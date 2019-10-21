using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneBoard.Business.Abstract;
using OneBoard.Entities.Concrete;

namespace OneBoard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost(template:"Add")]
        public IActionResult Add(User user)
        {
            var result = service.Add(user);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Success.ToString());
        }

        [HttpPost(template:"Update")]

        public IActionResult Update(User user)
        {
            var result = service.Update(user);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Success.ToString());
        }

        [HttpPost(template: "Delete")]

        public IActionResult Delete(User user)
        {
            var result = service.Delete(user);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Success.ToString());
        }

        [HttpGet(template:"GetAll")]
        public IActionResult GetAll()
        
        {
            var result = service.GetEntityValues();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Success.ToString());
        }
    }
}