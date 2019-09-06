using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IFAvaliacao.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroFazendaPage : ContentPage
    {
        public CadastroFazendaPage()
        {
            InitializeComponent();
            Keyboard.Create(KeyboardFlags.CapitalizeCharacter);
        }
    }
}