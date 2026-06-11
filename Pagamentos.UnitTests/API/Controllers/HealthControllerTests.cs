using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pagamentos.API.Controllers;
using System;
using Xunit;

namespace Pagamentos.UnitTests.API.Controllers
{
    public class HealthControllerTests
    {
        [Fact]
        public void GetDetails_ReturnsOkWithExpectedFields()
        {
            var envMock = new Mock<IWebHostEnvironment>();
            envMock.Setup(e => e.EnvironmentName).Returns("Testing");

            var controller = new HealthController(envMock.Object);

            var result = controller.GetDetails();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var body = okResult.Value;

            var statusProp = body.GetType().GetProperty("status");
            var envProp = body.GetType().GetProperty("environment");
            var tsProp = body.GetType().GetProperty("timestamp");

            Assert.NotNull(statusProp);
            Assert.NotNull(envProp);
            Assert.NotNull(tsProp);

            Assert.Equal("ok", statusProp.GetValue(body));
            Assert.Equal("Testing", envProp.GetValue(body));
            Assert.IsType<DateTime>(tsProp.GetValue(body));
        }
    }
}
