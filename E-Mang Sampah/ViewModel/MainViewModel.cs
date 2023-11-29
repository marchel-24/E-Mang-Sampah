using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        public ICommand ShowPartnerAccountCommand { get; }
        public ICommand ShowUserAccountCommand { get; }

        public MainViewModel()
        {
            ShowMainViewCommand = new ViewModelCommand(ExecuteShowTestView);
            ShowPartnerAccountCommand = new ViewModelCommand(ExecutePartnerAccountView);
            ShowUserAccountCommand = new ViewModelCommand(ExecuteUserAccountView);


            ExecuteShowTestView(null);    

        }

        private void ExecuteShowTestView(object obj) 
        {
            CurrentChildView = new JunkPickModel();
        }

        private void ExecutePartnerAccountView(object obj)
        {
            CurrentChildView = new PartnerAccountModel();
        }

        private void ExecuteUserAccountView(object obj)
        {
            CurrentChildView = new UserAccountViewModel();
        }
        
    }
}
