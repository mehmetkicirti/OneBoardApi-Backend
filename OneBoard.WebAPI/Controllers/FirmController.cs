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
    public class FirmController : ControllerBase
    {
        public IFirmService _service;

        public FirmController(IFirmService service)
        {
            this._service = service;
        }


        [HttpPost("Add")]
        public IActionResult Add(Firm firm)
        {
            var result = _service.Add(firm);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Success.ToString() + " and  " + result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(Firm firm)
        {
            var result = _service.Update(firm);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Success.ToString() + " and  " + result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Firm firm)
        {
            var result = _service.Delete(firm);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Success.ToString() + " and  " + result.Message);
        }

        [HttpGet(template: "GetAll")]
        public IActionResult GetAll()
        {
            var result = _service.GetFirm();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Success.ToString() + " and  " + result.Message);
        }
    }
}
