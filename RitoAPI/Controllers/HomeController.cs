using Microsoft.AspNetCore.Mvc;

namespace RitoAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> ReturnBasic()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        }

        [Route("check")]
        [HttpGet]
        public ActionResult<string> CheckIfTextIsEqualToOne(string text)
        {
            if (text == "1")
            {
                return Ok("1");
            } else
            {
                return NotFound("not 1");
            }
        }
    }
}