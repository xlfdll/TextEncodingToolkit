using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataTextTranscoder
{
    public partial class TextTranscoderForm : Form
    {
        public TextTranscoderForm()
        {
            InitializeComponent();
        }

        private void TextTranscoderForm_Load(object sender, EventArgs e)
        {
            EncodingComboBoxHelper.FillEncodingComboBox(encodingComboBox);

            encodingComboBox.SelectedIndex = encodingComboBox.FindString(Encoding.Default.CodePage.ToString());

            modeComboBox.SelectedIndex = 0;
        }

        private void modeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            contentTextBox.ReadOnly = !(modeComboBox.SelectedIndex == 0);
            hexTextBox.ReadOnly = !(modeComboBox.SelectedIndex == 1);

            contentTextBox.Clear();
            hexTextBox.Clear();
        }

        private void encodingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedEncodingString = encodingComboBox.SelectedItem.ToString();

            _encoding = EncodingComboBoxHelper.GetEncodingByDescription(selectedEncodingString);

            mainToolTip.SetToolTip(encodingComboBox, selectedEncodingString);

            inputTextBox_TextChanged(sender, e);
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            switch (modeComboBox.SelectedIndex)
            {
                case 0:
                    {
                        hexTextBox.Text = EncodingHelper.ConvertStringToHexString(contentTextBox.Text, _encoding, spaceCheckBox.Checked);
                        binTextBox.Text = EncodingHelper.ConvertStringToBinString(contentTextBox.Text, _encoding, spaceCheckBox.Checked);

                        break;
                    }
                case 1:
                    {
                        contentTextBox.Text = EncodingHelper.ConvertHexStringToString(hexTextBox.Text, _encoding);
                        binTextBox.Text = EncodingHelper.ConvertHexStringToBinString(hexTextBox.Text, spaceCheckBox.Checked);

                        break;
                    }
                default:
                    break;
            }
        }

        private Encoding _encoding;
    }
}