﻿using IFAvaliacao.Data.Repository;
using IFAvaliacao.Utils.Extensions;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Essentials;

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
