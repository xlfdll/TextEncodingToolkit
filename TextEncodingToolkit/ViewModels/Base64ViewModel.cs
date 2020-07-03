using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

            this.OperationProgressChanged += Base64ViewModel_ProgressChanged;
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
                async delegate
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

                            if (this.CancellationTokenSource != null)
                            {
                                this.CancellationTokenSource.Dispose();
                            }

                            this.CancellationTokenSource = new CancellationTokenSource();

                            try
                            {
                                // Run all operations in one async block instead of using ReadAsync/WriteAsync methods
                                // Otherwise context switch would be very expensive
                                await Task.Run(() =>
                                {
                                    this.PerformBase64FileOperation(this.SourceFilePath, dialog.FileName, this.SelectedActionIndex);
                                });

                                this.OperationProgressChanged?.Invoke(this, new ProgressChangedEventArgs(100, null));

                                if (!this.CancellationTokenSource.IsCancellationRequested)
                                {
                                    this.OperationSucceeded?.Invoke(this, new EventArgs());
                                }
                                else
                                {
                                    if (File.Exists(dialog.FileName))
                                    {
                                        File.Delete(dialog.FileName);
                                    }

                                    this.OperationCancelled?.Invoke(this, new EventArgs());
                                }
                            }
                            catch (Exception ex)
                            {
                                this.OperationErrorOccurred?.Invoke(this, new ExceptionEventArgs(ex));
                            }
                            finally
                            {
                                this.IsBusy = false;
                            }
                        }
                    }
                    else
                    {
                        this.CancellationTokenSource.Cancel();
                    }
                },
                delegate
                {
                    return !String.IsNullOrEmpty(this.SourceFilePath);
                }
            );

        public event EventHandler<EventArgs> OperationSucceeded;
        public event EventHandler<EventArgs> OperationCancelled;
        public event EventHandler<ExceptionEventArgs> OperationErrorOccurred;

        private event ProgressChangedEventHandler OperationProgressChanged;
        private CancellationTokenSource CancellationTokenSource { get; set; }

        private void PerformBase64FileOperation(String sourceFilePath, String targetFilePath, Int32 actionIndex)
        {
            Int64 progress = 0;

            switch (actionIndex)
            {
                case 0:
                    using (FileStream sourceFileStream = File.OpenRead(sourceFilePath))
                    {
                        Int64 singlePercentStreamLength = Convert.ToInt64(sourceFileStream.Length * 0.01);

                        using (StreamWriter targetStreamWriter = File.CreateText(targetFilePath))
                        {
                            Int32 sourceBlockByteCount = 3;
                            Byte[] sourceBlockBytes = new Byte[sourceBlockByteCount];
                            Int32 readCount = sourceFileStream.Read(sourceBlockBytes, 0, sourceBlockByteCount);

                            while (readCount > 0)
                            {
                                if (this.CancellationTokenSource.IsCancellationRequested)
                                {
                                    break;
                                }

                                progress += readCount;

                                targetStreamWriter.Write(Convert.ToBase64String(sourceBlockBytes, 0, sourceBlockByteCount));

                                // Limit the times of progress report, or UI would be locked up with memory leaks due to the massive cross-thread calls
                                if (progress % singlePercentStreamLength == 0)
                                {
                                    this.OperationProgressChanged?.Invoke(this,
                                        new ProgressChangedEventArgs
                                        (Convert.ToInt32(progress * 100.0 / sourceFileStream.Length),
                                        null));
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
                                    if (this.CancellationTokenSource.IsCancellationRequested)
                                    {
                                        break;
                                    }

                                    progress += writeCount;

                                    Byte[] targetBlockBytes = Convert.FromBase64CharArray(base64BlockCharacters, 0, writeCount);

                                    targetFileStream.Write(targetBlockBytes, 0, targetBlockBytes.Length);

                                    // Limit the times of progress report, or UI would be locked up with memory leaks due to the massive cross-thread calls
                                    if (progress % singlePercentStreamLength == 0)
                                    {
                                        this.OperationProgressChanged?.Invoke(this,
                                            new ProgressChangedEventArgs
                                            (Convert.ToInt32(progress * 100.0 / sourceStreamReader.BaseStream.Length),
                                            null));
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
        }

        private void Base64ViewModel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.CurrentFileProgress = e.ProgressPercentage;
        }
    }
}