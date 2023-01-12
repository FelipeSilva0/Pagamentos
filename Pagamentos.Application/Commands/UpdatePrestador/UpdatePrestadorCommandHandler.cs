using MediatR;
using Pagamentos.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Pagamentos.Application.Commands.UpdatePrestador
{
    public class UpdatePrestadorCommandHandler : IRequestHandler<UpdatePrestadorCommand, Unit>
    {
        private readonly IPrestadorRepository _prestadorRepository;
        public UpdatePrestadorCommandHandler(IPrestadorRepository prestadorRepository)
        {
            _prestadorRepository = prestadorRepository;
        }

        public async Task<Unit> Handle(UpdatePrestadorCommand request, CancellationToken cancellationToken)
        {
            var prestador = await _prestadorRepository.GetByIdAsync(request.Id);
            
            prestador.Update(request.Apelido, request.Nome, request.CNPJ, request.Endereco, request.Numero,
                                    request.Complemento, request.Bairro, request.Cidade, request.Estado, request.CEP,
                                    request.Telefone, request.Celular, request.Email, request.Categoria, request.TipoPag,
                                    request.TipoDoc, request.Banco, request.Agencia, request.Conta, request.TipoPix, request.Pix,
                                    request.Favorecido, request.CPF, request.Ativo);

            await _prestadorRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
