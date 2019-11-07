using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneBoard.Business.Abstract;
using OneBoard.Core.Utilities.Extensions;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.Dashboard;
using OneBoard.Entities.Mapping.DashboardMap;

namespace OneBoard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _Dashboardservice;
        private IMapper _mapper;

        public DashboardController(IDashboardService dashboardservice, IMapper mapper)
        {
            this._Dashboardservice = dashboardservice;
            this._mapper = mapper;
        }

        #region normal
        [HttpPost("Add")]
        public IActionResult Add(DashboardDTO dashboardDto)
        {
            _mapper = DashboardMapping.GetMapper().CreateMapper();
            Dashboard dashboard = _mapper.Map<DashboardDTO,Dashboard>(dashboardDto);

            var result = _Dashboardservice.Add(dashboard);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Success.ToString() + "and " + result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(DashboardDTO dashboardDto)
        {
            _mapper = DashboardMapping.GetMapper().CreateMapper();
            Dashboard dashboard = _mapper.Map<DashboardDTO, Dashboard>(dashboardDto);
            var result = _Dashboardservice.Update(dashboard);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Success.ToString() + "and " + result.Message);
        }


        [HttpPost("Delete")]
        public IActionResult Delete(Dashboard dashboard)
        {
            var result = _Dashboardservice.Delete(dashboard);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Success.ToString() + " and  " + result.Message);
        }

        [HttpGet(template: "GetAll")]
        public IActionResult GetAll()
        {

            var result = _Dashboardservice.GetEntityValues();

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
            IDataResult<IList<Dashboard>> DashboardListResult = await _Dashboardservice.GetEntityValuesAsync();
            if (DashboardListResult.Success)
            {
                return Ok(DashboardListResult.Data);
            }
            else
            {
                return BadRequest(DashboardListResult.Message);
            }
        }
        //localhost/api/firm/2 => this method execute.
        [HttpGet(template: "getbyidAsync/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            IDataResult<Dashboard> DashboardResult = await _Dashboardservice.FindByIdAsync(Id);
            if (DashboardResult.Success)
            {
                return Ok(DashboardResult.Data);
            }
            else
            {
                return BadRequest(DashboardResult.Message);
            }
        }
        #endregion
        #region PostPut
        //localhost/api/firm/addfirmasync
        [HttpPost(template: "addfirmAsync")]
        public async Task<IActionResult> AddFirmAsync(DashboardDTO dashboardDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {

                _mapper = DashboardMapping.GetMapper().CreateMapper();
                Dashboard dashboard = _mapper.Map<DashboardDTO,Dashboard>(dashboardDTO);
                var DashboardResult = await _Dashboardservice.AddAsync(dashboard);
                if (DashboardResult.Success)
                {
                    return Ok(DashboardResult.Message);
                }
                else
                {
                    return BadRequest(DashboardResult.Message);
                }
            }
        }
        [HttpPut(template: "updatefirmAsync/{id:int}")]
        public async Task<IActionResult> UpdateFirmAsync(DashboardDTO dashboardDTO, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                IDataResult<Dashboard> DashboardResult = await _Dashboardservice.FindByIdAsync(Id);
                if (DashboardResult==null)
                {
                    return BadRequest(DashboardResult.Message);
                }

                _mapper = DashboardMapping.GetMapper().CreateMapper();
                Dashboard dashboard = _mapper.Map<DashboardDTO, Dashboard>(dashboardDTO);
                var Dashboardresult = await _Dashboardservice.AddAsync(dashboard);
                if (Dashboardresult.Success)
                {
                    return Ok(Dashboardresult.Message);
                }
                else
                {
                    return BadRequest(Dashboardresult.Message);
                }

            }
        }
        [HttpDelete(template: "deletefirmAsync/{id:int}")]
        public async Task<IActionResult> DeleteFirmAsync(int Id)
        {
            var result = await _Dashboardservice.DeleteByIdAsync(Id);
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