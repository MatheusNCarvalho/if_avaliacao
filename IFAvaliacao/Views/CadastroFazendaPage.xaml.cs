using IFAvaliacao.Utils.Extensions;
using IFAvaliacao.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IFAvaliacao.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroFazendaPage : ContentPage
    {
        private CadastroFazendaViewModel viewModel => (CadastroFazendaViewModel)BindingContext;
        public CadastroFazendaPage()
        {
            InitializeComponent();
        }

        private async void Entry_Completed(object sender, System.EventArgs e)
        {
            if (!viewModel.Cep.HasValue())
            {
                return;
            }
            if (viewModel.Cep.Length < 9)
            {
                await viewModel.UserDialogService().AlertAsync("Cep inválido", "Opss..", "OK");
                return;
            }
            var result = await viewModel.ExecuteFinZipCodeCommand();
            if (result)
            {
                viewModel.Liberar = true;
            }

        }
    }
}