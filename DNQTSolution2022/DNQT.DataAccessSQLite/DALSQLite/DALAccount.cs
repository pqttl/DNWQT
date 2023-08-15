using DNQT.ToolCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace DNQT.DataAccessSQLite.DALSQLite
{
    public class DALAccount: DALBase
	{

  //      public DALAccount()
  //      {

		//}

		public void AddAccount(ref Dictionary<string, object> dicOutput, ref Exception exOutput
		  , Dictionary<string, object> dicInput)
		{
			try
			{
				int intMaxIdCurrent = -1;
				GetMaxIdFromTable(ref intMaxIdCurrent, "Id", "BangAccount");

				using (var con = new SQLiteConnection(StrConnectionString))
				{
					var lstColName = new List<string>();
					//var cmSql = new SQLiteCommand(strQuery,con);
					var cmSql = new SQLiteCommand(con);
					{
						string strColName = "Id";
						lstColName.Add(strColName);
						cmSql.Parameters.Add("@" + strColName, DbType.Int32).Value = intMaxIdCurrent + 1;
					}
					{
						string strColName = "Username";
						lstColName.Add(strColName);
						string objTemp = dicInput["string.strUserName"] as string;
						cmSql.Parameters.Add("@" + strColName, DbType.String).Value = objTemp;
					}
					{
						string strColName = "Password";
						lstColName.Add(strColName);
						string objTemp = dicInput["string.strPassword"] as string;
						cmSql.Parameters.Add("@" + strColName, DbType.String).Value = objTemp;
					}
					{
						string strColName = "IsDeleted";
						lstColName.Add(strColName);
						cmSql.Parameters.Add("@" + strColName, DbType.Int32).Value = 0;
					}
					{
						string strColName = "CreateTime";
						lstColName.Add(strColName);
						cmSql.Parameters.Add("@" + strColName, DbType.String).Value = 
							DateTime.Now.ToString(QTFormat.STR_DATETIME_SQLITE.STR);
					}
					{
						string strColName = "ModifyTime";
						lstColName.Add(strColName);
						cmSql.Parameters.Add("@" + strColName, DbType.String).Value = 
							DateTime.Now.ToString(QTFormat.STR_DATETIME_SQLITE.STR);
					}

					string strQuery = "";
					//		strQuery+="\n"+@"Insert into BangAccount"
					//+"(Id,Username,Password,IsDeleted,CreateTime,ModifyTime) "
					//+" values (@Id,@Username,@Password,@IsDeleted,@CreateTime,@ModifyTime);";
					CreateQueryInsert(ref strQuery, "BangAccount", lstColName);

					cmSql.CommandText = strQuery;

					cmSql.ExecuteNonQuery();

				}

			}
			catch (Exception ex)
			{
				dicOutput["string"] = ex.ToString();
				exOutput = ex;
			}
		}

		public void GetDtAccountGiaHanByUserPass(ref DataTable dtOutput, ref Exception exOutput
		  , Dictionary<string, object> dicInput)
		{
			try
			{

				using (var con = new SQLiteConnection(StrConnectionString))
				{
					con.Open();
					var cmSql = new SQLiteCommand(con);
					{
						string strColName = "Username";
						string objTemp = dicInput["string.strUserName"] as string;
						cmSql.Parameters.Add("@" + strColName, DbType.String).Value = objTemp;
					}
					{
						string strColName = "Password";
						string objTemp = dicInput["string.strPassword"] as string;
						cmSql.Parameters.Add("@" + strColName, DbType.String).Value = objTemp;
					}

					string strQuery = "";
					strQuery += "\n" + @"SELECT BangAccount.Id,BangAccount.Username,BangAccount.IsDeleted "
			+ " ,BangGiaHan.StartTimeUse,BangGiaHan.EndTimeUse "
			+ " FROM BangAccount BangAccount LEFT JOIN BangGiaHan BangGiaHan "
			+ " ON BangGiaHan.IdAccount=BangAccount.Id "
			+ " WHERE BangAccount.Username=@Username AND BangAccount.Password=@Password;";

					cmSql.CommandText = strQuery;

					//cmSql.ExecuteNonQuery();
					SQLiteDataReader reader = cmSql.ExecuteReader();
					var dtTemp = new DataTable();
					try
					{
						dtTemp.Load(reader);

						GetDataTableWithChangeTypeColumnDateTime(ref dtOutput, dtTemp, new List<string>() {
		  "StartTimeUse","EndTimeUse"});
					}
					catch (Exception e)
					{
						string str = e.Message;
					}

				}
			}
			catch (Exception ex)
			{
				exOutput = ex;
			}
		}

	}
}
