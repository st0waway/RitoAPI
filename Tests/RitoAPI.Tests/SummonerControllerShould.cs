using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RitoAPI.Controllers;
using RitoAPI.Models;
using Xunit;

namespace RitoAPI.Tests
{
    public class SummonerControllerShould
    {
        private readonly SummonerController _summonerController;
        //IOptions<UserConfig> userConfig = Options.Create(new UserConfig { APIKey = "RGAPI-3442f48a-1573-4bd2-bfbf-442d809728b3" });

        public SummonerControllerShould()
        {
            _summonerController = new SummonerController();
        }

        [Fact]
        public void GetSummonerByName()
        {
            var result = _summonerController.GetSummonerByName("Lum1x");
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetSummonerByName401()
        {
            IOptions<UserConfig> userConfig = Options.Create(new UserConfig { APIKey = "" });
            var noKeySummonerController = new SummonerController(userConfig);
            var result = noKeySummonerController.GetSummonerByName("Lum1x");
            Assert.Null(result.Value);
            Assert.IsType<StatusCodeResult>(result.Result);            
        }
    }
}
