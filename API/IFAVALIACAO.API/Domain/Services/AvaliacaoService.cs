using System.Collections.Generic;
using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Domain.Interfaces.Repository;
using IFAVALIACAO.API.Domain.Interfaces.Services;
using IFAVALIACAO.API.Domain.Notifications;
using IFAVALIACAO.API.Models;
using MediatR;

namespace IFAVALIACAO.API.Domain.Services
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