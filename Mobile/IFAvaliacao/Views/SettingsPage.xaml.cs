
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IFAvaliacao.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        //protected override bool OnBackButtonPressed()
        //{
        //    Device.BeginInvokeOnMainThread(async () =>
        //    {
        //        var confirmConfig = new ConfirmConfig()
        //           .SetTitle("Deseja sair do aplicativo?")
        //           .SetOkText("Sim")
        //           .SetCancelText("Não");

        //        var confirmDialog = await Dialogs.Instance.ConfirmAsync(confirmConfig);
        //        if (confirmDialog)
        //        {
        //            var nativeHelper = DependencyService.Get<INativeHelper>();
        //            nativeHelper?.CloseApp();
        //        }
        //    });

        //    return true;
        //}
    }
}