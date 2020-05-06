using System;
using System.Windows.Input;
using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Extensions;
using Prism.Navigation;
using Xamarin.Forms;

namespace IFAvaliacao.ViewModels
{
    public class PreenchimentoViewModel : ViewModelBase
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        public PreenchimentoViewModel(INavigationService navigationService, IAvaliacaoRepository avaliacaoRepository) : base(navigationService)
        {
            _avaliacaoRepository = avaliacaoRepository;
            TapCommand = new Command(OnTapped);
            SaveCommand = new Command(ExecuteSaveCommand);
            SliderMinimum = 1.0;
            DataHoraInicio = DateTime.Now;
        }

        public ICommand TapCommand { get; }
        public ICommand SaveCommand { get; }

        public DateTime DataHoraInicio { get; set; }

        private bool _podeSalvar = true;
        public bool PodeSalvar { get => _podeSalvar; set => SetProperty(ref _podeSalvar, value); }

        private double _angulosidade;
        public double Angulosiodade { get => _angulosidade; set => SetProperty(ref _angulosidade, value); }

        private double _profundidadeCorporal;
        public double ProfundidadeCorporal { get => _profundidadeCorporal; set => SetProperty(ref _profundidadeCorporal, value); }

        private double _forcaLeiteira;
        public double ForcaLeiteira { get => _forcaLeiteira; set => SetProperty(ref _forcaLeiteira, value); }

        private double _alturaGarupaHipometro;
        public double AlturaGarupaHipometro { get => _alturaGarupaHipometro; set => SetProperty(ref _alturaGarupaHipometro, value); }
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
        public double JarreteLateral { get => _jarreteLateral; set => SetProperty(ref _jarreteLateral, value); }

        private double _jarreteTras;
        public double JarreteTras { get => _jarreteTras; set => SetProperty(ref _jarreteTras, value); }

        private double _ubereFirmeza;
        public double UbereFirmeza { get => _ubereFirmeza; set => SetProperty(ref _ubereFirmeza, value); }

        private double _uberePosterior;
        public double UberePosterior { get => _uberePosterior; set => SetProperty(ref _uberePosterior, value); }

        private double _alturaUltere;
        public double AlturaUbere { get => _alturaUltere; set => SetProperty(ref _alturaUltere, value); }

        private double _ligamentoCentral;
        public double LigamentoCentral { get => _ligamentoCentral; set => SetProperty(ref _ligamentoCentral, value); }

        private double _posicaoTetos;
        public double PosicaoTetos { get => _posicaoTetos; set => SetProperty(ref _posicaoTetos, value); }

        private decimal _comprimentoTeto1;
        public decimal ComprimentoTeto1 { get => _comprimentoTeto1; set => SetProperty(ref _comprimentoTeto1, value); }

        private decimal _comprimentoTeto2;
        public decimal ComprimentoTeto2 { get => _comprimentoTeto2; set => SetProperty(ref _comprimentoTeto2, value); }

        private decimal _comprimentoTeto3;
        public decimal ComprimentoTeto3 { get => _comprimentoTeto3; set => SetProperty(ref _comprimentoTeto3, value); }

        private decimal _comprimentoTeto4;
        public decimal ComprimentoTeto4 { get => _comprimentoTeto4; set => SetProperty(ref _comprimentoTeto4, value); }

        private decimal _diametroTeto1;
        public decimal DiametroTeto1 { get => _diametroTeto1; set => SetProperty(ref _diametroTeto1, value); }

        private decimal _diametroTeto2;
        public decimal DiametroTeto2 { get => _diametroTeto2; set => SetProperty(ref _diametroTeto2, value); }

        private decimal _diametroTeto3;
        public decimal DiametroTeto3 { get => _diametroTeto3; set => SetProperty(ref _diametroTeto3, value); }

        private decimal _diametroTeto4;
        public decimal DiametroTeto4 { get => _diametroTeto4; set => SetProperty(ref _diametroTeto4, value); }

        private int _nameCow;
        public int NameCow { get => _nameCow; set => SetProperty(ref _nameCow, value); }

        private decimal _bodyWight;
        public decimal BodyWight { get => _bodyWight; set => SetProperty(ref _bodyWight, value); }

        public double SliderMinimum { get; set; }
        public double SliderMaximum { get; set; }


        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                var profileCow = (AvaliacaoVaca)parameters[nameof(AvaliacaoVaca)];

                if (profileCow == null)
                {
                    await NavigationService.GoBackAsync();
                    return;
                }

                BodyWight = profileCow.BodyWight;
                NameCow = profileCow.NameCow;

                if (profileCow.Id.HasValue())
                {
                    Loading(profileCow);
                }
            }
            catch (Exception ex)
            {
                ToastError(ex.Message);
            }
        }

        private async void ExecuteSaveCommand()
        {
            try
            {
                var avaliacao = new AvaliacaoVaca(NameCow, BodyWight, Angulosiodade.DoubleToInt(), ProfundidadeCorporal.DoubleToInt(), ForcaLeiteira.DoubleToInt(),
                                                  AlturaGarupaHipometro.DoubleToInt(), ComprimentoCorpo.DoubleToInt(), AnguloCarupa.DoubleToInt(),
                                                  LarguraIleo.DoubleToInt(), LarguraIsquio.DoubleToInt(), AnguloCasco.DoubleToInt(),
                                                  JarreteLateral.DoubleToInt(), JarreteTras.DoubleToInt(), UbereFirmeza.DoubleToInt(),
                                                  UberePosterior.DoubleToInt(), AlturaUbere.DoubleToInt(), LigamentoCentral.DoubleToInt(),
                                                  PosicaoTetos.DoubleToInt(), DataHoraInicio, ComprimentoTeto1, ComprimentoTeto2,
                                                  ComprimentoTeto3, ComprimentoTeto4, DiametroTeto1, DiametroTeto2,
                                                  DiametroTeto3, DiametroTeto4)
                {
                    DataHoraFim = DateTime.Now
                };

                if (await _avaliacaoRepository.AddAsync(avaliacao))
                {
                    ToastSuccess("Avaliação adicionada com sucesso!");
                    await NavigationService.GoBackToRootAsync();
                    return;
                }

                ToastError("Ocorreu um erro ao salvar avaliação, Tente novamente!");

            }
            catch (Exception ex)
            {
                ToastError(ex.Message);
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

        private void Loading(AvaliacaoVaca profileCow)
        {
            Angulosiodade = profileCow.Angulosiodade;
            ProfundidadeCorporal = profileCow.ProfundidadeCorporal;
            ForcaLeiteira = profileCow.ForcaLeiteira;
            AlturaGarupaHipometro = profileCow.AlturaGarupaHipometro;
            ComprimentoCorpo = profileCow.ComprimentoCorpo;
            AnguloCarupa = profileCow.AnguloCarupa;
            LarguraIleo = profileCow.LarguraIleo;
            LarguraIsquio = profileCow.LarguraIsquio;
            AnguloCasco = profileCow.AnguloCasco;
            JarreteLateral = profileCow.JarreteLateral;
            JarreteTras = profileCow.JarreteTras;
            UbereFirmeza = profileCow.UbereFirmeza;
            UberePosterior = profileCow.UberePosterior;
            AlturaUbere = profileCow.AlturaUbere;
            LigamentoCentral = profileCow.LigamentoCentral;
            PosicaoTetos = profileCow.PosicaoTetos;
            ComprimentoTeto1 = profileCow.ComprimentoTeto1;
            ComprimentoTeto2 = profileCow.ComprimentoTeto2;
            ComprimentoTeto3 = profileCow.ComprimentoTeto3;
            ComprimentoTeto4 = profileCow.ComprimentoTeto4;
            DiametroTeto1 = profileCow.DiametroTeto1;
            DiametroTeto2 = profileCow.DiametroTeto2;
            DiametroTeto3 = profileCow.DiametroTeto3;
            DiametroTeto4 = profileCow.DiametroTeto4;
            PodeSalvar = false;
        }
    }
}