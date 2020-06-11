using System;
using System.IO;
using System.Windows;

using Xlfdll;
using Xlfdll.Windows.Presentation.Dialogs;

namespace TextEncodingToolkit
{
    /// <summary>
    /// Base64Window.xaml の相互作用ロジック
    /// </summary>
    public partial class Base64Window : Window
    {
        public Base64Window()
        {
            InitializeComponent();
        }

        private void Base64Window_Loaded(object sender, RoutedEventArgs e)
        {
            Base64ViewModel viewModel = this.DataContext as Base64ViewModel;

            if (viewModel != null)
            {
                viewModel.OperationSucceeded += ViewModel_OperationSucceeded;
                viewModel.OperationCancelled += ViewModel_OperationCancelled;
                viewModel.OperationErrorOccurred += ViewModel_OperationErrorOccurred;
            }
        }

        private void Base64Window_Unloaded(object sender, RoutedEventArgs e)
        {
            Base64ViewModel viewModel = this.DataContext as Base64ViewModel;

            if (viewModel != null)
            {
                viewModel.OperationSucceeded -= ViewModel_OperationSucceeded;
                viewModel.OperationCancelled -= ViewModel_OperationCancelled;
                viewModel.OperationErrorOccurred -= ViewModel_OperationErrorOccurred;
            }
        }

        private void SourceFilePathTextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
                e.Handled = true; // Only stop handling after a file drop
            }
        }

        private void SourceFilePathTextBox_Drop(object sender, DragEventArgs e)
        {
            String[] files = e.Data.GetData(DataFormats.FileDrop) as String[];

            if (files != null && files.Length > 0)
            {
                Base64ViewModel viewModel = this.DataContext as Base64ViewModel;

                if (viewModel != null)
                {
                    if (viewModel.SelectedActionIndex == 1
                        && !Constants.TextFileFilter.Contains(Path.GetExtension(files[0])))
                    {
                        return;
                    }

                    viewModel.SourceFilePath = files[0];
                }
            }
        }

        #region ViewModel Events

        private void ViewModel_OperationSucceeded(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Operation completed successfully.", this.Title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ViewModel_OperationCancelled(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Operation cancelled.", this.Title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ViewModel_OperationErrorOccurred(object sender, ExceptionEventArgs e)
        {
            ExceptionMessageBox.Show(this, this.Title, "The following error occurred:", e.Exception);
        }

        #endregion
    }
}