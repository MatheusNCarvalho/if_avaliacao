﻿using System.Collections.Generic;
using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Domain.Repository;
using IFAVALIACAO.API.Models;
using IFAVALIACAO.API.Services.Interfaces;
using IFAVALIACAO.API.Services.Notifications;
using MediatR;

namespace IFAVALIACAO.API.Services
{
    public class AvaliacaoService : ServiceBase, IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoService(IUnitOfWork ofWork, IMediator mediator, INotificationHandler<DomainNotification> notifications, IAvaliacaoRepository avaliacaoRepository) : base(ofWork, mediator, notifications)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        public void Save(IList<AvaliacaoModel> model)
        {
            foreach (var avaliacaoModel in model)
            {
                var avaliacao = new Avaliacao(avaliacaoModel.DataHoraInicio,
                    avaliacaoModel.DataHoraFim,
                    avaliacaoModel.NameCow,
                    avaliacaoModel.BodyWight,
                    avaliacaoModel.Angulosiodade,
                    avaliacaoModel.ProfundidadeCorporal,
                    avaliacaoModel.ForcaLeiteira,
                    avaliacaoModel.AlturaGarupaHipometro,
                    avaliacaoModel.ComprimentoCorpo,
                    avaliacaoModel.AnguloCarupa,
                    avaliacaoModel.LarguraIleo,
                    avaliacaoModel.LarguraIsquio,
                    avaliacaoModel.AnguloCasco,
                    avaliacaoModel.JarreteLateral,
                    avaliacaoModel.JarreteTras,
                    avaliacaoModel.UbereFirmeza,
                    avaliacaoModel.UberePosterior,
                    avaliacaoModel.AlturaUbere,
                    avaliacaoModel.LigamentoCentral,
                    avaliacaoModel.PosicaoTetos);
                _avaliacaoRepository.Add(avaliacao);
            }

            Commit();
        }
    }
}