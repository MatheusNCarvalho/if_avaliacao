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
        
    }
}
