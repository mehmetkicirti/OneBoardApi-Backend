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
    public class GroupController : ControllerBase
    {
        public IGroupService _service;

        public GroupController(IGroupService service)
        {
            this._service = service;
        }


        [HttpPost("Add")]
        public IActionResult Add(Group group)
        {
            var result = _service.Add(group);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Success.ToString() + " and  " + result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(Group group)
        {
            var result = _service.Update(group);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Success.ToString() + " and  " + result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Group group)
        {
            var result = _service.Delete(group);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Success.ToString() + " and  " + result.Message);
        }

        [HttpGet(template: "GetAll")]
        public IActionResult GetAll()
        {
            var result = _service.GetEntityValues();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Success.ToString()+" and  "+result.Message);
        }
    }
}