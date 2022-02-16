using Microsoft.AspNetCore.Mvc;
using Moq;
using SelfieAPokemon.API.UI.Controllers;
using SelfieAPokemon.Core.Domain;
using SelfieAPokemon.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestWebApi
{
    public class SelfiControllerUnitTest
    {
        #region public methods

        [Fact]
        public void ShouldReturnListOfSelfies()
        {
            //Arrange
            var SelfieRepositoryMock = new Mock<ISelfieRepository>();
            SelfieRepositoryMock.Setup(r => r.GetAll()).ReturnsAsync(new List<Selfie>()
            {
                new Selfie(),
                new Selfie(),
            });
            var controller = new SelfieController(SelfieRepositoryMock.Object);

            // Act
            var result = controller.TestAMoi();
            //Assert

            Assert.NotNull(result);
            Assert.IsType< Task<ActionResult<List<Selfie>>>>(result);

            Assert.NotNull(result.Result);

        }

        #endregion
    }
}
