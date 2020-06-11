using System;
using System.Linq;
using System.Text;

namespace TextEncodingToolkit
{
    public class CompareTabViewModel : BaseViewModel
    {
        public CompareTabViewModel()
        {
            this.SelectedText2BytesEncodingIndex = this.Encodings.IndexOf
                (this.Encodings.First(e => e.CodePage == Encoding.UTF8.CodePage));
            this.SelectedBytes2TextEncodingIndex = this.Encodings.IndexOf
                (this.Encodings.First(e => e.CodePage == Encoding.UTF8.CodePage));
            this.ShowSpaceForText2Bytes = true;
            this.ShowSpaceForBytes2Text = true;
        }

        private Int32 _selectedText2BytesEncodingIndex;
        private Int32 _selectedBytes2TextEncodingIndex;
        private Boolean _showSpaceForText2Bytes;
        private Boolean _showSpaceForBytes2Text;
        private String _text2BytesSourceText;
        private String _bytes2TextHexText;

        public Int32 SelectedText2BytesEncodingIndex
        {
            get
            {
                return _selectedText2BytesEncodingIndex;
            }
            set
            {
                SetField(ref _selectedText2BytesEncodingIndex, value);

                if (this.Text2BytesSourceText != null)
                {
                    OnPropertyChanged(nameof(this.Text2BytesHexText));
                    OnPropertyChanged(nameof(this.Text2BytesBinaryText));
                }
            }
        }

        public Int32 SelectedBytes2TextEncodingIndex
        {
            get
            {
                return _selectedBytes2TextEncodingIndex;
            }
            set
            {
                SetField(ref _selectedBytes2TextEncodingIndex, value);

                if (this.Bytes2TextHexText != null)
                {
                    OnPropertyChanged(nameof(this.Bytes2TextSourceText));
                    OnPropertyChanged(nameof(this.Bytes2TextBinaryText));
                }
            }
        }

        public Boolean ShowSpaceForText2Bytes
        {
            get
            {
                return _showSpaceForText2Bytes;
            }
            set
            {
                SetField(ref _showSpaceForText2Bytes, value);

                if (this.Text2BytesSourceText != null)
                {
                    OnPropertyChanged(nameof(this.Text2BytesHexText));
                    OnPropertyChanged(nameof(this.Text2BytesBinaryText));
                }
            }
        }

        public Boolean ShowSpaceForBytes2Text
        {
            get
            {
                return _showSpaceForBytes2Text;
            }
            set
            {
                SetField(ref _showSpaceForBytes2Text, value);

                if (this.Bytes2TextHexText != null)
                {
                    OnPropertyChanged(nameof(this.Bytes2TextBinaryText));
                }
            }
        }

        public String Text2BytesSourceText
        {
            get
            {
                return _text2BytesSourceText;
            }
            set
            {
                SetField(ref _text2BytesSourceText, value);

                if (value != null)
                {
                    OnPropertyChanged(nameof(this.Text2BytesHexText));
                    OnPropertyChanged(nameof(this.Text2BytesBinaryText));
                }
            }
        }

        public String Text2BytesHexText
        {
            get
            {
                if (this.Text2BytesSourceText != null)
                {
                    return this.Text2BytesSourceText.ToHexString
                        (this.Encodings[this.SelectedText2BytesEncodingIndex].GetEncoding(),
                        this.ShowSpaceForText2Bytes);
                }

                return null;
            }
        }

        public String Text2BytesBinaryText
        {
            get
            {
                if (this.Text2BytesSourceText != null)
                {
                    return this.Text2BytesSourceText.ToBinaryString
                        (this.Encodings[this.SelectedText2BytesEncodingIndex].GetEncoding(),
                        this.ShowSpaceForText2Bytes);
                }

                return null;
            }
        }

        public String Bytes2TextHexText
        {
            get
            {
                return _bytes2TextHexText;
            }
            set
            {
                SetField(ref _bytes2TextHexText, value);

                if (value != null)
                {
                    OnPropertyChanged(nameof(this.Bytes2TextSourceText));
                    OnPropertyChanged(nameof(this.Bytes2TextBinaryText));
                }
            }
        }

        public String Bytes2TextSourceText
        {
            get
            {
                if (this.Bytes2TextHexText != null)
                {
                    return DataHelper.ConvertHexToString
                        (this.Bytes2TextHexText,
                        this.Encodings[this.SelectedBytes2TextEncodingIndex].GetEncoding());
                }

                return null;
            }
        }

        public String Bytes2TextBinaryText
        {
            get
            {
                if (this.Bytes2TextHexText != null)
                {
                    return DataHelper.ConvertHexToBinaryString
                        (this.Bytes2TextHexText,
                        this.ShowSpaceForBytes2Text);
                }

                return null;
            }
        }
    }
}