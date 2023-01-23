using Moq;
using Pagamentos.Application.Commands.CreatePrestador;
using Pagamentos.Core.Entities;
using Pagamentos.Core.Repositories;
using Pagamentos.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Pagamentos.UnitTests.Application.Commands
{
    public class CreatePrestadorCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnPrestadorId()
        {
            // Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            var prestadorRepository = new Mock<IPrestadorRepository>();

            unitOfWork.SetupGet(uow => uow.Prestadores).Returns(prestadorRepository.Object);
            var createPrestadorCommand = new CreatePrestadorCommand
            {
                Apelido = "Especialistas",
                Nome = "Grupo Especialistas",
                CNPJ = "61.743.188/0001-52",
                Endereco = "Avenida Pasteur, N 263 - São Paulo",
                Numero = "263",
                Complemento = "Prédio",
                Bairro = "Vila Euthalia",
                Cidade = "São Paulo",
                Estado = "São Paulo",
                CEP = "03531-070",
                Telefone = "1140028922",
                Celular = "11947214217",
                Email = "feehlipeeh014@hotmail.com",
                Categoria = "Serviços",
                TipoPag = "Boleto",
                TipoDoc = "Documento",
                Banco = "Bradesco",
                Agencia = "0387",
                Conta = "20382-9",
                TipoPix = "Celular",
                Pix = "11947214217",
                Favorecido = "Felipe Gabriel Correa da Silva",
                CPF = "371.001.188-40" 
            };

            var createPrestadorCommandHandler = new CreatePrestadorCommandHandler(unitOfWork.Object);

            // Act
            var id = await createPrestadorCommandHandler.Handle(createPrestadorCommand, new CancellationToken());

            // Assert
            Assert.True(id >= 0);

            prestadorRepository.Verify(pr => pr.AddAsync(It.IsAny<Prestadores>()), Times.Once);
        }
    }
}
