using GenshinImpact.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GenshinImpact
{
    class MainWindowViewModel : ViewModelBase
    {
        public ICommand OpenUrlCommand { get; }
        public ICommand CloseWindow { get; }
        public ICommand MinimizeWindow { get; }
        public ICommand PlayCommand { get; }
        public ICommand SelectTabCommand { get; }

        public MainWindowViewModel()
        {
            OpenUrlCommand = new RelayCommand((url) =>
            {
                if (url is string _url && !string.IsNullOrEmpty(_url))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = _url,
                        UseShellExecute = true
                    });
                }
            });

            CloseWindow = new RelayCommand((_closeWindow) =>
            {
                Application.Current.MainWindow.Close();
            });

            MinimizeWindow = new RelayCommand((_reduceWindow) =>
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            });

            PlayCommand = new RelayCommand((_play) =>
            {
                LoginWindow _loginWindow = new LoginWindow();
                _loginWindow.Show();
                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = _loginWindow;
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            });

            SelectTabCommand = new RelayCommand((_selectTab) =>
            {
                if (_selectTab is string _selected && int.TryParse(_selected, out int _tab))
                {

                }
            });
        }
    }
}
