using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Domain.Filters;
using IFAVALIACAO.API.Domain.Interfaces.Authentication;
using IFAVALIACAO.API.Domain.Interfaces.Repository;
using IFAVALIACAO.API.Domain.Interfaces.Services;
using IFAVALIACAO.API.Domain.Notifications;
using IFAVALIACAO.API.Models;
using IFAVALIACAO.API.Resources;
using MediatR;

namespace IFAVALIACAO.API.Domain.Services
{
    public class FazendaService : ServiceBase, IFazendaService
    {
        private readonly IRepository<Fazenda> _repository;
        private readonly IMapper _mapper;
        private readonly IUserSession _userSession;

        public FazendaService(IUnitOfWork ofWork, IMediator mediator, INotificationHandler<DomainNotification> notifications, IRepository<Fazenda> repository, IMapper mapper, IUserSession userSession) : base(ofWork, mediator, notifications)
        {
            _repository = repository;
            _mapper = mapper;
            _userSession = userSession;
        }


        public IList<FazendaModel> SearchItemsToSync(SyncFilter filter)
        {
            return _mapper.Map<IList<FazendaModel>>(_repository.SearchItemsToSync(_userSession.UserId, filter.FirstSync, filter.LastDateStart));
        }

        public void Save(FazendaModel model)
        {
            var existeFazenda = _repository.Get(x => x.UserId == _userSession.UserId && x.InscricaoEstadual == model.InscricaoEstadual).FirstOrDefault();

            if (existeFazenda == null)
            {
                var fazenda = CreateFazenda(model);

                _repository.Add(fazenda);
                Commit();
                return;
            }

            if (!(model.DataAtualizacao > existeFazenda.DataAtualizacao)) return;

            Update(model, existeFazenda);
            Commit();

        }

        public void SaveOrUpdate(IList<FazendaModel> model)
        {
            var inscricoesEstaduais = model.Select(x => x.InscricaoEstadual).ToList();

            var existeFazendas = _repository
                .Get(x => x.UserId == _userSession.UserId 
                          && inscricoesEstaduais.Contains(x.InscricaoEstadual)).ToList();

            foreach (var fazendaModel in model)
            {
                var existeFazenda = existeFazendas.FirstOrDefault(x => x.InscricaoEstadual == fazendaModel.InscricaoEstadual);
                if (existeFazenda == null)
                {
                    var fazenda = CreateFazenda(fazendaModel);
                    _repository.Add(fazenda);
                    continue;
                }

                if (existeFazenda.DataAtualizacao?.Ticks >= fazendaModel.DataAtualizacao?.Ticks) continue;

                Update(fazendaModel, existeFazenda);
            }

            if (model.Count > 0)
                Commit();
        }

        public void Update(Guid id, FazendaModel model)
        {
            var fazenda = _repository.GetById(id);

            if (fazenda == null)
            {
                NotifyValidationError(nameof(DomainError.FazendaNaoEncontrada), DomainError.FazendaNaoEncontrada);
                return;
            }

            if (fazenda.DataAtualizacao > model.DataAtualizacao) return;

            fazenda.SetCidade(model.Cidade);
            fazenda.SetEndereco(model.Endereco);
            fazenda.SetEstado(model.Estado);
            fazenda.SetInscricaoEstadual(model.InscricaoEstadual);
            fazenda.SetNomeFazenda(model.NomeFazenda);
            fazenda.SetNomeProprietario(model.NomeProprietario);
            fazenda.SetDataAtualizacao(model.DataAtualizacao);

            _repository.Update(fazenda);
            Commit();
        }

        public void Delete(Guid id)
        {
            _repository.Remove(id);
            Commit();
        }

        private void Update(FazendaModel model, Fazenda fazenda)
        {
            fazenda.SetCidade(model.Cidade);
            fazenda.SetEndereco(model.Endereco);
            fazenda.SetEstado(model.Estado);
            fazenda.SetInscricaoEstadual(model.InscricaoEstadual);
            fazenda.SetNomeFazenda(model.NomeFazenda);
            fazenda.SetNomeProprietario(model.NomeProprietario);
            fazenda.SetDeletado(model.Deletado);
            fazenda.SetDataAtualizacao(model.DataAtualizacao);

            _repository.Update(fazenda);
        }

        private Fazenda CreateFazenda(FazendaModel model)
        {
            var fazenda = new Fazenda(model.NomeProprietario, model.NomeFazenda, model.InscricaoEstadual, model.Cep,
                model.Endereco, model.Cidade, model.Estado, _userSession.UserId, model.Id);

            fazenda.SetDataCriacao(model.DataCriacao);
            fazenda.SetDataAtualizacao(model.DataAtualizacao);
            fazenda.SetDeletado(model.Deletado);
            return fazenda;
        }


    }
}