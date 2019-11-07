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
using OneBoard.Entities.DTO.Group;
using OneBoard.Entities.Mapping.GroupMap;

namespace OneBoard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _service;
        private IMapper _mapper;

        public GroupController(IGroupService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        #region normal

        [HttpPost("Add")]
        public IActionResult Add(GroupDTO groupDto)
        {
            _mapper = GroupMapping.GetMapper().CreateMapper();
            Group group = _mapper.Map<GroupDTO, Group>(groupDto);
            var result = _service.Add(group);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Success.ToString() + " and  " + result.Message);
        }

        [HttpPut("Update")]
        public IActionResult Update(GroupDTO groupDto)
        {
            _mapper = GroupMapping.GetMapper().CreateMapper();
            Group group = _mapper.Map<GroupDTO, Group>(groupDto);
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

            return BadRequest(result.Success.ToString() + " and  " + result.Message);
        }

        #endregion

        #region async
        [HttpPost(template: "addfirmAsync")]
        public async Task<IActionResult> AddFirmAsync(GroupDTO groupDtO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {

                _mapper = GroupMapping.GetMapper().CreateMapper();
                Group group = _mapper.Map<GroupDTO, Group>(groupDtO);
                var GroupResult = await _service.AddAsync(group);
                if (GroupResult.Success)
                {
                    return Ok(GroupResult.Message);
                }
                else
                {
                    return BadRequest(GroupResult.Message);
                }
            }
        }

        [HttpPut(template: "updateFirmAsync/{id:int}")]
        public async Task<IActionResult> UpdateFirmAsync(GroupDTO groupDtO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {

                _mapper = GroupMapping.GetMapper().CreateMapper();
                Group group = _mapper.Map<GroupDTO, Group>(groupDtO);
                var GroupResult = await _service.UpdateAsync(group);
                if (GroupResult.Success)
                {
                    return Ok(GroupResult.Message);
                }
                else
                {
                    return BadRequest(GroupResult.Message);
                }
            }
        }
        [HttpDelete(template: "deleteFirmAsync/{id:int}")]
        public async Task<IActionResult> DeleteFirmAsync(int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                var GroupResult = await _service.DeleteByIdAsync(Id);
                if (GroupResult.Success)
                {
                    return Ok(GroupResult.Message);
                }
                else
                {
                    return BadRequest(GroupResult.Message);
                }
            }
        }

        [HttpGet(template: "getListAsync")]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
              IDataResult<IList<Group>> GroupResult=await _service.GetEntityValuesAsync();
              if (GroupResult.Success)
              {
                 return Ok(GroupResult.Message);
              }
              else
              {
                 return BadRequest(GroupResult.Message);
              }
            }
        }
    
        [HttpGet(template: "getByIdAsync/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                IDataResult<Group> GroupResult = await _service.FindByIdAsync(Id);
                if (GroupResult.Success)
                {
                    return Ok(GroupResult.Message);
                }
                else
                {
                    return BadRequest(GroupResult.Message);
                }
            }
        }



        #endregion
    }


}