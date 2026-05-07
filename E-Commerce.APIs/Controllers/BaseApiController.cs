using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace E_Commerce.APIs.Controllers
{
    #region Explain
        // - Created BaseApiController with[ApiController] and[Route] attributes.
        // - Inherited ProductsController from BaseApiController to reduce code duplication.
        // - Set up a foundation for future shared logic and centralized error handling.
    #endregion
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}
