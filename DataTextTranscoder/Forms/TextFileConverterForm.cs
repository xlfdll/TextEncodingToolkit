using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DataTextTranscoder
{
    public partial class TextFileConverterForm : Form
    {
        public TextFileConverterForm()
        {
            InitializeComponent();
        }

        private void TextFileConverterForm_Load(object sender, EventArgs e)
        {
            EncodingComboBoxHelper.FillEncodingComboBox(sourceEncodingComboBox, destinationEncodingComboBox);

            sourceEncodingComboBox.SelectedIndex = sourceEncodingComboBox.FindString(Encoding.Default.CodePage.ToString());
            destinationEncodingComboBox.SelectedIndex = destinationEncodingComboBox.FindString(Encoding.UTF8.CodePage.ToString());
        }

        private void TextFileConverterForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void TextFileConverterForm_DragDrop(object sender, DragEventArgs e)
        {
            String[] filenames = e.Data.GetData(DataFormats.FileDrop) as String[];

            if (filenames != null && filenames.Length > 0)
            {
                SourceBytes = File.ReadAllBytes(filenames[0]);
            }
        }

        private void encodingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox encodingComboBox = sender as ComboBox;

            if (encodingComboBox != null)
            {
                String selectedEncodingString = encodingComboBox.SelectedItem.ToString();

                if (encodingComboBox == sourceEncodingComboBox)
                {
                    SourceEncoding = EncodingComboBoxHelper.GetEncodingByDescription(selectedEncodingString);
                }
                else if (encodingComboBox == destinationEncodingComboBox)
                {
                    DestinationEncoding = EncodingComboBoxHelper.GetEncodingByDescription(selectedEncodingString);
                }

                mainToolTip.SetToolTip(encodingComboBox, selectedEncodingString);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "All Files (*.*)|*.*";
                dlg.Multiselect = false;
                dlg.CheckFileExists = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    SourceBytes = File.ReadAllBytes(dlg.FileName);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Text Document (*.txt)|*.txt|All Files (*.*)|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllLines(dlg.FileName, destinationRichTextBox.Lines, DestinationEncoding);
                }
            }
        }

        private void textContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            RichTextBox richTextBox = textContextMenuStrip.SourceControl as RichTextBox;

            if (richTextBox != null)
            {
                copyToolStripMenuItem.Enabled = !String.IsNullOrEmpty(richTextBox.SelectedText);

                selectAllToolStripMenuItem.Enabled = (richTextBox.SelectedText != richTextBox.Text);
                deselectAllToolStripMenuItem.Enabled = !String.IsNullOrEmpty(richTextBox.SelectedText);
            }
        }

        private void textContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            RichTextBox richTextBox = textContextMenuStrip.SourceControl as RichTextBox;

            if (richTextBox != null)
            {
                switch (e.ClickedItem.Text.Replace("&", String.Empty))
                {
                    case "Copy":
                        {
                            richTextBox.Copy();

                            break;
                        }
                    case "Paste":
                        {
                            if (Clipboard.ContainsText())
                            {
                                SourceBytes = Encoding.Default.GetBytes(Clipboard.GetText());
                            }
                            else if (Clipboard.ContainsFileDropList())
                            {
                                SourceBytes = File.ReadAllBytes(Clipboard.GetFileDropList()[0]);
                            }

                            break;
                        }
                    case "Select All":
                        {
                            richTextBox.SelectAll();

                            break;
                        }
                    case "Deselect All":
                        {
                            richTextBox.DeselectAll();

                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private Encoding _sourceEncoding;
        private Encoding _destinationEncoding;
        private Byte[] _sourceBytes;
        private Byte[] _destinationBytes;

        private Encoding SourceEncoding
        {
            get { return _sourceEncoding; }
            set
            {
                _sourceEncoding = value;

                if (_sourceBytes != null && _sourceBytes.Length > 0)
                {
                    sourceRichTextBox.Text = _sourceEncoding.GetString(_sourceBytes);

                    DestinationBytes = Encoding.Convert(_sourceEncoding, _destinationEncoding, _sourceBytes);
                }
            }
        }

        private Encoding DestinationEncoding
        {
            get { return _destinationEncoding; }
            set
            {
                _destinationEncoding = value;

                if (_destinationBytes != null && _destinationBytes.Length > 0)
                {
                    DestinationBytes = Encoding.Convert(_sourceEncoding, _destinationEncoding, _sourceBytes);
                }
            }
        }

        private Byte[] SourceBytes
        {
            get { return _sourceBytes; }
            set
            {
                _sourceBytes = value;

                if (_sourceBytes != null && _sourceBytes.Length > 0)
                {
                    sourceHexRichTextBox.Text = EncodingHelper.ConvertBytesToHexString(_sourceBytes, true);
                    sourceRichTextBox.Text = _sourceEncoding.GetString(_sourceBytes);

                    DestinationBytes = Encoding.Convert(_sourceEncoding, _destinationEncoding, _sourceBytes);
                }
            }
        }

        private Byte[] DestinationBytes
        {
            get { return _destinationBytes; }
            set
            {
                _destinationBytes = value;

                if (_destinationBytes != null && _destinationBytes.Length > 0)
                {
                    destinationHexRichTextBox.Text = EncodingHelper.ConvertBytesToHexString(_destinationBytes, true);
                    destinationRichTextBox.Text = _destinationEncoding.GetString(_destinationBytes);
                }
            }
        }

        internal void LoadFile(String fileName)
        {
            SourceBytes = File.ReadAllBytes(fileName);
        }
    }
}