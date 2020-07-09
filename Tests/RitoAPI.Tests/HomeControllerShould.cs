using Microsoft.AspNetCore.Mvc;
using RitoAPI.Controllers;
using Xunit;

namespace RitoAPI.Tests
{
    public class HomeControllerShould 
    {
        HomeController _controller;

        public HomeControllerShould()
        {
            _controller = new HomeController();
        }

        [Fact]
        public void ReturnBasic()
        {
            var result = _controller.ReturnBasic();
            Assert.IsType<ActionResult<string>>(result);
        }

        [Fact]
        public void CheckIfTextIsEqualToOne()
        {
            var okResult = _controller.CheckIfTextIsEqualToOne("1");
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
