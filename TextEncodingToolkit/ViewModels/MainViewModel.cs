using System;

using Xlfdll.Windows.Presentation;
using Xlfdll.Windows.Presentation.Dialogs;

namespace TextEncodingToolkit
{
    public class MainViewModel : BaseViewModel
    {
        public ConvertTabViewModel ConvertTabViewModel
            => new ConvertTabViewModel();
        public CompareTabViewModel CompareTabViewModel
            => new CompareTabViewModel();
        public Base64ViewModel Base64ViewModel
            => new Base64ViewModel();

        public RelayCommand<Object> Base64Command
            => new RelayCommand<Object>
            (
                delegate
                {
                    Base64Window base64Window = new Base64Window()
                    {
                        Owner = App.Current.MainWindow,
                        DataContext = this.Base64ViewModel
                    };

                    base64Window.ShowDialog();
                }
            );

        public RelayCommand<Object> ExitCommand
            => new RelayCommand<Object>
            (
                delegate
                {
                    App.Current.MainWindow.Close();
                }
            );

        public RelayCommand<Object> AboutCommand
            => new RelayCommand<Object>
            (
                delegate
                {
                    AboutWindow aboutWindow = new AboutWindow
                        (
                        App.Current.MainWindow,
                        App.Metadata,
                        new ApplicationPackUri("/Images/TextEncodingToolkit.png")
                        );

                    aboutWindow.ShowDialog();
                }
            );
    }
}