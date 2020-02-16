using Plugin.Connectivity;
using System;
using Xamarin.Forms;

namespace IFAvaliacao.Utils
{
    public static class Help
    {
        public static bool IsConnected => CrossConnectivity.Current.IsConnected;

        public static void SetNavigationPageRoot(Type page)
        {
            Application.Current.MainPage = new NavigationPage((Page)Activator.CreateInstance(page));
        }

    }
}
