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
    }
}