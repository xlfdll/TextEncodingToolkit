using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TextEncodingToolkit
{
    internal static class FormHelper
    {
        static FormHelper()
        {
            _mainForm = new MainForm();
        }

        internal static void ShowForm(TextEncodingTools textEncodingToolName)
        {
            Form targetForm = null;

            switch (textEncodingToolName)
            {
                case TextEncodingTools.TextEncodingConverter:
                    {
                        if (_textEncodingConverterForm == null || _textEncodingConverterForm.IsDisposed)
                        {
                            _textEncodingConverterForm = new TextEncodingConverterForm();
                        }

                        targetForm = _textEncodingConverterForm;

                        break;
                    }
                case TextEncodingTools.TextEncodingIntepreter:
                    {
                        if (_textEncodingIntepreterForm == null || _textEncodingIntepreterForm.IsDisposed)
                        {
                            _textEncodingIntepreterForm = new TextTranscoderForm();
                        }

                        targetForm = _textEncodingIntepreterForm;

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
        private static TextEncodingConverterForm _textEncodingConverterForm;
        private static TextTranscoderForm _textEncodingIntepreterForm;

        internal static MainForm MainForm
        {
            get { return _mainForm; }
        }

        internal static TextEncodingConverterForm TextEncodingConverterForm
        {
            get { return _textEncodingConverterForm; }
        }

        internal static TextTranscoderForm TextEncodingIntepreterForm
        {
            get { return _textEncodingIntepreterForm; }
        }
    }

    internal enum TextEncodingTools { TextEncodingConverter, TextEncodingIntepreter }
}