using IFAvaliacao.Data.Repository;
using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Services;
using IFAvaliacao.Services.Interfaces;
using IFAvaliacao.ViewModels;
using IFAvaliacao.Views;
using Prism.Ioc;
using Xamarin.Forms;

namespace IFAvaliacao.Extensions
{
    public static class ContainerRegistryExtension
    {
        public static IContainerRegistry DependecyInjection(this IContainerRegistry container)
        {
       
            container.Register<IFazendaRepository, FazendaReposiotry>();
            container.Register<IVacaRepository, VacaRepository>();
            container.Register<IVacaService, VacaService>();
            container.Register<IAvaliacaoRepository, AvaliacaoRepository>();
            container.Register<IMobileTableSchemaRepository, MobileTableSchemaRepository>();
            container.Register<IUserService, UserService>();
            container.Register<IFazendaService, FazendaService>();
            container.Register<ISyncService, SyncService>();

            container.RegisterForNavigation<NavigationPage>();
            container.RegisterForNavigation<MainPage, MainViewModel>();
            container.RegisterForNavigation<PreenchimentoPage, PreenchimentoViewModel>();
            container.RegisterForNavigation<PreenchimentoTabPage, PreenchimentoTabViewModel>();
            container.RegisterForNavigation<PreenchimentoConcluidosPage, PreenchimentoConcluidosViewModel>();
            container.RegisterForNavigation<AvaliacaoInicioPage, InicioAvaliacaoViewModel>();
            container.RegisterForNavigation<FazendaPage, FazendaViewModel>();
            container.RegisterForNavigation<VacaPage, VacaViewModel>();
            container.RegisterForNavigation<CadastroFazendaPage, CadastroFazendaViewModel>();
            container.RegisterForNavigation<CadastroVacaPage, CadastroVacaViewModel>();
            container.RegisterForNavigation<LoginPage, LoginViewModel>();
            container.RegisterForNavigation<CadastroUsuarioPage, CadastroUsuarioVieModel>();

            return container;
        }
    }
}
