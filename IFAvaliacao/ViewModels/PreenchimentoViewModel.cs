using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace IFAvaliacao.ViewModels
{
    public class PreenchimentoViewModel : ViewModelBase
    {
        private ICommand _tapCommand;
        public PreenchimentoViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            _tapCommand = new Command(OnTapped);
            SliderMinimum = 1.0;
            SliderMaximum = 9.0;
        }


        public ICommand TapCommand { get => _tapCommand; }

        private double _angulosidade;
        public double Angulosiodade
        {
            get => _angulosidade;
            set
            {
                SetProperty(ref _angulosidade, value);
            }
        }

        public double SliderMinimum { get; set; }
        public double SliderMaximum { get; set; }

        private void OnTapped(object type)
        {
            var value = type.ToString().Split('.');
            switch ((string)value[0])
            {
                case nameof(Angulosiodade):
                    Angulosiodade = double.Parse(value[1]);
                    break;
            }

        }

    }
}