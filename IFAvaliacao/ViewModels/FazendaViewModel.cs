using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;
using Prism.Services;

namespace IFAvaliacao.ViewModels
{
    public class FazendaViewModel : ViewModelBase
    {
        public FazendaViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
        }
    }
}
