using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace microMantra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {

        private readonly IVisitorRepository _visitorRepository;

        public VisitorController(IVisitorRepository visitorRepository)
        {

            _visitorRepository = visitorRepository;
        }

        // GET: api/<VisitorController>
        [HttpGet]
        public IActionResult Get()
        {
            var visitors = _visitorRepository.GetVisitors();
            return new OkObjectResult(visitors);
        }

        // GET api/<VisitorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var visitor = _visitorRepository.GetVisitorByID(id);

            return new OkObjectResult(visitor);
        }

        // POST api/<VisitorController>
        [HttpPost]
        public IActionResult Post([FromBody] visitor objvisitor)
        {
            using (var scope = new TransactionScope())
            {
                _visitorRepository.addVisitor(objvisitor);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = objvisitor.visitorID}, objvisitor);
            }

        }

        // PUT api/<VisitorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] visitor objvisitor)
        {
            if (objvisitor != null)
            {
                using (var scope = new TransactionScope())
                {
                    _visitorRepository.updateVisitor(objvisitor);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<VisitorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _visitorRepository.DeleteVisitor(id);
            return new OkResult();
        }
    }
}
