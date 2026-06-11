using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pagamentos.API.Controllers;
using Pagamentos.API.Health;
using Pagamentos.API.Models;
using System;
using Xunit;

namespace Pagamentos.UnitTests.API.Controllers
{
    public class HealthControllerTests
    {
        private readonly Mock<IWebHostEnvironment> _envMock;
        private readonly Mock<IDatabaseHealthCheck> _dbHealthCheckMock;

        public HealthControllerTests()
        {
            _envMock = new Mock<IWebHostEnvironment>();
            _envMock.Setup(e => e.EnvironmentName).Returns("Testing");
            _dbHealthCheckMock = new Mock<IDatabaseHealthCheck>();
        }

        [Fact]
        public void GetDetails_ReturnsOk()
        {
            _dbHealthCheckMock.Setup(d => d.CanConnect()).Returns(true);
            var controller = new HealthController(_envMock.Object, _dbHealthCheckMock.Object);

            var result = controller.GetDetails();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetDetails_StatusIsOk()
        {
            _dbHealthCheckMock.Setup(d => d.CanConnect()).Returns(true);
            var controller = new HealthController(_envMock.Object, _dbHealthCheckMock.Object);

            var result = controller.GetDetails();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var body = Assert.IsType<HealthDetailsResponse>(okResult.Value);
            Assert.Equal("ok", body.Status);
        }

        [Fact]
        public void GetDetails_ApplicationIsCorrect()
        {
            _dbHealthCheckMock.Setup(d => d.CanConnect()).Returns(true);
            var controller = new HealthController(_envMock.Object, _dbHealthCheckMock.Object);

            var result = controller.GetDetails();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var body = Assert.IsType<HealthDetailsResponse>(okResult.Value);
            Assert.Equal("Pagamentos.API", body.Application);
        }

        [Fact]
        public void GetDetails_EnvironmentIsPopulated()
        {
            _dbHealthCheckMock.Setup(d => d.CanConnect()).Returns(true);
            var controller = new HealthController(_envMock.Object, _dbHealthCheckMock.Object);

            var result = controller.GetDetails();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var body = Assert.IsType<HealthDetailsResponse>(okResult.Value);
            Assert.NotEmpty(body.Environment);
            Assert.Equal("Testing", body.Environment);
        }

        [Fact]
        public void GetDetails_TimestampUtcIsPopulated()
        {
            _dbHealthCheckMock.Setup(d => d.CanConnect()).Returns(true);
            var controller = new HealthController(_envMock.Object, _dbHealthCheckMock.Object);

            var result = controller.GetDetails();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var body = Assert.IsType<HealthDetailsResponse>(okResult.Value);
            Assert.NotEmpty(body.TimestampUtc);
            Assert.True(DateTime.TryParse(body.TimestampUtc, out _));
        }

        [Fact]
        public void GetDetails_VersionIsPopulated()
        {
            _dbHealthCheckMock.Setup(d => d.CanConnect()).Returns(true);
            var controller = new HealthController(_envMock.Object, _dbHealthCheckMock.Object);

            var result = controller.GetDetails();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var body = Assert.IsType<HealthDetailsResponse>(okResult.Value);
            Assert.NotEmpty(body.Version);
        }

        [Fact]
        public void GetDetails_DatabaseCanConnectTrue_WhenDbContextConnects()
        {
            _dbHealthCheckMock.Setup(d => d.CanConnect()).Returns(true);
            var controller = new HealthController(_envMock.Object, _dbHealthCheckMock.Object);

            var result = controller.GetDetails();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var body = Assert.IsType<HealthDetailsResponse>(okResult.Value);
            Assert.True(body.Database.CanConnect);
        }

        [Fact]
        public void GetDetails_DatabaseCanConnectFalse_WhenExceptionOccurs()
        {
            _dbHealthCheckMock.Setup(d => d.CanConnect()).Throws(new Exception("DB connection failed"));
            var controller = new HealthController(_envMock.Object, _dbHealthCheckMock.Object);

            var result = controller.GetDetails();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var body = Assert.IsType<HealthDetailsResponse>(okResult.Value);
            Assert.False(body.Database.CanConnect);
        }
    }
}
