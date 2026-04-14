using GenshinImpact.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private int _selectedTab;
        public int SelectedTab
        {
            get => _selectedTab;
            set { _selectedTab = value; OnPropertyChanged();}
        }

        public ObservableCollection<NewsItem> CurrentItems { get; set; } = new ObservableCollection<NewsItem>();
        private List<NewsItem> _event = new List<NewsItem>()
        {
            new NewsItem { Title = "Le concours de la rubrique « Talents » de la...", Date = "04/08", Url = @"https://www.hoyolab.com/article/44581900?utm_id=2" },
            new NewsItem { Title = "L'événement web « Dans le sillage des premiers...", Date = "04/08", Url = @"https://act.hoyoverse.com/ys/event/e20260408land-gmdt0n/index.html?game_biz=hk4e_global&hyl_presentation_style=fullscreen&hyl_auth_required=true&hyl_landscape=true&hyl_hide_status_bar=true&utm_source=launcher&utm_medium=news" },
        };
        private List<NewsItem> _annonce = new List<NewsItem>()
        {
            new NewsItem { Title = "Détails de la mise à jour; corrections et...", Date = "04/08", Url = @"https://www.hoyolab.com/article/44546513?utm_source=launcher&utm_medium=notice&utm_id=2" },
            new NewsItem { Title = "Détails de mise à jour de la version Luna VI «...", Date = "04/08", Url = @"https://www.hoyolab.com/article/44539280?utm_source=launcher&utm_medium=notice&utm_id=2" },
        };
        private List<NewsItem> _actualities = new List<NewsItem>()
        {
            new NewsItem { Title = "Aperçu des événe,ents de la version Luna VI «...", Date = "04/06", Url = @"https://www.hoyolab.com/article_pre/22608?utm_source=launcher&utm_medium=news&utm_id=2" },
        };

        private void UpdatesItems(int _tab)
        {
            List<NewsItem> _items = new List<NewsItem>();

            CurrentItems.Clear();
            switch (_tab)
            {
                case 0:
                    _items = _event;
                    break;
                case 1:
                    _items = _annonce;
                    break;
                case 2:
                    _items = _actualities;
                    break;

            }

            foreach (NewsItem item in _items) CurrentItems.Add(item);
        }

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
                    SelectedTab = _tab;
                    UpdatesItems(_tab);
                }
            });


            UpdatesItems(0);
        }
    }
}
