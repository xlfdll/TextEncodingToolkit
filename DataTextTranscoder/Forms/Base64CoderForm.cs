using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using DataTextTranscoder.Properties;

namespace DataTextTranscoder
{
    public partial class Base64CoderForm : Form
    {
        public Base64CoderForm()
        {
            InitializeComponent();
        }

        private void Base64CoderForm_Load(object sender, EventArgs e)
        {
            EncodingComboBoxHelper.FillEncodingComboBox(encodingComboBox);

            encodingComboBox.SelectedIndex = encodingComboBox.FindString(Encoding.UTF8.CodePage.ToString());

            modeComboBox.SelectedIndex = 0;
            sourceComboBox.SelectedIndex = 0;
        }

        private void Base64CoderForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Base64CoderForm_DragDrop(object sender, DragEventArgs e)
        {
            String[] filenames = e.Data.GetData(DataFormats.FileDrop) as String[];

            if (filenames != null && filenames.Length > 0)
            {
                processFile(filenames[0], modeComboBox.SelectedIndex);
            }
        }

        private void base64ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.AllowDrop = (sourceComboBox.SelectedIndex == 0);

            encodingLabel.Enabled = (sourceComboBox.SelectedIndex == 1);
            encodingComboBox.Enabled = (sourceComboBox.SelectedIndex == 1);

            switch (sourceComboBox.SelectedIndex)
            {
                case 0:
                    {
                        executeButton.Text = "&Browse...";
                        helpLabel.Text = String.Format(@"Click ""Browse..."" button to select a file and {0}.", modeComboBox.SelectedItem.ToString().ToLower());

                        break;
                    }
                case 1:
                    {
                        executeButton.Text = "&Execute";
                        helpLabel.Text = String.Format(@"Click ""Execute"" button to {0} text in Windows clipboard.", modeComboBox.SelectedItem.ToString().ToLower());

                        break;
                    }
                default:
                    break;
            }
        }

        private void encodingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedEncodingString = encodingComboBox.SelectedItem.ToString();

            _encoding = EncodingComboBoxHelper.GetEncodingByDescription(selectedEncodingString);

            mainToolTip.SetToolTip(encodingComboBox, selectedEncodingString);
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            switch (sourceComboBox.SelectedIndex)
            {
                case 0:
                    {
                        if (!fileProcessBackgroundWorker.IsBusy)
                        {
                            using (OpenFileDialog dlg = new OpenFileDialog())
                            {
                                dlg.Title = String.Format("Open File ({0})", modeComboBox.SelectedItem.ToString());
                                dlg.Filter = (modeComboBox.SelectedIndex == 0) ? "All Files(*.*)|*.*" : "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";

                                if (dlg.ShowDialog() == DialogResult.OK)
                                {
                                    processFile(dlg.FileName, modeComboBox.SelectedIndex);
                                }
                            }
                        }
                        else
                        {
                            fileProcessBackgroundWorker.CancelAsync();
                        }

                        break;
                    }
                case 1:
                    {
                        if (Clipboard.ContainsText())
                        {
                            switch (modeComboBox.SelectedIndex)
                            {
                                case 0:
                                    {
                                        Byte[] bytes = _encoding.GetBytes(Clipboard.GetText());
                                        Clipboard.SetText(Convert.ToBase64String(bytes));

                                        break;
                                    }
                                case 1:
                                    {
                                        try
                                        {
                                            Byte[] bytes = Convert.FromBase64String(Clipboard.GetText());
                                            Clipboard.SetText(_encoding.GetString(bytes));
                                        }
                                        catch (FormatException ex)
                                        {
                                            helpLabel.Text = ex.Message;

                                            return;
                                        }

                                        break;
                                    }
                                default:
                                    break;
                            }

                            helpLabel.Text = "Convertion done. Result has been copied to Windows clipboard.";
                        }
                        else
                        {
                            helpLabel.Text = "No text in Windows clipboard.";
                        }

                        break;
                    }
                default:
                    break;
            }
        }

        private void fileProcessBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            String[] arguments = e.Argument.ToString().Split('|');

            String openFileName = arguments[1];
            String saveFileName = arguments[2];

            Int32 mode = Int32.Parse(arguments[0]);
            Int32 progress = 0;

            switch (mode)
            {
                case 0:
                    {
                        using (FileStream sourceFileStream = File.OpenRead(openFileName))
                        {
                            Int32 singlePercentStreamLength = Convert.ToInt32(sourceFileStream.Length * 0.01);

                            using (StreamWriter destinationStreamWriter = File.CreateText(saveFileName))
                            {
                                Byte[] sourceBlockBytes = new Byte[3];

                                Int32 readCount = sourceFileStream.Read(sourceBlockBytes, 0, 3);

                                while (readCount > 0)
                                {
                                    if (fileProcessBackgroundWorker.CancellationPending)
                                    {
                                        e.Cancel = true;

                                        break;
                                    }
                                    else
                                    {
                                        destinationStreamWriter.Write(Convert.ToBase64String(sourceBlockBytes, 0, readCount));

                                        readCount = sourceFileStream.Read(sourceBlockBytes, 0, 3);

                                        progress += 3;

                                        if (progress % singlePercentStreamLength == 0)
                                        {
                                            fileProcessBackgroundWorker.ReportProgress(progress, sourceFileStream.Length.ToString());
                                        }
                                    }
                                }
                            }
                        }

                        break;
                    }
                case 1:
                    {
                        using (StreamReader sourceStreamReader = File.OpenText(openFileName))
                        {
                            Int32 singlePercentStreamLength = Convert.ToInt32(sourceStreamReader.BaseStream.Length * 0.01);

                            using (FileStream destinationFileStream = File.Create(saveFileName))
                            {
                                Char[] base64BlockChars = new Char[4];

                                Int32 writeCount = sourceStreamReader.Read(base64BlockChars, 0, 4);

                                while (writeCount > 0)
                                {
                                    if (fileProcessBackgroundWorker.CancellationPending)
                                    {
                                        e.Cancel = true;

                                        break;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            Byte[] writeBytes = Convert.FromBase64CharArray(base64BlockChars, 0, writeCount);

                                            destinationFileStream.Write(writeBytes, 0, writeBytes.Length);

                                            writeCount = sourceStreamReader.Read(base64BlockChars, 0, 4);

                                            progress += 4;

                                            if (progress % singlePercentStreamLength == 0)
                                            {
                                                fileProcessBackgroundWorker.ReportProgress(progress, sourceStreamReader.BaseStream.Length.ToString());
                                            }
                                        }
                                        catch (FormatException formatEx)
                                        {
                                            e.Result = formatEx.Message;

                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        break;
                    }
                default:
                    break;
            }

            if (e.Cancel)
            {
                File.Delete(saveFileName);
            }
        }

        private void fileProcessBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Double percentageFactor = e.ProgressPercentage / Double.Parse(e.UserState.ToString());
            Int32 percentage = Convert.ToInt32(Math.Ceiling(percentageFactor * 100));

            String modeString = modeComboBox.SelectedItem.ToString();
            helpLabel.Text = String.Format("{0}ing... {1}%", modeString.Remove(modeString.Length - 1), percentage.ToString());

            if (percentage <= mainProgressBar.Maximum)
            {
                mainProgressBar.Value = percentage;
            }
        }

        private void fileProcessBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            helpLabel.Text = (e.Result == null) ? (!e.Cancelled ? "All operations done." : "Operations cancelled.") : e.Result.ToString();

            executeButton.Text = "&Browse...";

            modeComboBox.Enabled = true;
            sourceComboBox.Enabled = true;
            this.ControlBox = true;

            mainProgressBar.Value = mainProgressBar.Maximum;
        }

        private void processFile(String fileName, Int32 mode)
        {
            modeComboBox.SelectedIndex = mode;

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = String.Format("Save File ({0}d)", modeComboBox.SelectedItem.ToString());
                dlg.Filter = (modeComboBox.SelectedIndex == 0) ? "Text Document(*.txt)|*.txt|All Files(*.*)|*.*" : "All Files(*.*)|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.ControlBox = false;
                    modeComboBox.Enabled = false;
                    sourceComboBox.Enabled = false;

                    mainProgressBar.Value = mainProgressBar.Minimum;

                    executeButton.Text = "&Cancel";

                    helpLabel.Text = "Processing...";

                    fileProcessBackgroundWorker.RunWorkerAsync(String.Format("{0}|{1}|{2}", mode.ToString(), fileName, dlg.FileName));
                }
            }
        }

        private Encoding _encoding;

        internal void LoadFile(String fileName, Int32 mode)
        {
            processFile(fileName, mode);
        }
    }
}