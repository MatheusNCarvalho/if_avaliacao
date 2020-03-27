using IFAvaliacao.Data.Repository;
using IFAvaliacao.Extensions;
using IFAvaliacao.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IFAvaliacao
{
    public partial class App : PrismApplication
    {
        const string LogTag = "AppCenterBullApp";
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
            StartAppCenter();
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


        [Conditional("RELEASE")]
        public void StartAppCenter()
        {
            AppCenter.LogLevel = LogLevel.Verbose;
            AppCenter.Start($@"android={AppSettings.AppCenterAndroid}", typeof(Distribute), typeof(Analytics), typeof(Crashes));


            AppCenter.GetInstallIdAsync().ContinueWith(installId =>
            {
                AppCenterLog.Info(LogTag, "AppCenter.InstallId=" + installId.Result);
            });
            Crashes.HasCrashedInLastSessionAsync().ContinueWith(hasCrashed =>
            {
                AppCenterLog.Info(LogTag, "Crashes.HasCrashedInLastSession=" + hasCrashed.Result);
            });
            Crashes.GetLastSessionCrashReportAsync().ContinueWith(report =>
            {
                AppCenterLog.Info(LogTag, "Crashes.LastSessionCrashReport.Exception=" + report.Result?.Exception);
            });
        }
    }
}
