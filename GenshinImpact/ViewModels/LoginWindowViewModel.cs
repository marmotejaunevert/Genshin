using GenshinImpact.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GenshinImpact
{
    public class LoginWindowViewModel : ViewModelBase
    {
        bool isGridVisible = true; 
        public bool IsGridVisible 
        {
            get => isGridVisible;
            set
            {
                isGridVisible = value;
                OnPropertyChanged(nameof(IsGridVisible));
            }
        }
        bool isLoadingVisible = false; 
        public bool IsLoadingVisible
        {
            get => isLoadingVisible;
            set
            {
                isLoadingVisible = value;
                OnPropertyChanged(nameof(isLoadingVisible));
            }
        }


        public ICommand ChangeLoadingScreen{ get; }

        public LoginWindowViewModel() 
        {
            ChangeLoadingScreen = new RelayCommand((_) =>
            {
                HideGridContent();
                LoadingScreen();
            });
        }

        void HideGridContent()
        {
            IsGridVisible = false;

        }
        void LoadingScreen()
        {
            IsLoadingVisible = true;

        }
    }
}
