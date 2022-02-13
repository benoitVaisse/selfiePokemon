using Microsoft.AspNetCore.Mvc;
using SelfieAPokemon.API.UI.Controllers;
using System;
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
            var controller = new SelfieController(null);
            // Act
            var result = controller.TestAMoi();
            //Assert

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        #endregion
    }
}
