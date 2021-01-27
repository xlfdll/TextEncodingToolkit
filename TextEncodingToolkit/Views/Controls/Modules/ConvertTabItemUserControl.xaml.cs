using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace TextEncodingToolkit
{
    /// <summary>
    /// ConvertTabItemUserControl.xaml の相互作用ロジック
    /// </summary>
    public partial class ConvertTabItemUserControl : UserControl
    {
        public ConvertTabItemUserControl()
        {
            InitializeComponent();
        }

        private void ConvertTabItemUserControl_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
                e.Handled = true; // Only stop handling after a file drop
            }
        }

        private void ConvertTabItemUserControl_Drop(object sender, DragEventArgs e)
        {
            String[] files = e.Data.GetData(DataFormats.FileDrop) as String[];

            if (files != null && files.Length > 0)
            {
                ConvertTabViewModel viewModel = this.DataContext as ConvertTabViewModel;

                if (viewModel != null)
                {
                    viewModel.SourceBytes = File.ReadAllBytes(files[0]);
                }
            }
        }
    }
}