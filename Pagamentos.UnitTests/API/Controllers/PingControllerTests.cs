using Microsoft.AspNetCore.Mvc;
using Pagamentos.API.Controllers;
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
            Assert.Equal(200, okResult.StatusCode);

            var body = okResult.Value;
            var messageProp = body.GetType().GetProperty("message");

            Assert.NotNull(messageProp);
            Assert.Equal("pong", messageProp.GetValue(body));
        }
    }
}
