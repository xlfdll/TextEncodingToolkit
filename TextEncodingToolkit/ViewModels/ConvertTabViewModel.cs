using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

using Microsoft.Win32;

using Xlfdll.Windows.Presentation;

namespace TextEncodingToolkit
{
    public class ConvertTabViewModel : ViewModelBase
    {
        public ConvertTabViewModel()
        {
            this.SelectedSourceEncodingIndex = this.Encodings.IndexOf
                (this.Encodings.First(e => e.CodePage == Encoding.Default.CodePage));
            this.SelectedTargetEncodingIndex = this.Encodings.IndexOf
                (this.Encodings.First(e => e.CodePage == Encoding.UTF8.CodePage));
        }

        private Int32 _selectedSourceEncodingIndex;
        private Int32 _selectedTargetEncodingIndex;
        private Byte[] _sourceBytes;

        public Int32 SelectedSourceEncodingIndex
        {
            get
            {
                return _selectedSourceEncodingIndex;
            }
            set
            {
                SetField(ref _selectedSourceEncodingIndex, value);

                if (this.SourceBytes != null)
                {
                    OnPropertyChanged(nameof(this.SourceText));
                    OnPropertyChanged(nameof(this.TargetText));
                    OnPropertyChanged(nameof(this.TargetHexText));
                }
            }
        }

        public Int32 SelectedTargetEncodingIndex
        {
            get
            {
                return _selectedTargetEncodingIndex;
            }
            set
            {
                SetField(ref _selectedTargetEncodingIndex, value);

                if (this.SourceBytes != null)
                {
                    OnPropertyChanged(nameof(this.TargetText));
                    OnPropertyChanged(nameof(this.TargetHexText));
                }
            }
        }

        public Byte[] SourceBytes
        {
            get
            {
                return _sourceBytes;
            }
            set
            {
                SetField(ref _sourceBytes, value);

                if (value != null)
                {
                    OnPropertyChanged(nameof(this.SourceText));
                    OnPropertyChanged(nameof(this.SourceHexText));
                    OnPropertyChanged(nameof(this.TargetText));
                    OnPropertyChanged(nameof(this.TargetHexText));
                }
            }
        }

        public Byte[] TargetBytes => Encoding.Convert
            (this.Encodings[this.SelectedSourceEncodingIndex].GetEncoding(),
            this.Encodings[this.SelectedTargetEncodingIndex].GetEncoding(),
            this.SourceBytes);

        public String SourceText
        {
            get
            {
                if (this.SourceBytes != null)
                {
                    return this.Encodings[this.SelectedSourceEncodingIndex]
                        .GetEncoding()
                        .GetString(this.SourceBytes);
                }

                return null;
            }
        }

        public String SourceHexText
        {
            get
            {
                if (this.SourceBytes != null)
                {
                    return this.SourceBytes.ToHexString(true);
                }

                return null;
            }
        }

        public String TargetText
        {
            get
            {
                if (this.SourceBytes != null)
                {
                    return this.Encodings[this.SelectedTargetEncodingIndex]
                        .GetEncoding()
                        .GetString(this.TargetBytes);
                }

                return null;
            }
        }

        public String TargetHexText
        {
            get
            {
                if (this.SourceBytes != null)
                {
                    return this.TargetBytes.ToHexString(true);
                }

                return null;
            }
        }

        public RelayCommand<Object> OpenFileCommand
            => new RelayCommand<Object>
            (
                delegate
                {
                    OpenFileDialog dialog = new OpenFileDialog()
                    {
                        Filter = Constants.TextFileFilter,
                        RestoreDirectory = true
                    };

                    if (dialog.ShowDialog() == true)
                    {
                        this.SourceBytes = File.ReadAllBytes(dialog.FileName);
                    }
                }
            );

        public RelayCommand<Object> SaveFileCommand
            => new RelayCommand<Object>
            (
                delegate
                {
                    SaveFileDialog dialog = new SaveFileDialog()
                    {
                        Filter = Constants.TextFileFilter,
                        RestoreDirectory = true
                    };

                    if (dialog.ShowDialog() == true)
                    {
                        File.WriteAllBytes(dialog.FileName, this.TargetBytes);
                    }
                }
            );

        public RelayCommand<Object> PasteSourceCommand
            => new RelayCommand<Object>
            (
                delegate
                {
                    if (Clipboard.ContainsFileDropList())
                    {
                        this.SourceBytes = File.ReadAllBytes(Clipboard.GetFileDropList()[0]);
                    }
                    else if (Clipboard.ContainsText())
                    {
                        this.SourceBytes
                            = this.Encodings[this.SelectedSourceEncodingIndex]
                                .GetEncoding()
                                .GetBytes(Clipboard.GetText());
                    }
                }
            );
    }
}