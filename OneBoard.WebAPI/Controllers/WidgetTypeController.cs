using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OneBoard.Business.Abstract;
using OneBoard.Core.Utilities.Extensions;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.WidgetType;
using OneBoard.Entities.Mapping.WidgetTypeMap;

namespace OneBoard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetTypeController : ControllerBase
    {
        private IWidgetTypeService _iWidgetTypeService;
        private IMapper _iMapper;

        public WidgetTypeController(IWidgetTypeService widgetTypeService, IMapper mapper)
        {
            _iWidgetTypeService = widgetTypeService;
            _iMapper = mapper;
        }

        #region NORMAL
        [HttpPost("Add")]
        public IActionResult Add(WidgetTypeDTO widgetTypeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                _iMapper = WidgetTypeMapping.GetMapper().CreateMapper();
                WidgetType widgetType = _iMapper.Map<WidgetTypeDTO, WidgetType>(widgetTypeDTO);

                IResult result = _iWidgetTypeService.Add(widgetType);

                if (result.Success)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }

        }

        [HttpPut("Update")]
        public IActionResult Update(WidgetTypeDTO widgetTypeDTO, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                IDataResult<WidgetType> result = _iWidgetTypeService.GetById(Id);
                if (result == null)
                    return BadRequest(result.Message);
                else
                {
                    _iMapper = WidgetTypeMapping.GetMapper().CreateMapper();
                    WidgetType widgetType = _iMapper.Map<WidgetTypeDTO, WidgetType>(widgetTypeDTO);

                    IResult updateResult = _iWidgetTypeService.Update(widgetType);

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
                IDataResult<WidgetType> result = _iWidgetTypeService.GetById(Id);
                if (result == null)
                    return BadRequest(result.Message);
                else
                {
                    IResult deleteResult = _iWidgetTypeService.Delete(result.Data);
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
            IDataResult<IList<WidgetType>> result = _iWidgetTypeService.GetEntityValues();

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }


        #endregion

        #region Async
        [HttpGet(template: "getListAsync")]
        public async Task<IActionResult> GetListAsync()
        {
            IDataResult<IList<WidgetType>> result = await _iWidgetTypeService.GetEntityValuesAsync();

            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getByIdAsync/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            IDataResult<WidgetType> result = await _iWidgetTypeService.FindByIdAsync(id);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);

        }

        [HttpPost(template: "addAsync")]
        public async Task<IActionResult> AddAsync(WidgetTypeDTO widgetTypeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                _iMapper = WidgetTypeMapping.GetMapper().CreateMapper();

                WidgetType widgetType = _iMapper.Map<WidgetTypeDTO, WidgetType>(widgetTypeDTO);

                IResult result = await _iWidgetTypeService.AddAsync(widgetType);

                if (result.Success)
                    return Ok(result.Message);
                return BadRequest($"{result.Message} \n Try Again later can be either server error or user error ");
            }
        }

        [HttpPut(template: "updateAsync/{id:int}")]
        public async Task<IActionResult> UpdateAsync(WidgetTypeDTO widgetTypeDTO, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                IDataResult<WidgetType> dataResult = await _iWidgetTypeService.FindByIdAsync(Id);
                if (dataResult.Data == null)
                    return BadRequest(dataResult.Message);
                _iMapper = WidgetTypeMapping.GetMapper().CreateMapper();

                WidgetType widgetType = _iMapper.Map<WidgetTypeDTO, WidgetType>(widgetTypeDTO);

                IResult result = await _iWidgetTypeService.UpdateAsync(widgetType);
                if (result.Success)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }

        }

        [HttpDelete(template: "deleteAsync/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var result = await _iWidgetTypeService.DeleteByIdAsync(Id);
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