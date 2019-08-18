using System;
using System.ComponentModel;
using IFAvaliacao.ViewModels;
using Xamarin.Forms;

namespace IFAvaliacao
{
   
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private MainViewModel MainViewModel => (MainViewModel)BindingContext;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            entryBodyWight.Completed += Entry_NameCowCompleted;
            entryNameCow.Completed += Entry_NameCowCompleted;
            btnStart.IsEnabled = false;
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            entryBodyWight.Completed -= Entry_NameCowCompleted;
            entryNameCow.Completed -= Entry_NameCowCompleted;
            base.OnDisappearing();
        }

        private void Entry_NameCowCompleted(object sender, EventArgs e)
        {
            if (MainViewModel.BodyWight > 0 && MainViewModel.NameCow > 0)
            {
                btnStart.IsEnabled = true;
            }
        }
    }
}
