using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OneBoard.Business.Abstract;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.User;
using OneBoard.Entities.Mapping.UserMap;

namespace OneBoard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private IMapper _mapper;

        public UserController(IUserService service , IMapper mapper)
        {
            this._userService = service;
            this._mapper = mapper;
        }
        //only having token
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            IEnumerable<Claim> claims = User.Claims;
            //getting claim tokens
            //new Claim(ClaimType,Value);
            string userId = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            IDataResult<User> result = await _userService.FindByIdAsync(Convert.ToInt32(userId));

            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
        //all
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO userDTO)
        {
            _mapper = UserMapping.GetMapper().CreateMapper();

            User user = _mapper.Map<UserDTO, User>(userDTO);
            IResult result = await _userService.AddUser(user);
            if (result.Success)
                return Ok($"{result.Message} : Data :{JsonConvert.SerializeObject(user)}");
            else
                return BadRequest(result.Message);
        }

    }
}