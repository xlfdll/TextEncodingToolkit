using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TextEncodingToolkit
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
                if (mainFormButton == converterButton)
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
                if (mainFormButton == converterButton)
                {
                    fileConvertButton_Click(sender, e);

                    String[] filenames = e.Data.GetData(DataFormats.FileDrop) as String[];

                    if (filenames != null && filenames.Length > 0)
                    {
                        FormHelper.TextEncodingConverterForm.LoadFile(filenames[0]);
                    }
                }
            }
        }

        private void fileConvertButton_Click(object sender, EventArgs e)
        {
            FormHelper.ShowForm(TextEncodingTools.TextEncodingConverter);
        }

        private void textConvertButton_Click(object sender, EventArgs e)
        {
            FormHelper.ShowForm(TextEncodingTools.TextEncodingIntepreter);
        }
    }
}
