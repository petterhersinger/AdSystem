using Microsoft.AspNetCore.Mvc;
using AdSystem.Models;

namespace AdSystem.Controllers { }
    [ApiController]
    [Route("[controller]")]
    public class AnnonsController : Controller
    {
        [HttpGet("AllAnnonser", Name = "GetAllAnnonser")]
        public List<AnnonsModel> GetAllAnnonser()
        {
            AnnonsMethods annonsMethods = new AnnonsMethods();
            List<AnnonsModel> annonsList = annonsMethods.GetAllAnnonser(out string error);

            if (error != null)
            {
                
            }

            return annonsList;
        }


        [HttpPost(Name = "InsertAnnons")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public string InsertAnnons([FromBody] AnnonsModel annons)
        {
            AnnonsorMethods am = new AnnonsorMethods();
            AnnonsMethods adm = new AnnonsMethods();
            string errormsg = "";

            AnnonsorModel annonsor = am.GetAnnonsor(annons.AnnonsorId, out string annonsorError);

            annons.Pris = annonsor.ForetagsAnnonsor ? 40 : 0;

            int rowsAffected = adm.InsertAnnons(annons, out errormsg);

            if (errormsg == null)
            {
                return rowsAffected.ToString();
            }
            else
            {
                return errormsg;
            }
        }

}
