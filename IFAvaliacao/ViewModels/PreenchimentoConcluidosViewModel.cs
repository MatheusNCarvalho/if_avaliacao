﻿using Prism.Navigation;
using Prism.Services;

namespace IFAvaliacao.ViewModels
{
    public class PreenchimentoConcluidosViewModel : ViewModelBase
    {
        protected PreenchimentoConcluidosViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
        }
    }
}