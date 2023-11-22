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
        public string InsertAnnonsor([FromBody] AnnonsorModel annonsor)
        {
            AnnonsorMethods pm = new AnnonsorMethods();
            string errormsg = "";
            int i = pm.InsertAnnonsor(annonsor, out errormsg);
            if (errormsg == null)
            {
                return i.ToString();
            }
            else return errormsg;
        }

        [HttpGet("organisationsnummer", Name = "GetAnnonsorByOrganisationsnummer")]
        public AnnonsorModel GetAnnonsorByOrganisationsnummer(string organisationsnummer)
        {
            AnnonsorModel Annonsor = new AnnonsorModel();
            AnnonsorMethods am = new AnnonsorMethods();
            Annonsor = am.GetAnnonsorByOrganisationsnummer(organisationsnummer, out string error);
            return Annonsor;
        }

        [HttpGet("prenumerantId", Name = "GetAnnonsorByPrenumerantId")]
        public AnnonsorModel GetAnnonsorByPrenumerantId(int prenumerantId)
        {
            AnnonsorModel Annonsor = new AnnonsorModel();
            AnnonsorMethods am = new AnnonsorMethods();
            Annonsor = am.GetAnnonsorByPrenumerantId(prenumerantId, out string error);
            return Annonsor;
        }
    }
}