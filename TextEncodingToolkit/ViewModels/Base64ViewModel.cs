using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

using Microsoft.Win32;

using Xlfdll;
using Xlfdll.Windows.Presentation;

namespace TextEncodingToolkit
{
    public class Base64ViewModel : BaseViewModel
    {
        public Base64ViewModel()
        {
            this.SelectedActionIndex = 0;
            this.SelectedModeIndex = 0;
            this.IsBusy = false;

            this.SelectedEncodingIndex = this.Encodings.IndexOf
                (this.Encodings.First(e => e.CodePage == Encoding.UTF8.CodePage));
        }

        private Int32 _selectedActionIndex;
        private Int32 _selectedModeIndex;
        private Boolean _isBusy;

        private Int32 _selectedEncodingIndex;
        private String _sourceText;
        private String _sourceFilePath;
        private Int32 _currentFileProgress;

        public Int32 SelectedActionIndex
        {
            get
            {
                return _selectedActionIndex;
            }
            set
            {
                SetField(ref _selectedActionIndex, value);

                this.SourceFilePath = null;
                this.SourceText = null;
            }
        }

        public Int32 SelectedModeIndex
        {
            get => _selectedModeIndex;
            set => SetField(ref _selectedModeIndex, value);
        }

        public Int32 SelectedEncodingIndex
        {
            get
            {
                return _selectedEncodingIndex;
            }
            set
            {
                SetField(ref _selectedEncodingIndex, value);

                OnPropertyChanged(nameof(this.ResultText));
            }
        }

        public Boolean IsBusy
        {
            get => _isBusy;
            private set => SetField(ref _isBusy, value);
        }

        public String SourceFilePath
        {
            get => _sourceFilePath;
            set => SetField(ref _sourceFilePath, value);
        }

        public Int32 CurrentFileProgress
        {
            get => _currentFileProgress;
            private set => SetField(ref _currentFileProgress, value);
        }

        public String SourceText
        {
            get
            {
                return _sourceText;
            }
            set
            {
                SetField(ref _sourceText, value);

                OnPropertyChanged(nameof(this.ResultText));
            }
        }

        public String ResultText
        {
            get
            {
                if (this.SourceText != null)
                {
                    Encoding selectedEncoding = this.Encodings[this.SelectedEncodingIndex].GetEncoding();

                    try
                    {
                        switch (this.SelectedActionIndex)
                        {
                            case 0:
                                Byte[] sourceBytes = selectedEncoding.GetBytes(this.SourceText);

                                return Convert.ToBase64String(sourceBytes);
                            case 1:
                                Byte[] base64Bytes = Convert.FromBase64String(this.SourceText);

                                return selectedEncoding.GetString(base64Bytes);
                            default:
                                throw new ApplicationException("Invalid action state occurred.");
                        }
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public RelayCommand<Object> BrowseCommand
            => new RelayCommand<Object>
            (
                delegate
                {
                    OpenFileDialog dialog = new OpenFileDialog()
                    {
                        Filter = this.SelectedActionIndex == 0 ? Constants.AllFileFilter : Constants.TextFileFilter,
                        RestoreDirectory = true
                    };

                    if (dialog.ShowDialog() == true)
                    {
                        this.SourceFilePath = dialog.FileName;
                    }
                }
            );

        public RelayCommand<Object> ExecuteCommand
            => new RelayCommand<Object>
            (
                delegate
                {
                    if (!this.IsBusy)
                    {
                        SaveFileDialog dialog = new SaveFileDialog()
                        {
                            Filter = this.SelectedActionIndex == 0 ? Constants.TextFileFilter : Constants.AllFileFilter,
                            FileName = Path.GetFileNameWithoutExtension(this.SourceFilePath),
                            RestoreDirectory = true
                        };

                        if (dialog.ShowDialog() == true)
                        {
                            this.IsBusy = true;

                            backgroundWorker = new BackgroundWorker()
                            {
                                WorkerReportsProgress = true,
                                WorkerSupportsCancellation = true
                            };
                            backgroundWorker.DoWork += FileModeBackgroundWorker_DoWork;
                            backgroundWorker.ProgressChanged += FileModeBackgroundWorker_ProgressChanged;
                            backgroundWorker.RunWorkerCompleted += FileModeBackgroundWorker_RunWorkerCompleted;

                            backgroundWorker.RunWorkerAsync(new Object[]
                            {
                                this.SourceFilePath,
                                dialog.FileName,
                                this.SelectedActionIndex
                            });
                        }
                    }
                    else
                    {
                        backgroundWorker.CancelAsync();
                    }
                },
                delegate
                {
                    return !String.IsNullOrEmpty(this.SourceFilePath);
                }
            );

        #region BackgroundWorker Event Handlers

        private void FileModeBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Object[] arguments = e.Argument as Object[];

            String sourceFilePath = arguments[0] as String;
            String targetFilePath = arguments[1] as String;
            Int32 action = Convert.ToInt32(arguments[2]);

            Int64 progress = 0;

            // Use 3 bytes (24 bits) to form 4 6-bit encoded characters
            switch (action)
            {
                case 0:
                    using (FileStream sourceFileStream = File.OpenRead(sourceFilePath))
                    {
                        Int64 singlePercentStreamLength = Convert.ToInt32(sourceFileStream.Length * 0.01);

                        using (StreamWriter targetStreamWriter = File.CreateText(targetFilePath))
                        {
                            Int32 sourceBlockByteCount = 3;
                            Byte[] sourceBlockBytes = new Byte[sourceBlockByteCount];
                            Int32 readCount = sourceFileStream.Read(sourceBlockBytes, 0, sourceBlockByteCount);

                            while (readCount > 0)
                            {
                                if (backgroundWorker.CancellationPending)
                                {
                                    e.Cancel = true;

                                    break;
                                }

                                progress += readCount;

                                targetStreamWriter.Write(Convert.ToBase64String(sourceBlockBytes, 0, sourceBlockByteCount));

                                // Limit the times of progress report, or UI would be locked up with memory leaks due to the massive cross-thread calls
                                if (progress % singlePercentStreamLength == 0)
                                {
                                    backgroundWorker.ReportProgress(Convert.ToInt32(progress * 100.0 / sourceFileStream.Length));
                                }

                                readCount = sourceFileStream.Read(sourceBlockBytes, 0, sourceBlockByteCount);
                            }
                        }
                    }

                    break;
                case 1:
                    using (StreamReader sourceStreamReader = File.OpenText(sourceFilePath))
                    {
                        Int64 singlePercentStreamLength = Convert.ToInt32(sourceStreamReader.BaseStream.Length * 0.01);

                        try
                        {
                            using (FileStream targetFileStream = File.Create(targetFilePath))
                            {
                                Int32 base64BlockCharacterCount = 4;
                                Char[] base64BlockCharacters = new Char[base64BlockCharacterCount];
                                Int32 writeCount = sourceStreamReader.Read(base64BlockCharacters, 0, base64BlockCharacterCount);

                                while (writeCount > 0)
                                {
                                    if (backgroundWorker.CancellationPending)
                                    {
                                        e.Cancel = true;

                                        break;
                                    }
                                    progress += writeCount;

                                    Byte[] targetBlockBytes = Convert.FromBase64CharArray(base64BlockCharacters, 0, writeCount);

                                    targetFileStream.Write(targetBlockBytes, 0, targetBlockBytes.Length);

                                    // Limit the times of progress report, or UI would be locked up with memory leaks due to the massive cross-thread calls
                                    if (progress % singlePercentStreamLength == 0)
                                    {
                                        backgroundWorker.ReportProgress(Convert.ToInt32(progress * 100.0 / sourceStreamReader.BaseStream.Length));
                                    }

                                    writeCount = sourceStreamReader.Read(base64BlockCharacters, 0, base64BlockCharacterCount);
                                }
                            }
                        }
                        catch
                        {
                            if (File.Exists(targetFilePath))
                            {
                                File.Delete(targetFilePath);
                            }

                            throw;
                        }
                    }

                    break;
                default:
                    throw new ApplicationException("Invalid action state occurred.");
            }

            if (e.Cancel && File.Exists(targetFilePath))
            {
                File.Delete(targetFilePath);
            }

            backgroundWorker.ReportProgress(100);
        }

        private void FileModeBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.CurrentFileProgress = e.ProgressPercentage;
        }

        private void FileModeBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.OperationErrorOccurred?.Invoke(sender, new ExceptionEventArgs(e.Error));
            }
            else if (e.Cancelled)
            {
                this.OperationCancelled?.Invoke(sender, new EventArgs());
            }
            else
            {
                this.OperationSucceeded?.Invoke(sender, new EventArgs());
            }

            this.IsBusy = false;

            backgroundWorker.Dispose();
        }

        private BackgroundWorker backgroundWorker;

        #endregion

        public event EventHandler<EventArgs> OperationSucceeded;
        public event EventHandler<EventArgs> OperationCancelled;
        public event EventHandler<ExceptionEventArgs> OperationErrorOccurred;
    }
}