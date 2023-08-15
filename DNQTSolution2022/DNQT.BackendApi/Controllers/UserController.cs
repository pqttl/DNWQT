using DNQT.BackendApi.Services;
using DNQT.ToolCommon.ListStringApi;
using DNQT.ViewModels.Admin.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNQT.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _iService;

        public UserController(IUserService iService)
        {
            _iService = iService;
        }

        //Link api: api/Login/TARAuthenticate
        [HttpPost(nameof(TARInsertUser))]
        [AllowAnonymous]
        public IActionResult TARInsertUser([FromBody] CreateUser_ViewModel mRequest)
        {
            string strTemp = STR_URI_User.TARInsertUser.STR;
            if (strTemp == "")  return null;//Dùng để Go to Definition đến BackendApi cho nhanh

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var strResultToken = _iService.TStrAuthencate(mRequest);
            if (!string.IsNullOrEmpty(strResultToken))
            {
                return BadRequest("Thao tác không thành công!\n"+ strResultToken);
            }
            return Ok(strResultToken);
        }

    }
}
