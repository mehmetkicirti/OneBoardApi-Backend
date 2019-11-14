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
using OneBoard.Entities.DTO.ChartType;
using OneBoard.Entities.Mapping.ChartTypeMap;

namespace OneBoard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartTypeController : ControllerBase
    {
        private IChartTypeService _service;
        private IMapper mapper;

        

        public ChartTypeController(IChartTypeService service, IMapper mapper)
        {
            this._service = service;
            this.mapper = mapper;
        }

        #region NORMAL

        [HttpPost("Add")]
        public IActionResult Add(ChartTypeDTO chartTypeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            else
            {
                mapper = ChartTypeMapping.GetMapper().CreateMapper();

                ChartType chartType = mapper.Map<ChartTypeDTO, ChartType>(chartTypeDto);

                IResult result = _service.Add(chartType);

                if (result.Success)
                    return Ok(result.Message);

                return BadRequest(result.Message);
            }
        }

        [HttpPut("Update/{id:int}")]
        public IActionResult Update(ChartTypeDTO chartTypeDto, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            else
            {
                IDataResult<ChartType> dataResult = _service.GetById(Id);

                if (dataResult == null)
                    return BadRequest(dataResult.Message);

                else
                {
                    mapper = ChartTypeMapping.GetMapper().CreateMapper();

                    ChartType chartType = mapper.Map<ChartTypeDTO, ChartType>(chartTypeDto);

                    IResult result = _service.Update(chartType);

                    if (result.Success)
                        return Ok(result.Message);

                    return BadRequest(result.Message);
                }
            }

        }

        [HttpPut("Delete/{id:int}")]
        public IActionResult Delete(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            else
            {
                IDataResult<ChartType> dataResult = _service.GetById(Id);

                if (dataResult == null)
                    return BadRequest(dataResult.Message);

                else
                {
                    IResult result = _service.Delete(dataResult.Data);

                    if (result.Success)
                        return Ok(result.Message);

                    return BadRequest(result.Message);
                }
            }
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            IDataResult<IList<ChartType>> result = _service.GetEntityValues();

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        #endregion


        #region async

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(ChartTypeDTO charTypeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            else
            {
                mapper = ChartTypeMapping.GetMapper().CreateMapper();

                ChartType chartType = mapper.Map<ChartTypeDTO, ChartType>(charTypeDto);

                IResult result = await _service.AddAsync(chartType);

                if (result.Success)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }
        }

        [HttpPut("UpdateAsync/{id:int}")]

        public async Task<IActionResult> UpdateAsync(ChartTypeDTO chartTypeDTO, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            IDataResult<ChartType> dataResult = _service.GetById(Id);

            if (dataResult == null)
                return BadRequest(dataResult.Message);

            else
            {
                mapper = ChartTypeMapping.GetMapper().CreateMapper();
                ChartType chartType = mapper.Map<ChartTypeDTO, ChartType>(chartTypeDTO);
                IResult result = await _service.UpdateAsync(chartType);


                if (result.Success)
                    return Ok(result.Message);
                return BadRequest(result.Message);

            }
        }


        [HttpDelete("DeleteAsync/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            else
            {       
               IResult result = await _service.DeleteByIdAsync(Id);

                if (result.Success)
                {
                    return Ok(result.Message);
                }

                return BadRequest(result.Message);              
                
            }
        }


        [HttpGet("GetAllAsync")]

        public async Task<IActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                IDataResult<IList<ChartType>> result = await _service.GetEntityValuesAsync();
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetByIdAsync/{id:int}")]

        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {

                IDataResult<ChartType> result = await _service.FindByIdAsync(Id);

                if (result.Success)
                    return Ok(result.Data);

                return BadRequest(result.Message);
            }

        }
        #endregion
    }
}
