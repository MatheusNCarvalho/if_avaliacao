using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Domain.Extension;
using IFAVALIACAO.API.Domain.Filters;
using IFAVALIACAO.API.Domain.Repository;
using IFAVALIACAO.API.Models;
using IFAVALIACAO.API.Services.Interfaces;
using IFAVALIACAO.API.Services.Notifications;
using MediatR;

namespace IFAVALIACAO.API.Services
{
    public class VacaService : ServiceBase, IVacaService
    {
        private readonly IFazendaRepository _fazendaRepository;
        private readonly IVacaRepository _vacaRepository;
        private readonly IMapper _mapper;
        public VacaService(IUnitOfWork ofWork, IMediator mediator, INotificationHandler<DomainNotification> notifications, IFazendaRepository fazendaRepository, IVacaRepository vacaRepository, IMapper mapper) : base(ofWork, mediator, notifications)
        {
            _fazendaRepository = fazendaRepository;
            _vacaRepository = vacaRepository;
            _mapper = mapper;
        }

        public IList<VacaModel> SearchItemsToSync(SyncFilter filter)
        {
            return _mapper.Map<IList<VacaModel>>(_vacaRepository.SearchItemsToSync(filter.FirstSync, filter.LastDateStart, "Fazenda"));
        }

        public void Save(VacaModel model)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IList<VacaModel> models)
        {
            var fazendas = _fazendaRepository.GetByInscricoesEstaduais(models.Where(x => x.FazendaInscricaoEstadual.HasValue()).Select(x => x.FazendaInscricaoEstadual).ToList());
            var vacasMaes = _vacaRepository
                .GetByNumeros(models.Where(x => x.NumeroVacaMae.HasValue).Select(x => x.NumeroVacaMae.Value).ToList())
                .ToList();

            var vacasExistente = _vacaRepository
                .GetByNumeros(models.Select(x => x.Numero).ToList())
                .ToList();

            foreach (var vacaModel in models)
            {
                var existeVaca = vacasExistente.FirstOrDefault(x => x.Numero == vacaModel.Numero && x.Fazenda?.InscricaoEstadual == vacaModel.FazendaInscricaoEstadual);
                var fazenda = fazendas.FirstOrDefault(x => x.InscricaoEstadual == vacaModel.FazendaInscricaoEstadual);
                var vacaMae = vacasMaes.FirstOrDefault(x =>
                    x.Numero == vacaModel.NumeroVacaMae &&
                    x.Fazenda?.InscricaoEstadual == vacaModel.FazendaInscricaoEstadual);

                if (existeVaca == null)
                {
                    existeVaca = CreateVaca(vacaModel, fazenda, vacaMae);
                    _vacaRepository.Add(existeVaca);
                    continue;
                }

                if (existeVaca.DataAtualizacao?.Ticks >= vacaModel.DataAtualizacao?.Ticks) continue;
                Update(vacaModel, existeVaca, vacaMae, fazenda);
            }

            Commit();
        }

        public void Update(Guid id, VacaModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        private Vaca CreateVaca(VacaModel model, Fazenda fazenda, Vaca vacaMae)
        {
            var vaca = new Vaca(model.Nome, model.Numero, model.NomePai, model.NumeroPai,
                                model.Raca, model.GrauSanguineo, model.DataNascimento,
                                model.OrdemParto, model.Ipp, fazenda, vacaMae, model.Id);
            vaca.SetDataCriacao(model.DataCriacao);
            vaca.SetDataAtualizacao(model.DataAtualizacao);
            vaca.SetDeletado(model.Deletado);
            return vaca;
        }

        private void Update(VacaModel model, Vaca vaca, Vaca vacaMae, Fazenda fazenda)
        {
            vaca.SetName(model.Nome);
            vaca.SetNumero(model.Numero);
            vaca.SetNomePai(model.NomePai);
            vaca.SetNumeroPai(model.NumeroPai);
            vaca.SetRaca(model.Raca);
            vaca.SetGrauSanguinio(model.GrauSanguineo);
            vaca.SetDataNascimento(model.DataNascimento);
            vaca.SetOrdemParto(model.OrdemParto);
            vaca.SetIpp(model.Ipp);
            vaca.SetDataAtualizacao(model.DataAtualizacao);
            vaca.SetDeletado(model.Deletado);
            vaca.SetFazenda(fazenda);
            vaca.SetVacaMae(vacaMae);
            _vacaRepository.Update(vaca);
        }

    }
}