using IFAvaliacao.Data.Repository;
using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.ViewModels;
using IFAvaliacao.Views;
using Prism.Ioc;
using Xamarin.Forms;

namespace IFAvaliacao.Utils.Extensions
{
    public static class ContainerRegistryExtension
    {
        public static IContainerRegistry DependecyInjection(this IContainerRegistry container)
        {
            container.Register<IFazendaRepository, FazendaReposiotry>();

            container.RegisterForNavigation<NavigationPage>();
            container.RegisterForNavigation<MainPage, MainViewModel>();
            container.RegisterForNavigation<PreenchimentoPage, PreenchimentoViewModel>();
            container.RegisterForNavigation<PreenchimentoTabPage, PreenchimentoTabViewModel>();
            container.RegisterForNavigation<PreenchimentoConcluidosPage, PreenchimentoConcluidosViewModel>();
            container.RegisterForNavigation<AvaliacaoInicioPage, InicioAvaliacaoViewModel>();
            container.RegisterForNavigation<FazendaPage, FazendaViewModel>();
            container.RegisterForNavigation<VacaPage, VacaViewModel>();
            container.RegisterForNavigation<CadastroFazendaPage, CadastroFazendaViewModel>();

            return container;
        }
    }
}
