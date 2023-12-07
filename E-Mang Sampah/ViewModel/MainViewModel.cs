using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using E_Mang_Sampah.Model;
using E_Mang_Sampah.Services.Session;

namespace E_Mang_Sampah.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        private ViewModelBase _currentChildView;

        public ViewModelBase CurrentChildView
        { 
            get 
            { 
                return _currentChildView; 
            } 
            set 
            { 
                _currentChildView = value; 
                OnPropertyChanged(nameof(CurrentChildView));
            } 
        }

        public ICommand ShowMainViewCommand { get; }
        public ICommand ShowAccountCommand { get; }
        public ICommand ShowJunkPickCommand { get; }


        public MainViewModel()
        {
            ShowMainViewCommand = new ViewModelCommand(ExecuteShowTestView);
            ShowAccountCommand = new ViewModelCommand(ExecuteAccountView);
            ShowJunkPickCommand = new ViewModelCommand(ExecuteJunkPickView);


            ExecuteShowTestView(null);    

        }

        private void ExecuteShowTestView(object obj) 
        {
            CurrentChildView = new WelcomeViewModel();
        }

        private void ExecuteAccountView(object obj)
        {
            if (SessionData.CurrentAccount is PartnerAccount)
            {
               CurrentChildView = new PartnerAccountModel();
            }
            else if (SessionData.CurrentAccount is UserAccount)
            {
               CurrentChildView = new UserAccountViewModel();
            }
        }
        
        private void ExecuteJunkPickView(object obj)
        {
            if (SessionData.CurrentAccount is PartnerAccount)
            {
                CurrentChildView = new JunkPickPartnerModel();
            }
            else if (SessionData.CurrentAccount is UserAccount)
            {    
                CurrentChildView = new JunkPickUserModel();
            }
        }
    }
}
