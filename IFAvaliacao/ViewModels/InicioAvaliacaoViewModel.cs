using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Services.Interfaces;
using IFAvaliacao.Views;
using Prism.Commands;
using Prism.Navigation;

namespace IFAvaliacao.ViewModels
{
    public class InicioAvaliacaoViewModel : ViewModelBase, IAsyncInitialization
    {
        public Task Initialization { get; }
        public DelegateCommand StartCommand { get; set; }
        private readonly IVacaService _vacaService;

        public InicioAvaliacaoViewModel(INavigationService navigationService, IVacaService vacaService) : base(navigationService)
        {
            Title = "Iniciar";
            _vacaService = vacaService;
            StartCommand = new DelegateCommand(async () => await LoadNavigation());
            Initialization = LoadSync();
        }

        private int _nameCow;

        public int NameCow
        {
            get => _nameCow;
            set => SetProperty(ref _nameCow, value);
        }

        private decimal _bodyWight;
        public decimal BodyWight
        {
            get => _bodyWight;
            set => SetProperty(ref _bodyWight, value);
        }

        private Vaca _vacaSelecionada;
        public Vaca VacaSelecionada { get => _vacaSelecionada; set => SetProperty(ref _vacaSelecionada, value); }

        private ObservableCollection<Vaca> _vacas;
        public ObservableCollection<Vaca> Vacas { get => _vacas; set => SetProperty(ref _vacas, value); }

        public async Task LoadSync()
        {
            var vacas = await _vacaService.GetAllAsync();
            Vacas = new ObservableCollection<Vaca>(vacas);
        }

        private async Task LoadNavigation()
        {
            try
            {
                DialogService.ShowLoading("Aguarde, realizando configuração...");
                if (VacaSelecionada == null)
                {
                    DialogService.HideLoading();
                    await DialogService.AlertAsync("É obrigatorio selecionar Vaca.", "Ops", "Ok");
                    return;
                }

                var parameters = new NavigationParameters { { nameof(AvaliacaoVaca), new AvaliacaoVaca(VacaSelecionada.Numero, BodyWight) } };
                await NavigateToPage(nameof(PreenchimentoPage), parameters);
                NameCow = 0;
                BodyWight = 0;
                VacaSelecionada = null;
            }
            catch (Exception e)
            {
                DialogService.HideLoading();                
                ToastError(e.Message);
            }
            finally
            {
                DialogService.HideLoading();
            }
        }

        public async Task NavigateToPage(string page, NavigationParameters parameters)
        {
            await NavigationService.NavigateAsync(page, parameters);
        }
    }
}
