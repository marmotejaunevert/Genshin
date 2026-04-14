using GenshinImpact.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GenshinImpact
{
    class MainWindowViewModel : ViewModelBase
    {
        public ICommand OpenUrlCommand { get; }

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
        }
    }
}
