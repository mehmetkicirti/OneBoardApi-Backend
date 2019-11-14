using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneBoard.Business.Abstract;
using OneBoard.Core.Utilities.Extensions;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.DataSource;
using OneBoard.Entities.Mapping.DataSourceMap;

namespace OneBoard.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DataSourceController : ControllerBase
    {
        private IDataSourceService _iDataSourceService;
        private IMapper _iMapper;
        
        public DataSourceController(IDataSourceService dataSourceService, IMapper mapper)
        {
            _iDataSourceService = dataSourceService;
            _iMapper = mapper;
        }

        #region NORMAL
        [HttpPost("Add")]
        public IActionResult Add(DataSourceDTO dataSourceDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                _iMapper = DataSourceMapping.GetMapper().CreateMapper();
                DataSource dataSource = _iMapper.Map<DataSourceDTO, DataSource>(dataSourceDTO);

                IResult result = _iDataSourceService.Add(dataSource);

                if (result.Success)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }

        }

        [HttpPut("Update")]
        public IActionResult Update(DataSourceDTO dataSourceDTO, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                IDataResult<DataSource> result = _iDataSourceService.GetById(Id);
                if (result == null)
                    return BadRequest(result.Message);
                else
                {
                    _iMapper = DataSourceMapping.GetMapper().CreateMapper();
                    DataSource dataSource = _iMapper.Map<DataSourceDTO, DataSource>(dataSourceDTO);

                    IResult updateResult = _iDataSourceService.Update(dataSource);

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
                IDataResult<DataSource> result = _iDataSourceService.GetById(Id);
                if (result == null)
                    return BadRequest(result.Message);
                else
                {
                    IResult deleteResult = _iDataSourceService.Delete(result.Data);
                    if (deleteResult.Success)
                        return Ok(deleteResult.Message);
                    else
                        return BadRequest(deleteResult.Message);
                }
            }
        }
        [HttpGet(template:"GetAll")]
        public IActionResult GetAll()
        {
            IDataResult<IList<DataSource>> result = _iDataSourceService.GetEntityValues();

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }


        #endregion

        #region Async
        [HttpGet(template:"getListAsync")]
        public async Task<IActionResult> GetListAsync()
        {
            IDataResult<IList<DataSource>> result = await _iDataSourceService.GetEntityValuesAsync();

            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet(template:"getByIdAsync/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            IDataResult<DataSource> result = await _iDataSourceService.FindByIdAsync(id);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
            
        }

        [HttpPost(template:"addAsync")]
        public async Task<IActionResult> AddAsync(DataSourceDTO dataSourceDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                _iMapper = DataSourceMapping.GetMapper().CreateMapper();

                DataSource dataSource = _iMapper.Map<DataSourceDTO, DataSource>(dataSourceDTO);

                IResult result = await _iDataSourceService.AddAsync(dataSource);

                if (result.Success)
                    return Ok(result.Message);
                return BadRequest($"{result.Message} \n Try Again later can be either server error or user error ");
            }
        }

        [HttpPut(template:"updateAsync/{id:int}")]
        public async Task<IActionResult> UpdateAsync(DataSourceDTO dataSourceDTO, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                IDataResult<DataSource> dataResult = await _iDataSourceService.FindByIdAsync(Id);
                if (dataResult.Data == null)
                    return BadRequest(dataResult.Message);
                _iMapper = DataSourceMapping.GetMapper().CreateMapper();

                DataSource dataSource = _iMapper.Map<DataSourceDTO, DataSource>(dataSourceDTO);
                 
                IResult result  = await _iDataSourceService.UpdateAsync(dataSource);
                if (result.Success)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }
            
        }

        [HttpDelete(template: "deleteAsync/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var result = await _iDataSourceService.DeleteByIdAsync(Id);
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