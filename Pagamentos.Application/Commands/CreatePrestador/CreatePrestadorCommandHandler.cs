using MediatR;
using Pagamentos.Core.Entities;
using Pagamentos.Core.Repositories;
using Pagamentos.Infrastructure.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pagamentos.Application.Commands.CreatePrestador
{
    public class CreatePrestadorCommandHandler : IRequestHandler<CreatePrestadorCommand, int>
    {
        private readonly IPrestadorRepository _prestadorRepository;
        public CreatePrestadorCommandHandler(IPrestadorRepository prestadorRepository)
        {
            _prestadorRepository = prestadorRepository;
        }

        public async Task<int> Handle(CreatePrestadorCommand request, CancellationToken cancellationToken)
        {
            var prestador = new Prestadores(request.Apelido, request.Nome, request.CNPJ, request.Endereco, request.Numero,
                                            request.Complemento, request.Bairro, request.Cidade, request.Estado, request.CEP,
                                            request.Telefone, request.Celular, request.Email, request.Categoria, request.TipoPag,
                                            request.TipoDoc, request.Banco, request.Agencia, request.Conta, request.TipoPix, request.Pix,
                                            request.Favorecido, request.CPF);

            await _prestadorRepository.AddAsync(prestador);

            return prestador.Id;
        }
    }
}
