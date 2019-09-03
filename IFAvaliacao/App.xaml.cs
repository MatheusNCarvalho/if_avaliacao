using IFAvaliacao.Data.Repository;
using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Utils.Extensions;
using IFAvaliacao.ViewModels;
using IFAvaliacao.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IFAvaliacao
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer)
            : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            VersionTracking.Track();
            new MobileDatabaseService().GenerateDatabase();
            await NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.DependecyInjection();
            //containerRegistry.Register<IFazendaRepository, FazendaReposiotry>();

            //containerRegistry.RegisterForNavigation<NavigationPage>();
            //containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
            //containerRegistry.RegisterForNavigation<PreenchimentoPage, PreenchimentoViewModel>();
            //containerRegistry.RegisterForNavigation<PreenchimentoTabPage, PreenchimentoTabViewModel>();
            //containerRegistry.RegisterForNavigation<PreenchimentoConcluidosPage, PreenchimentoConcluidosViewModel>();
            //containerRegistry.RegisterForNavigation<AvaliacaoInicioPage, InicioAvaliacaoViewModel>();
            //containerRegistry.RegisterForNavigation<FazendaPage, FazendaViewModel>();
            //containerRegistry.RegisterForNavigation<VacaPage, VacaViewModel>();
            //containerRegistry.RegisterForNavigation<CadastroFazendaPage, CadastroFazendaViewModel>();
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
