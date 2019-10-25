using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneBoard.Core.Business;
using OneBoard.Core.Helper;
using OneBoard.Core.Utilities.Extensions;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Core.Utilities.Security.Token;
using OneBoard.Entities.DTO.User;

namespace OneBoard.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService<AccessToken> _iAuthenticationService;

        public LoginController(IAuthenticationService<AccessToken> authenticationService)
        {
            this._iAuthenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> AccessToken(LoginUserDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            else
            {
                //loginDTO.Password = EncryptionPassword.Encrypt(loginDTO.Password);
                IDataResult<AccessToken> result = await _iAuthenticationService.CreateAccessToken(loginDTO.LoginName, loginDTO.Password);

                if (result.Success)
                    return Ok(result.Data);
                else
                    return BadRequest(result.Message);
            }
               
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenDTO refreshTokenDTO)
        {
           IDataResult<AccessToken> result = await _iAuthenticationService.CreateAccessTokenWithRefreshToken(refreshTokenDTO.RefreshToken);

            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDTO refreshTokenDTO)
        {
           IDataResult<AccessToken> result = await _iAuthenticationService.RevokeRefreshToken(refreshTokenDTO.RefreshToken);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}