using Moq;
using Pagamentos.Application.Queries.GetAllPrestadores;
using Pagamentos.Core.Entities;
using Pagamentos.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Pagamentos.UnitTests.Application.Queries
{
    public class GetAllPrestadoresCommandHandlerTests
    {
        [Fact]
        public async Task ThreePrestadoresExist_Executed_ReturnThreePrestadoresViewModels()
        {
            // Arrange
            var prestadores = new List<Prestadores>
            {
            new Prestadores
            ("Especialistas", "Grupo Especialistas", "61.743.188/0001-52", "Avenida Pasteur, N 263 - São Paulo", "263", "Prédio", "Vila Euthalia",
             "São Paulo", "São Paulo", "03531-070", "1140028922", "11947214217", "feehlipeeh014@hotmail.com", "Serviços", "Boleto", "Documento",
             "Bradesco", "0387", "20382-9", "Celular", "11947214217", "Felipe Gabriel Correa da Silva", "371.001.188-40"),

            new Prestadores
            ("Especialistas 2", "Grupo Especialistas 2", "61.722.188/0001-52", "Avenida Pasteur, N 263 - São Paulo", "264", "Prédio 2", "Vila Euthalia",
             "São Paulo", "São Paulo", "03531-070", "1140028922", "11947214217", "feehlipeeh014@hotmail.com", "Serviços", "Boleto", "Documento",
             "Bradesco", "0187", "20192-9", "Celular", "11947214217", "Felipe Gabriel Correa da Silva", "322.001.188-40"),

            new Prestadores
            ("Especialistas 3", "Grupo Especialistas 3", "61.743.128/0001-32", "Avenida Pasteur, N 263 - São Paulo", "266", "Prédio 3", "Vila Euthalia",
             "São Paulo", "São Paulo", "03531-070", "1140028922", "11947214217", "feehlipeeh014@hotmail.com", "Serviços", "Boleto", "Documento",
             "Bradesco", "0322", "20112-9", "Celular", "11947214217", "Felipe Gabriel Correa da Silva", "371.001.123-40")
            };

            var prestadorRepositoryMock = new Mock<IPrestadorRepository>();
            prestadorRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(prestadores);

            var getAllPrestadoresQuery = new GetPrestadoresQuery("");
            var getAllPrestadoresQueryHandler = new GetPrestadoresQueryHandler(prestadorRepositoryMock.Object);

            // Act
            var prestadorViewModelList = await getAllPrestadoresQueryHandler.Handle(getAllPrestadoresQuery, new CancellationToken());

            // Assert
            Assert.NotNull(prestadorViewModelList);
            Assert.NotEmpty(prestadorViewModelList);
            Assert.Equal(prestadores.Count, prestadorViewModelList.Count);

            prestadorRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
