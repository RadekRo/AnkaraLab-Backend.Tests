using Moq;
using AnkaraLab_BackEnd.WebAPI.Controllers;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AnkaraLab_BackEnd.WebAPI.Domain;


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

            mockRepository.Setup(repo => repo.GetClientAsync(It.IsAny<int>()))
                            .ReturnsAsync(new Client
                            {
                              Id = 1,
                              Name = "Jarosław",
                              Surname = "Kaczyński",
                              Discount = 0,
                              LastLoginDate = DateTime.Now,
                              Email = "",
                              Password = "",
                              Phone = "",
                              Newsletter = false,
                              IsActive = true,
                              IsAdmin = false,
                              Status = 1,
                              FtpLogin = "",
                              FtpPassword = "",
                              Epoint = 0,
                              Deposit = 0,
                              Deadline = DateTime.Now
                          });

            var controller = new ClientsController(mockRepository.Object, mockMapper.Object, mockLogger.Object);

            var result = await controller.GetClient(1);

            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            Assert.IsNotNull((result.Result as OkObjectResult)?.Value);

            mockRepository.Verify(repo => repo.GetClientAsync(1), Times.Once, "OK");
        }

    }
}
