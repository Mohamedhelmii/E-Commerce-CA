using E_Commerce.Repository.Data;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _storeContext;
        public BuggyController(StoreContext context)
        {
            _storeContext = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFound()
        {
            var thing = _storeContext.Products.Find(100);
            return (thing == null) ? NotFound() : Ok();
        }

        [HttpGet("servererror")]
        public ActionResult ServerError()
        {
            var thing = _storeContext.Products.Find(100);
            var thingTOREturn = thing.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetValidationError(int id)
        {
            return Ok();
        }
    }
}
