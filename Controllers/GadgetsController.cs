using webappmssql.Data;
using System.Linq;
using webappmssql.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace webappmssql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GadgetsController: ControllerBase
    {
        private readonly MyWorldDBContext _myWorldDBContext;

        public GadgetsController(MyWorldDBContext myWorldDBContext)
        {
            _myWorldDBContext = myWorldDBContext;
        }

        // การสร้าง Method Get All Gadgets()
        // https://localhost:5001/Gadgets/all
        [HttpGet]
        [Route("all")]
        public IActionResult GetAllGadgets(){
            var allGadgets = _myWorldDBContext.Gadgets.ToList();
            return Ok(allGadgets);
        }

        // สร้าง Method Add Gadgets()
        // https://localhost:5001/Gadgets/add
        [HttpPost]
        [Route("add")]
        public IActionResult CreateGadget(Gadgets gadgets)
        {
            _myWorldDBContext.Gadgets.Add(gadgets);
            _myWorldDBContext.SaveChanges();
            return Ok(gadgets.Id);
        }

        // สร้าง Method Update Gadgets()
        // https://localhost:5001/Gadgets/update
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateGadget(Gadgets gadgets)
        {
            _myWorldDBContext.Update(gadgets);
            _myWorldDBContext.SaveChanges();
            return NoContent();
        }

        // สร้าง Method Delete Gadgets()
        // https://localhost:5001/Gadgets/delete
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteGadget(int id)
        {
            var gadgetToDelete = _myWorldDBContext.Gadgets.Where(_ => _.Id == id).FirstOrDefault();
            if (gadgetToDelete == null)
            {
                return NotFound();
            }

            _myWorldDBContext.Gadgets.Remove(gadgetToDelete);
            _myWorldDBContext.SaveChanges();
            return NoContent();
        }

    }
}