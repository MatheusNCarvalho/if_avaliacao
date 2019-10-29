using IFAvaliacao.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IFAvaliacao.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreenchimentoConcluidosPage : ContentPage
    {
        private PreenchimentoConcluidosViewModel viewModel => (PreenchimentoConcluidosViewModel)BindingContext;

        public PreenchimentoConcluidosPage()
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