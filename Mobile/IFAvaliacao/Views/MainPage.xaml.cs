using System.ComponentModel;
using IFAvaliacao.Views;
using Xamarin.Forms;

namespace IFAvaliacao
{
    public partial class MainPage : MasterDetailPage
    {

        public MainPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new PreenchimentoTabPage());
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
