﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.Errors;
using Talabat.Repository.Data;

namespace Talabat.API.Controllers
{
    public class BugyController : BaseApiController
    {
        private readonly StoreContext _dbContext;

        public BugyController(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var product = _dbContext.Products.Find(100);
            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok(product);
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var product = _dbContext.Products.Find(100);
            var productToReturn = product.ToString();

            return Ok(productToReturn);
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id) // Validation Error
        {
            return Ok();
        }

        [HttpGet("unauthorized")]
        public ActionResult GetUnauthorizedError()
        {
            return Unauthorized(new ApiResponse(401));
        }

    }
}
