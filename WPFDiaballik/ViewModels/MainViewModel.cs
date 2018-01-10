using System.Windows.Input;
using WPFDiaballik.Utilities;

namespace WPFDiaballik.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The current view to display.
        /// </summary>
        private ViewModelBase currentView;
        public ViewModelBase CurrentView
        {
            get
            {
                return currentView;
            }
            set
            {
                currentView = value;
                RaisePropertyChanged("CurrentView");
            }
        }

        public MainViewModel()
        {
            CurrentView = new HomeViewModel();
        }

        /// <summary>
        /// Command to display the game creation page.
        /// </summary>
        private ICommand newGameCommand;
        public ICommand NewGameCommand
        {
            get
            {
                if (newGameCommand == null) newGameCommand = new ButtonCommand<object>(ViewNewGameAction);
                return newGameCommand;
            }
        }
        private void ViewNewGameAction(object param)
        {
            CurrentView = new NewGameViewModel();
        }

    }
}
