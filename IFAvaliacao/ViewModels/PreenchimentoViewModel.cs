using System.Windows.Input;
using IFAvaliacao.Domain.Entities;
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
        }

        public ICommand TapCommand { get => _tapCommand; }

        private double _angulosidade;
        public double Angulosiodade
        {
            get => _angulosidade;
            set => SetProperty(ref _angulosidade, value);
        }

        private double _profundidadeCorporal;
        public double ProfundidadeCorporal
        {
            get => _profundidadeCorporal;
            set => SetProperty(ref _profundidadeCorporal, value);
        }

        private double _forcaLeiteira;
        public double ForcaLeiteira
        {
            get => _forcaLeiteira;
            set => SetProperty(ref _forcaLeiteira, value);
        }

        private double _alturaGarupaHipometro;
        public double AlturaGarupaHipometro
        {
            get => _alturaGarupaHipometro;
            set => SetProperty(ref _alturaGarupaHipometro, value);
        }
        private double _comprimentoCorpo;
        public double ComprimentoCorpo { get => _comprimentoCorpo; set => SetProperty(ref _comprimentoCorpo, value); }

        private double _anguloCarupa;
        public double AnguloCarupa { get => _anguloCarupa; set => SetProperty(ref _anguloCarupa, value); }

        private double _larguraIleo;
        public double LarguraIleo { get => _larguraIleo; set => SetProperty(ref _larguraIleo, value); }

        private double _larguraIsquio;
        public double LarguraIsquio { get => _larguraIsquio; set => SetProperty(ref _larguraIsquio, value); }

        private double _anguloCasco;
        public double AnguloCasco { get => _anguloCasco; set => SetProperty(ref _anguloCasco, value); }

        private double _jarreteLateral;
        public double JarreteLateral { get => _jarreteLateral; set => SetProperty(ref _jarreteLateral,value); }

        private double _jarreteTras;
        public double JarreteTras { get => _jarreteTras; set => SetProperty(ref _jarreteTras, value); }

        private double _ubereFirmeza;
        public double UbereFirmeza { get => _ubereFirmeza; set => SetProperty(ref _ubereFirmeza,value); }

        private double _uberePosterior;
        public double UberePosterior { get => _uberePosterior; set => SetProperty(ref _uberePosterior, value); }

        private double _alturaUltere;
        public double AlturaUbere { get => _alturaUltere; set => SetProperty(ref _alturaUltere, value); }

        private double _ligamentoCentral;
        public double LigamentoCentral { get => _ligamentoCentral; set => SetProperty(ref _ligamentoCentral,value); }

        private double _posicaoTetos;
        public double PosicaoTetos { get => _posicaoTetos; set => SetProperty(ref _posicaoTetos, value); }
                         

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
                case nameof(ProfundidadeCorporal):
                    ProfundidadeCorporal = double.Parse(value[1]);
                    break;
                case nameof(ForcaLeiteira):
                    ForcaLeiteira = double.Parse(value[1]);
                    break;
                case nameof(AnguloCarupa):
                    AnguloCarupa = double.Parse(value[1]);
                    break;
                case nameof(AnguloCasco):
                    AnguloCasco = double.Parse(value[1]);
                    break;
                case nameof(JarreteLateral):
                    JarreteLateral = double.Parse(value[1]);
                    break;
                case nameof(JarreteTras):
                    JarreteTras = double.Parse(value[1]);
                    break;
                case nameof(UbereFirmeza):
                    UbereFirmeza = double.Parse(value[1]);
                    break;
                case nameof(UberePosterior):
                    UberePosterior = double.Parse(value[1]);
                    break;
                case nameof(AlturaUbere):
                    AlturaUbere = double.Parse(value[1]);
                    break;
                case nameof(LigamentoCentral):
                    LigamentoCentral = double.Parse(value[1]);
                    break;
                case nameof(PosicaoTetos):
                    PosicaoTetos = double.Parse(value[1]);
                    break;
            }
        }
    }
}