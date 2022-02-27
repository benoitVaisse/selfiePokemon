using Microsoft.AspNetCore.Mvc;
using Moq;
using SelfieAPokemon.API.UI.Controllers;
using SelfieAPokemon.Core.Application.Models.DTOs;
using SelfieAPokemon.Core.Domain;
using SelfieAPokemon.Core.Domain.Interfaces;
using SelfieAPokemon.Core.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestWebApi
{
    public class SelfiControllerUnitTest
    {
        #region public methods

        //[Fact]
        //public void ShouldReturnListOfSelfies()
        //{
        //    //Arrange
        //    var SelfieRepositoryMock = new Mock<ISelfieRepository>();
        //    SelfieRepositoryMock.Setup(r => r.GetAll()).ReturnsAsync(new List<Selfie>()
        //    {
        //        new Selfie(),
        //        new Selfie(),
        //    });
        //    var controller = new SelfieController(SelfieRepositoryMock.Object);

        //    // Act
        //    var result = controller.GetAll();
        //    //Assert

        //    Assert.NotNull(result);
        //    Assert.IsType< Task<ActionResult<List<Selfie>>>>(result);

        //    Assert.NotNull(result.Result);

        //}

        //[Fact]
        //public async void ShouldAddOneSelfie()
        //{
        //    //Arange
        //    SelfieDto Selfie = new SelfieDto();
        //    var SelfieRepositoryMock = new Mock<ISelfieRepository>();
        //    var unit = new Mock<IUnitOfWork>();
        //    SelfieRepositoryMock.Setup(r => r.UnitOfWork).Returns(unit.Object);
        //    SelfieRepositoryMock.Setup(r => r.Add(It.IsAny<Selfie>())).ReturnsAsync(new Selfie() { Id = 4 });
            

        //    //Act
        //    var controller = new SelfieController(SelfieRepositoryMock.Object);
        //    var result = await controller.AddOne(Selfie);

        //    //Assert

        //    Assert.NotNull(result);
        //    Assert.IsType<OkObjectResult>(result);

        //    var addedSelfie = (result as OkObjectResult).Value as SelfieDto;

        //    Assert.NotNull(addedSelfie);
        //    Assert.True(addedSelfie.Id > 0);
        //}

        #endregion
    }
}
