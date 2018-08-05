using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DataTextTranscoder
{
    internal static class FormHelper
    {
        static FormHelper()
        {
            _mainForm = new MainForm();
        }

        internal static void ShowForm(Transcoders transcoderName)
        {
            Form targetForm = null;

            switch (transcoderName)
            {
                case Transcoders.TextFileConverter:
                    {
                        if (_textFileConverterForm == null || _textFileConverterForm.IsDisposed)
                        {
                            _textFileConverterForm = new TextFileConverterForm();
                        }

                        targetForm = _textFileConverterForm;

                        break;
                    }
                case Transcoders.TextTranscoder:
                    {
                        if (_textTranscoderForm == null || _textTranscoderForm.IsDisposed)
                        {
                            _textTranscoderForm = new TextTranscoderForm();
                        }

                        targetForm = _textTranscoderForm;

                        break;
                    }
                case Transcoders.Base64Coder:
                    {
                        if (_base64CoderForm == null || _base64CoderForm.IsDisposed)
                        {
                            _base64CoderForm = new Base64CoderForm();
                        }

                        targetForm = _base64CoderForm;

                        break;
                    }
                default:
                    break;
            }

            if (!targetForm.Visible)
            {
                targetForm.Show(_mainForm);
            }
            else
            {
                targetForm.Focus();
            }
        }

        private static MainForm _mainForm;
        private static TextFileConverterForm _textFileConverterForm;
        private static TextTranscoderForm _textTranscoderForm;
        private static Base64CoderForm _base64CoderForm;

        internal static MainForm MainForm
        {
            get { return _mainForm; }
        }

        internal static TextFileConverterForm TextFileConverterForm
        {
            get { return _textFileConverterForm; }
        }

        internal static TextTranscoderForm TextTranscoderForm
        {
            get { return _textTranscoderForm; }
        }

        internal static Base64CoderForm Base64CoderForm
        {
            get { return _base64CoderForm; }
        }
    }

    internal enum Transcoders { TextFileConverter, TextTranscoder, Base64Coder }
}