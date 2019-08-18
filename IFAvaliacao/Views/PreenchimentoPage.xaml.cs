using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IFAvaliacao.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreenchimentoPage : ContentPage
    {
        public PreenchimentoPage()
        {
            InitializeComponent();
        }

        private void Slider_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue > 0)
            {
                var newValue = (int)e.NewValue;
                lbValue.Text = newValue.ToString();
            }

        }
    }
}