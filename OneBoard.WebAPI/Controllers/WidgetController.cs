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
using OneBoard.Entities.DTO.Widget;
using OneBoard.Entities.Mapping.WidgetMap;

namespace OneBoard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetController : ControllerBase
    {
        private IWidgetService _iWidgetService;
        private IMapper _iMapper;

        public WidgetController(IWidgetService widgetService, IMapper mapper)
        {
            _iWidgetService = widgetService;
            _iMapper = mapper;
        }

        #region NORMAL
        [HttpPost("Add")]
        public IActionResult Add(WidgetDTO widgetDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                _iMapper = WidgetMapping.GetMapper().CreateMapper();
                Widget widget = _iMapper.Map<WidgetDTO, Widget>(widgetDTO);

                IResult result = _iWidgetService.Add(widget);

                if (result.Success)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }

        }

        [HttpPut("Update")]
        public IActionResult Update(WidgetDTO widgetDTO, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                IDataResult<Widget> result = _iWidgetService.GetById(Id);
                if (result == null)
                    return BadRequest(result.Message);
                else
                {
                    _iMapper = WidgetMapping.GetMapper().CreateMapper();
                    Widget widget = _iMapper.Map<WidgetDTO, Widget>(widgetDTO);

                    IResult updateResult = _iWidgetService.Update(widget);

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
                IDataResult<Widget> result = _iWidgetService.GetById(Id);
                if (result == null)
                    return BadRequest(result.Message);
                else
                {
                    IResult deleteResult = _iWidgetService.Delete(result.Data);
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
            IDataResult<IList<Widget>> result = _iWidgetService.GetEntityValues();

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }


        #endregion

        #region Async
        [HttpGet(template: "getListAsync")]
        public async Task<IActionResult> GetListAsync()
        {
            IDataResult<IList<Widget>> result = await _iWidgetService.GetEntityValuesAsync();

            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getByIdAsync/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            IDataResult<Widget> result = await _iWidgetService.FindByIdAsync(id);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);

        }

        [HttpPost(template: "addAsync")]
        public async Task<IActionResult> AddAsync(WidgetDTO widgetDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                _iMapper = WidgetMapping.GetMapper().CreateMapper();

                Widget widget = _iMapper.Map<WidgetDTO, Widget>(widgetDTO);

                IResult result = await _iWidgetService.AddAsync(widget);

                if (result.Success)
                    return Ok(result.Message);
                return BadRequest($"{result.Message} \n Try Again later can be either server error or user error ");
            }
        }

        [HttpPut(template: "updateAsync/{id:int}")]
        public async Task<IActionResult> UpdateAsync(WidgetDTO widgetDTO, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                IDataResult<Widget> dataResult = await _iWidgetService.FindByIdAsync(Id);
                if (dataResult.Data == null)
                    return BadRequest(dataResult.Message);
                _iMapper = WidgetMapping.GetMapper().CreateMapper();

                Widget widget= _iMapper.Map<WidgetDTO, Widget>(widgetDTO);

                IResult result = await _iWidgetService.UpdateAsync(widget);
                if (result.Success)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }

        }

        [HttpDelete(template: "deleteAsync/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var result = await _iWidgetService.DeleteByIdAsync(Id);
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