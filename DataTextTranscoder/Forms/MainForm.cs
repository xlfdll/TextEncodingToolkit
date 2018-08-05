using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataTextTranscoder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            foreach (Form form in this.OwnedForms)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    form.Hide();
                }
                else
                {
                    form.Show(this);
                }
            }
        }

        private void mainFormButton_DragEnter(object sender, DragEventArgs e)
        {
            Button mainFormButton = sender as Button;

            if (mainFormButton != null)
            {
                if (mainFormButton == fileConvertButton || mainFormButton == base64ConvertButton)
                {
                    if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    {
                        e.Effect = DragDropEffects.Copy;
                    }
                }
            }
        }

        private void mainFormButton_DragDrop(object sender, DragEventArgs e)
        {
            Button mainFormButton = sender as Button;

            if (mainFormButton != null)
            {
                if (mainFormButton == fileConvertButton)
                {
                    fileConvertButton_Click(sender, e);

                    String[] filenames = e.Data.GetData(DataFormats.FileDrop) as String[];

                    if (filenames != null && filenames.Length > 0)
                    {
                        FormHelper.TextFileConverterForm.LoadFile(filenames[0]);
                    }
                }
                else if (mainFormButton == base64ConvertButton)
                {
                    String[] filenames = e.Data.GetData(DataFormats.FileDrop) as String[];

                    if (filenames != null && filenames.Length > 0)
                    {
                        base64ModeContextMenuStrip.Tag = filenames[0];
                        base64ModeContextMenuStrip.Show(base64ConvertButton, base64ConvertButton.PointToClient(Control.MousePosition), ToolStripDropDownDirection.BelowRight);
                    }
                }
            }
        }

        private void base64ModeContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            base64ModeContextMenuStrip.Hide();

            base64ConvertButton_Click(sender, e);

            FormHelper.Base64CoderForm.LoadFile(base64ModeContextMenuStrip.Tag.ToString(), Int32.Parse(e.ClickedItem.Tag.ToString()));

            base64ModeContextMenuStrip.Tag = null;
        }

        private void fileConvertButton_Click(object sender, EventArgs e)
        {
            FormHelper.ShowForm(Transcoders.TextFileConverter);
        }

        private void textConvertButton_Click(object sender, EventArgs e)
        {
            FormHelper.ShowForm(Transcoders.TextTranscoder);
        }

        private void base64ConvertButton_Click(object sender, EventArgs e)
        {
            FormHelper.ShowForm(Transcoders.Base64Coder);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
