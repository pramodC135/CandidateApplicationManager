using CandidateApplicationManager.Api.Core;
using Xunit;
using Moq;
using CandidateApplicationManager.Api.Entities;
using CandidateApplicationManager.Api.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace CandidateApplicationManager.UniTests
{
    public class ApplicationControllerTests
    {
        [Fact]
        public async Task GetApplicationAsync_WithUnExistingItem_ReturnsNotFound()
        {
            // Arrange
            var repositoryStub = new Mock<IApplicationRepository>();
            repositoryStub.Setup(repo => repo.GetApplicationAsync(It.IsAny<Guid>().ToString())).ReturnsAsync((Application)null);

            var loggerStub = new Mock<ILogger<ApplicationController>>();

            var controller = new ApplicationController(repositoryStub.Object, loggerStub.Object);

            //Act
            var result = await controller.GetApplicationById(Guid.NewGuid().ToString());

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
} 