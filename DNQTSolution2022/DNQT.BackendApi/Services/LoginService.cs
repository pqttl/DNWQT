using DNQT.DataAccessSQLite.DALSQLite;
using DNQT.ViewModels.Admin.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DNQT.BackendApi.Services
{
    public class LoginService : ILoginService
    {
        private readonly DALAccount DAL_Account = new DALAccount();
        private readonly BLLProject _bllPlugin = new BLLProject();
        private readonly IConfiguration _iConfig;

        public LoginService(IConfiguration config)
        {
            _iConfig = config;
        }

        public string StrJsonAuthencate(LoginRequest_ViewModel mRequest)
        {

            var dicInput = new Dictionary<string, object>();
            dicInput["string.strUserName"] = mRequest.StrUserName;
            dicInput["string.strPassword"] = _bllPlugin.Base64Encode(mRequest.StrPassword);

            var dicOutput = new Dictionary<string, object>();
            DataTable dtOutput = null;
            {
                Exception exOutput = null;
                DAL_Account.GetDtAccountGiaHanByUserPass(ref dtOutput, ref exOutput, dicInput);
                dicOutput["DataTable"] = dtOutput;
                if (exOutput != null)
                {
                    //Log4Net.Error(exOutput.Message);
                    //Log4Net.Error(exOutput.StackTrace);
                    //ShowException(exOutput);
                    //return;
                    dicOutput["Exception"] = exOutput;
                }
            }

            //var user = await _userManager.FindByNameAsync(request.UserName);
            //if (user == null) return null;

            //var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            //if (!result.Succeeded)
            //{
            //	return null;
            //}
            //var roles = await _userManager.GetRolesAsync(user);

            var claims = new[]
            {
				//new Claim(ClaimTypes.Email,user.Email),
				//new Claim(ClaimTypes.GivenName,user.FirstName),
				//new Claim(ClaimTypes.Role, string.Join(";",roles)),
				new Claim(ClaimTypes.Name, mRequest.StrUserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iConfig["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_iConfig["Tokens:Issuer"],
                _iConfig["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            string strJwtTokenForLogin = new JwtSecurityTokenHandler().WriteToken(token);

            dicOutput["string.strJwtTokenForLogin"] = strJwtTokenForLogin;
            string strJsonDictionary = JsonConvert.SerializeObject(dicOutput
                  , Formatting.Indented);
            return strJsonDictionary;
        }
    }
}
