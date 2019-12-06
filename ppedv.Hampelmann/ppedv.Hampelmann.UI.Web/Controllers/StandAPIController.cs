using System.Collections.Generic;
using System.Web.Http;
using ppedv.Hampelmann.Logic;
using ppedv.Hampelmann.Model;

namespace ppedv.Hampelmann.UI.Web.Controllers
{
    
    [Route("api/[controller]")]
    public class StandAPIController : ApiController
    {

        Core core = new Core();

        public IEnumerable<Stand> Get()
        {
            return core.UnitOfWork.StandRepository.GetAll();
        }

        // GET: api/AutoApi/5
        public Stand Get(int id)
        {
            return core.UnitOfWork.StandRepository.GetById(id);
        }

        // POST: api/AutoApi
        public void Post([FromBody]Stand stand)
        {
            core.UnitOfWork.StandRepository.Add(stand);
            core.UnitOfWork.Save();
        }


    }
}