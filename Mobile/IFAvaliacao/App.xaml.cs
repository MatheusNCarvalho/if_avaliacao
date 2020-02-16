using IFAvaliacao.Data.Repository;
using IFAvaliacao.Extensions;
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
            InitializeNavigation();
        }

        private void InitializeNavigation()
        {
            if (AppSettings.Usuario == null)
            {
                //await NavigationService.NavigateAsync("/NavigationPage/LoginPage");
                MainPage = new NavigationPage(new LoginPage());
                return;
            }
            MainPage = new NavigationPage(new MainPage());
            //await NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.DependecyInjection();
        }


        protected override void OnStart()
        {
            new MobileDatabaseService().GenerateDatabase();
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
