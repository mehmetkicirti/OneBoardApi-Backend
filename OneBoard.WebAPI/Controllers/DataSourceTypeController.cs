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
using OneBoard.Entities.DTO.DataSourceType;
using OneBoard.Entities.Mapping.DataSourceTypeMap;

namespace OneBoard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSourceTypeController : ControllerBase
    {
        private IDataSourceTypeService _iDataSourceTypeService;
        private IMapper _iMapper;

        public DataSourceTypeController(IDataSourceTypeService dataSourceTypeService, IMapper mapper)
        {
            _iDataSourceTypeService = dataSourceTypeService;
            _iMapper = mapper;
        }

        #region NORMAL
        [HttpPost("Add")]
        public IActionResult Add(DataSourceTypeDTO dataSourceDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                _iMapper = DataSourceTypeMapping.GetMapper().CreateMapper();
                DataSourceType dataSource = _iMapper.Map<DataSourceTypeDTO, DataSourceType>(dataSourceDTO);

                IResult result = _iDataSourceTypeService.Add(dataSource);

                if (result.Success)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }

        }

        [HttpPut("Update")]
        public IActionResult Update(DataSourceTypeDTO dataSourceTypeDTO, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                IDataResult<DataSourceType> result = _iDataSourceTypeService.GetById(Id);
                if (result == null)
                    return BadRequest(result.Message);
                else
                {
                    _iMapper = DataSourceTypeMapping.GetMapper().CreateMapper();
                    DataSourceType dataSource = _iMapper.Map<DataSourceTypeDTO, DataSourceType>(dataSourceTypeDTO);

                    IResult updateResult = _iDataSourceTypeService.Update(dataSource);

                    if (updateResult.Success)
                        return Ok(updateResult.Message);
                    return BadRequest(updateResult.Message);
                }
            }
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult Delete(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                IDataResult<DataSourceType> result = _iDataSourceTypeService.GetById(Id);
                if (result == null)
                    return BadRequest(result.Message);
                else
                {
                    IResult deleteResult = _iDataSourceTypeService.Delete(result.Data);
                    if (deleteResult.Success)
                        return Ok(deleteResult.Message);
                    else
                        return BadRequest(deleteResult.Message);
                }
            }
        }
        [HttpGet(template: "GetAll")]
        public IActionResult GetAll()
        {
            IDataResult<IList<DataSourceType>> result = _iDataSourceTypeService.GetEntityValues();

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }


        #endregion

        #region Async
        [HttpGet(template: "getListAsync")]
        public async Task<IActionResult> GetListAsync()
        {
            IDataResult<IList<DataSourceType>> result = await _iDataSourceTypeService.GetEntityValuesAsync();

            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getByIdAsync/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            IDataResult<DataSourceType> result = await _iDataSourceTypeService.FindByIdAsync(id);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);

        }

        [HttpPost(template: "addAsync")]
        public async Task<IActionResult> AddAsync(DataSourceTypeDTO dataSourceTypeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                _iMapper = DataSourceTypeMapping.GetMapper().CreateMapper();

                DataSourceType dataSourceType = _iMapper.Map<DataSourceTypeDTO, DataSourceType>(dataSourceTypeDTO);

                IResult result = await _iDataSourceTypeService.AddAsync(dataSourceType);

                if (result.Success)
                    return Ok(result.Message);
                return BadRequest($"{result.Message} \n Try Again later can be either server error or user error ");
            }
        }

        [HttpPut(template: "updateAsync/{id:int}")]
        public async Task<IActionResult> UpdateAsync(DataSourceTypeDTO dataSourceTypeDTO, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                IDataResult<DataSourceType> dataResult = await _iDataSourceTypeService.FindByIdAsync(Id);
                if (dataResult.Data == null)
                    return BadRequest(dataResult.Message);
                _iMapper = DataSourceTypeMapping.GetMapper().CreateMapper();

                DataSourceType dataSourceType = _iMapper.Map<DataSourceTypeDTO, DataSourceType>(dataSourceTypeDTO);

                IResult result = await _iDataSourceTypeService.UpdateAsync(dataSourceType);
                if (result.Success)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }

        }

        [HttpDelete(template: "deleteAsync/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var result = await _iDataSourceTypeService.DeleteByIdAsync(Id);
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
    }
}