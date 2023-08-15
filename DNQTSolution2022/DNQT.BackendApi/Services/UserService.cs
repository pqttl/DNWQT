using DNQT.DataAccessSQLite.DALSQLite;
using DNQT.ViewModels.Admin.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DNQT.BackendApi.Services
{
    public class UserService : IUserService
	{
		private readonly DALAccount DAL_Account = new DALAccount();
		private readonly BLLProject _bllPlugin = new BLLProject();

		public string TStrAuthencate(CreateUser_ViewModel mRequest)
		{

			string strUserName = mRequest.StrUserNameAndPass;
			var dicInput = new Dictionary<string, object>();
			dicInput["string.strUserName"] = strUserName;
			dicInput["string.strPassword"] = _bllPlugin.Base64Encode(strUserName);

			{
				var dicOutput = new Dictionary<string, object>();
				Exception exOutput = null;
				//DALAccount.AddAccount(ref dicOutput,ref exOutput,dicInput);
				DAL_Account.AddAccount(ref dicOutput, ref exOutput, dicInput);
				if (exOutput != null)
				{
					//Log4Net.Error(exOutput.Message);
					//Log4Net.Error(exOutput.StackTrace);
					//ShowException(exOutput);
					//return;
					return $"{exOutput.Message}\n{exOutput.StackTrace}";
				}
			}
			return "";
		}
	}
}
