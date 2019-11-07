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
using OneBoard.Entities.DTO.UserGroup;
using OneBoard.Entities.Mapping.UserGroupMap;

namespace OneBoard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private IUserGroupService _iUserGroupService;
        private IMapper _iMapper;

        public UserGroupController(IUserGroupService userGroupService, IMapper mapper)
        {
            _iUserGroupService = userGroupService;
            _iMapper = mapper;
        }

        #region NORMAL
        [HttpPost("Add")]
        public IActionResult Add(UserGroupDTO UserGroupDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                _iMapper = UserGroupMapping.GetMapper().CreateMapper();
                UserGroup userGroup = _iMapper.Map<UserGroupDTO, UserGroup>(UserGroupDTO);

                IResult result = _iUserGroupService.Add(userGroup);

                if (result.Success)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }

        }

        [HttpPut("Update")]
        public IActionResult Update(UserGroupDTO userGroupDTO, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                IDataResult<UserGroup> result = _iUserGroupService.GetById(Id);
                if (result == null)
                    return BadRequest(result.Message);
                else
                {
                    _iMapper = UserGroupMapping.GetMapper().CreateMapper();
                    UserGroup userGroup = _iMapper.Map<UserGroupDTO, UserGroup>(userGroupDTO);

                    IResult updateResult = _iUserGroupService.Update(userGroup);

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
                IDataResult<UserGroup> result = _iUserGroupService.GetById(Id);
                if (result == null)
                    return BadRequest(result.Message);
                else
                {
                    IResult deleteResult = _iUserGroupService.Delete(result.Data);
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
            IDataResult<IList<UserGroup>> result = _iUserGroupService.GetEntityValues();

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }


        #endregion

        #region Async
        [HttpGet(template: "getListAsync")]
        public async Task<IActionResult> GetListAsync()
        {
            IDataResult<IList<UserGroup>> result = await _iUserGroupService.GetEntityValuesAsync();

            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getByIdAsync/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            IDataResult<UserGroup> result = await _iUserGroupService.FindByIdAsync(id);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);

        }

        [HttpPost(template: "addAsync")]
        public async Task<IActionResult> AddAsync(UserGroupDTO userGroupDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                _iMapper = UserGroupMapping.GetMapper().CreateMapper();

                UserGroup userGroup = _iMapper.Map<UserGroupDTO, UserGroup>(userGroupDTO);

                IResult result = await _iUserGroupService.AddAsync(userGroup);

                if (result.Success)
                    return Ok(result.Message);
                return BadRequest($"{result.Message} \n Try Again later can be either server error or user error ");
            }
        }

        [HttpPut(template: "updateAsync/{id:int}")]
        public async Task<IActionResult> UpdateAsync(UserGroupDTO userGroupDTO, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                IDataResult<UserGroup> dataResult = await _iUserGroupService.FindByIdAsync(Id);
                if (dataResult.Data == null)
                    return BadRequest(dataResult.Message);
                _iMapper = UserGroupMapping.GetMapper().CreateMapper();

                UserGroup userGroup= _iMapper.Map<UserGroupDTO, UserGroup>(userGroupDTO);

                IResult result = await _iUserGroupService.UpdateAsync(userGroup);
                if (result.Success)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }

        }

        [HttpDelete(template: "deleteAsync/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var result = await _iUserGroupService.DeleteByIdAsync(Id);
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