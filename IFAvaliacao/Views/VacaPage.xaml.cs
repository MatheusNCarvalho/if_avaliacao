using IFAvaliacao.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IFAvaliacao.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VacaPage : ContentPage
    {
        private VacaViewModel viewModel => (VacaViewModel)BindingContext;
        public VacaPage()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            await viewModel.LoadAsync();
            base.OnAppearing();
        }
    }
}