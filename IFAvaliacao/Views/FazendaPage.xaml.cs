using IFAvaliacao.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IFAvaliacao.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FazendaPage : ContentPage
    {
        private FazendaViewModel viewModel => (FazendaViewModel)BindingContext;

        public FazendaPage()
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