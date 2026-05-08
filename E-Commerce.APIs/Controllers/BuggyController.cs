using E_Commerce.APIs.Errors;
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
            var thing = _storeContext.Products.Find(Guid.NewGuid());
            return (thing == null) ? NotFound(new ApiResponse(404)) : Ok(thing);
        }

        [HttpGet("servererror")]
        public ActionResult ServerError()
        {
            var thing = _storeContext.Products.Find(Guid.NewGuid());
            var thingTOREturn = thing.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetValidationError(int id)
        {
            return Ok();
        }
    }
}
