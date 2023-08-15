using DNQT.BackendApi.Services;
using DNQT.ToolCommon.ListStringApi;
using DNQT.ViewModels.Admin.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNQT.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService iService)
        {
            _loginService = iService;
        }

        //Link api: api/Login/TARAuthenticate
        [HttpPost(STR_URI_Login.TARAuthenticate.STR)]
        [AllowAnonymous]
        public IActionResult TARAuthenticate([FromBody] LoginRequest_ViewModel mRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string strJsonDictionary = _loginService.StrJsonAuthencate(mRequest);
            return Ok(strJsonDictionary);
        }

    }
}
