using System;
using System.Collections.Generic;
using System.Linq;
using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Domain.Repository;
using IFAVALIACAO.API.Models;
using IFAVALIACAO.API.Resources;
using IFAVALIACAO.API.Services.Interfaces;
using IFAVALIACAO.API.Services.Notifications;
using MediatR;

namespace IFAVALIACAO.API.Services
{
    public class FazendaService : ServiceBase, IFazendaService
    {
        private readonly IRepository<Fazenda> _repository;
        public FazendaService(IUnitOfWork ofWork, IMediator mediator, INotificationHandler<DomainNotification> notifications, IRepository<Fazenda> repository) : base(ofWork, mediator, notifications)
        {
            _repository = repository;
        }


        public void Save(FazendaModel model)
        {
            var existeFazenda = _repository.Get(x => x.InscricaoEstadual == model.InscricaoEstadual).FirstOrDefault();

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
                .Get(x => inscricoesEstaduais.Contains(x.InscricaoEstadual)).ToList();

            foreach (var fazendaModel in model)
            {
                var existeFazenda = existeFazendas.FirstOrDefault(x => x.InscricaoEstadual == fazendaModel.InscricaoEstadual);
                if (existeFazenda == null)
                {
                    var fazenda = CreateFazenda(fazendaModel);
                    _repository.Add(fazenda);
                    continue;
                }

                if (existeFazenda.DataAtualizacao > fazendaModel.DataAtualizacao) continue;

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

            _repository.Update(fazenda);
        }

        private Fazenda CreateFazenda(FazendaModel model)
        {
            var fazenda = new Fazenda(model.NomeProprietario, model.NomeFazenda, model.InscricaoEstadual, model.Cep,
                model.Endereco, model.Cidade, model.Estado, model.Id);

            fazenda.SetDataCriacao(model.DataCriacao);
            fazenda.SetDataAtualizacao(model.DataAtualizacao);
            return fazenda;
        }


    }
}