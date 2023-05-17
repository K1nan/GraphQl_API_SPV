using GPL.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPL.Controllers
{
    [ApiController]
    public class DataController : ControllerBase
    {
        PersonDataContext _context = new PersonDataContext();

        [Route("GetPersonInfos")]

        [HttpGet]
        public List<PersonInfo> GetPersonInfos()
        {
            return _context.PersonInfos.ToList();
        }

        [Route("POSTPersonInfos")]

        [HttpPost]
        public void POSTPersonInfo(PersonInfo person)
        {
            _context.Add(person);
            _context.SaveChanges();
        }

    }

}
