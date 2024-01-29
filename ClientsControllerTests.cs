using Moq;
using AnkaraLab_BackEnd.WebAPI.Controllers;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;


namespace AnkaraLab_Backend.Tests
{
    public class ClientsControllerTests
    {
        [Test]
        public async Task GetClients_ReturnsOkResult()
        {
            var mockRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            var controller = new ClientsController(mockRepository.Object, mockMapper.Object, mockLogger.Object);

            var result = await controller.GetClients();

            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            Assert.IsNotNull((result.Result as OkObjectResult)?.Value);
        }

        [Test]
        public async Task GetClient_ReturnsOkResultForValidId()
        {
            var mockRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            var controller = new ClientsController(mockRepository.Object, mockMapper.Object, mockLogger.Object);

            var result = await controller.GetClient(1);

            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            Assert.IsNotNull((result.Result as OkObjectResult)?.Value);
        }

    }
}
