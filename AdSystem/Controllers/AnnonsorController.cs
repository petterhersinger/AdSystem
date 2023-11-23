using Microsoft.AspNetCore.Mvc;
using AdSystem.Models;

namespace AdSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnnonsorController : Controller
    {
        [HttpGet("id", Name = "GetAnnonsorById")]
        public AnnonsorModel GetAnnonsorById(int id)
        {
            AnnonsorModel Annonsor = new AnnonsorModel();
            AnnonsorMethods am = new AnnonsorMethods();
            Annonsor = am.GetAnnonsor(id, out string error);
            return Annonsor;
        }

        [HttpPost(Name = "InsertAnnonsor")]
        public ActionResult<AnnonsorModel> InsertAnnonsor([FromBody] AnnonsorModel annonsor)
        {
            AnnonsorMethods pm = new AnnonsorMethods();
            string errormsg = "";
            annonsor = pm.InsertAnnonsor(annonsor, out errormsg);
            if (errormsg == "")
            {
                return Ok(annonsor);
            }
            else return BadRequest();
        }
    }
}