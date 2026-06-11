using Microsoft.AspNetCore.Mvc;
using Pagamentos.API.Controllers;
using Pagamentos.API.Models;
using Xunit;

namespace Pagamentos.UnitTests.API.Controllers
{
    public class PingControllerTests
    {
        [Fact]
        public void Get_ReturnsOkWithPongMessage()
        {
            var controller = new PingController();

            var result = controller.Get();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var body = Assert.IsType<PongResponse>(okResult.Value);
            Assert.Equal("pong", body.Message);
        }
    }
}
