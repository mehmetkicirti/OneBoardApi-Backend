﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneBoard.Business.Abstract;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.Firm;
using OneBoard.Core.Utilities.Extensions;
using OneBoard.Entities.Mapping.FirmMap;
using Microsoft.AspNetCore.Authorization;

namespace OneBoard.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FirmController : ControllerBase
    {
        private readonly IFirmService _Firmservice;
        private IMapper _mapper;
        
        public FirmController(IFirmService Firmservice,IMapper mapper)
        {
            this._Firmservice = Firmservice;
            this._mapper = mapper;
        }


        #region normal
        [HttpPost("Add")]
        public IActionResult Add(FirmDTO firmDto)
        {
            _mapper = FirmMapping.GetMapper().CreateMapper();
            Firm firm = _mapper.Map<FirmDTO, Firm>(firmDto);

            var result = _Firmservice.Add(firm);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Success.ToString() + "and " + result.Message);
        }

       [HttpPut("Update")]
       public IActionResult Update(FirmDTO firmDto)
       {
           _mapper = FirmMapping.GetMapper().CreateMapper();
           Firm firm = _mapper.Map<FirmDTO, Firm>(firmDto);

            var result = _Firmservice.Update(firm);
          

          if (result.Success)
          {
                return Ok(result.Message);
          }

            return BadRequest(result.Success.ToString() + "and " + result.Message);
        }
          

        [HttpPost("Delete")]
        public IActionResult Delete(Firm firm)
        {
            var result = _Firmservice.Delete(firm);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Success.ToString() + " and  " + result.Message);
        }

        [HttpGet(template: "GetAll")]
        public IActionResult GetAll()
        {
            
            var result = _Firmservice.GetEntityValues();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Success.ToString() + " and  " + result.Message);
        }
        #endregion

        #region async
        #region Get

        [HttpGet(template: "getlistAsync")]
        public async Task<IActionResult> GetListAsync()
        {
            IDataResult<IList<Firm>> FirmListResult = await _Firmservice.GetEntityValuesAsync();
            if (FirmListResult.Success)
            {
                return Ok(FirmListResult.Data);
            }
            else
            {
                return BadRequest(FirmListResult.Message);
            }
        }
        //localhost/api/firm/2 => this method execute.
        [HttpGet(template: "getByIdAsync/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            IDataResult<Firm> FirmResult = await _Firmservice.FindByIdAsync(Id);
            if (FirmResult.Success)
            {
                return Ok(FirmResult.Data);
            }
            else
            {
                return BadRequest(FirmResult.Message);
            }
        }
        #endregion
        #region Post
        //localhost/api/firm/addfirmasync
        [HttpPost(template: "addfirmAsync")]
        public async Task<IActionResult> AddAsync(FirmDTO firmDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {

                _mapper = FirmMapping.GetMapper().CreateMapper();
                //Using with Automapper mapped by Firm to FirmDTO
                Firm firm = _mapper.Map<FirmDTO, Firm>(firmDTO);
                //Firm firm = new Firm();

                //firm.FirmName = firmDTO.FirmName;
                //firm.ParentID = firmDTO.ParentID; //instead of this

                var FirmResult = await _Firmservice.AddAsync(firm);
                if (FirmResult.Success)
                {
                    return Ok(FirmResult.Message);
                }
                else
                {
                    return BadRequest(FirmResult.Message);
                }
            }
        }
        [HttpPut(template: "updatefirmAsync/{id:int}")]
        public async Task<IActionResult> UpdateAsync(FirmDTO firmDTO, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                IDataResult<Firm> firmDataResult = await _Firmservice.FindByIdAsync(Id);
                if (firmDataResult.Data == null)
                {
                    return BadRequest(firmDataResult.Message);
                }
                _mapper = FirmMapping.GetMapper().CreateMapper();
                Firm firm = _mapper.Map<FirmDTO, Firm>(firmDTO);
                firm.ID = firmDataResult.Data.ID;
                IResult firmResult = await _Firmservice.UpdateAsync(firm);
                if (firmResult.Success)
                {
                    return Ok(firmResult.Message);
                }
                else
                {
                    return BadRequest(firmResult.Message);
                }
            }
        }
        [HttpDelete(template: "deletefirmAsync/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var result = await _Firmservice.DeleteByIdAsync(Id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        #endregion
        #endregion
    }
}
