using MediatR;
using Microsoft.EntityFrameworkCore;
using Pagamentos.Application.ViewModels;
using Pagamentos.Core.Repositories;
using Pagamentos.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pagamentos.Application.Queries.GetPrestadorById
{
    public class GetPrestadorByIdQueryHandler : IRequestHandler<GetPrestadorByIdQuery, PrestadoresDetailsViewModel>
    {
        private readonly IPrestadorRepository _prestadorRepository;
        public GetPrestadorByIdQueryHandler(IPrestadorRepository prestadorRepository)
        {
            _prestadorRepository = prestadorRepository;
        }

        public async Task<PrestadoresDetailsViewModel> Handle(GetPrestadorByIdQuery request, CancellationToken cancellationToken)
        {
            var prestador = await _prestadorRepository.GetDetailsByIdAsync(request.Id);

            if (prestador == null) return null;
            var servicosDetails = new List<ServicosDetailsViewModel>();

            foreach(var servicos in prestador.Servicos)
            {
                ServicosDetailsViewModel servico = new ServicosDetailsViewModel(servicos.Id, servicos.Servico, servicos.Valor, servicos.IdPrestador);

                servicosDetails.Add(servico);
            }

            var prestadorDetailsViewModel = new PrestadoresDetailsViewModel(
                prestador.Id,
                prestador.Apelido,
                prestador.Nome,
                prestador.CNPJ,
                prestador.Endereco,
                prestador.Numero,
                prestador.Complemento,
                prestador.Bairro,
                prestador.Cidade,
                prestador.Estado,
                prestador.CEP,
                prestador.Telefone,
                prestador.Celular,
                prestador.Email,
                prestador.Categoria,
                prestador.TipoPag,
                prestador.TipoDoc,
                prestador.Banco,
                prestador.Agencia,
                prestador.Conta,
                prestador.TipoPix,
                prestador.Pix,
                prestador.Favorecido,
                prestador.CPF,
                prestador.Ativo,
                servicosDetails
                );

            return prestadorDetailsViewModel;
        }
    }
}
