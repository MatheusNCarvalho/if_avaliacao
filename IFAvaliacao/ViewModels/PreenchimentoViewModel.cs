using System.Collections.ObjectModel;
using System.Windows.Input;
using IFAvaliacao.Models;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace IFAvaliacao.ViewModels
{
    public class PreenchimentoViewModel : ViewModelBase
    {
        private readonly ICommand _tapCommand;
        public PreenchimentoViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            _tapCommand = new Command(OnTapped);
            SliderMinimum = 1.0;
            SliderMaximum = 9.0;
            Perguntas = new ObservableCollection<Perguntas>();
        }



        private ObservableCollection<Perguntas> _perguntas;
        public ObservableCollection<Perguntas> Perguntas
        {
            get => _perguntas;
            set => SetProperty(ref _perguntas, value);
        }

        public ICommand TapCommand { get => _tapCommand; }

        private double _angulosidade;
        public double Angulosiodade
        {
            get => _angulosidade;
            set => SetProperty(ref _angulosidade, value);
        }

        private int _nameCow;

        public int NameCow
        {
            get => _nameCow;
            set => SetProperty(ref _nameCow, value);
        }

        private decimal _bodyWight;
        public decimal BodyWight
        {
            get => _bodyWight;
            set => SetProperty(ref _bodyWight, value);
        }

        public double SliderMinimum { get; set; }
        public double SliderMaximum { get; set; }


        public void LoadPerguntas()
        {
            Perguntas.Add(new Perguntas("Angulosidade", "Sem angulosidade", "Intermediário",
                "angulosa e descarnada"));

            Perguntas.Add(new Perguntas("Profundidade Corporal", "raso", "Intermediário",
                "profundo"));
        }



        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var profileCow = (ProfileCow)parameters[nameof(ProfileCow)];

            if (profileCow != null)
            {
                BodyWight = profileCow.BodyWight;
                NameCow = profileCow.NameCow;
            }
        }

        private void OnTapped(object type)
        {
            var value = type.ToString().Split('.');

            switch (value[0])
            {
                case nameof(Angulosiodade):
                    Angulosiodade = double.Parse(value[1]);
                    break;
            }

        }

    }
}