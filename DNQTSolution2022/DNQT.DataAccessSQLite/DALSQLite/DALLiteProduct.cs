using DNQT.ToolCommon.ListTableDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace DNQT.DataAccessSQLite.DALSQLite
{
	public class DALLiteProduct : DALBase
	{
        private readonly BLLQuery _bllQuery = new BLLQuery();

        public void GetDTAllIdProduct(ref DataTable dtOutput, ref Exception exOutput
			, List<string> lstStringName)
		{
			try
			{
				string strQuery = "";
				_bllQuery.GetQueryLayAllProductByListName(ref strQuery, lstStringName);

				//GetDataTableFromQuery(ref dtOutput, "BangViThuoc"
				//	, "SELECT MaViThuoc,TenViThuoc FROM BangViThuoc ORDER BY TenViThuoc ;");
				GetDataTableFromQueryWithoutTableName(ref dtOutput
					, strQuery);
				//GetDataTableFromQuery(ref dtOutput,"BangViThuoc"
				//	,"SELECT MaViThuoc,TenViThuoc FROM BangViThuoc ORDER BY TenViThuoc  COLLATE UNICODE ;");
			}
			catch (Exception ex)
			{
				exOutput = ex;
			}
		}

		public void GetDTAllIdProductLeftJoinDepot(ref DataTable dtOutput, ref Exception exOutput)
		{
			try
			{
				string strOrderBy = " order by tblThuoc.TenViThuoc ";

				string strQuery = "";
				strQuery = @"SELECT tblDepot.Id, tblThuoc.MaViThuoc, tblThuoc.TenViThuoc, tblDepot.QuantityCurrent, tblDepot.DonVi, tblDepot.ModifiedDate, tblDepot.MinQuantity 
FROM BangViThuoc tblThuoc 
LEFT JOIN TblListProductInDepot tblDepot on tblThuoc.MaViThuoc=tblDepot.MaViThuoc " + strOrderBy;
				//_bllQuery.GetQueryLayAllIdProduct(ref strQuery);

				//var dtTemp = new DataTable();
				//GetDataTableFromQueryWithoutTableName(ref dtTemp,strQuery);
				//GetDataTableWithChangeTypeColumnDateTime(ref dtOutput,dtTemp,new List<string>() {
				//  "ModifiedDate"});

				GetDataTableFromQueryWithoutTableName(ref dtOutput, strQuery);
				ChangeTypeColumnDateTime(ref dtOutput, new List<string>() {
		  "ModifiedDate"});
			}
			catch (Exception ex)
			{
				exOutput = ex;
			}
		}

		public void GetDTIdNewByInsertNameProduct(ref DataTable dtOutput, ref Exception exOutput
		  , string strName)
		{
			try
			{
				int intMaxIdCurrent = -1;
				GetMaxIdFromTable(ref intMaxIdCurrent, "MaViThuoc", "BangViThuoc");

				using (var con = new SQLiteConnection(StrConnectionString))
				{
					con.Open();
					InsertBangViThuoc(con, intMaxIdCurrent + 1, strName, "", 0);
				}

				dtOutput = new DataTable();
				DataColumn dcNew = new DataColumn(Table_BangViThuoc.Col_MaViThuoc.NAME, typeof(Int32));
				dtOutput.Columns.Add(dcNew);

				DataRow dr = dtOutput.NewRow();
				dr[0] = intMaxIdCurrent + 1;
				dtOutput.Rows.Add(dr);

			}
			catch (Exception ex)
			{
				exOutput = ex;
			}
		}

		private void InsertBangViThuoc(SQLiteConnection con, int intIdNew, string strName, string strGhiChu
		  , int intIsDeleted)
		{
			var lstColName = new List<string>();
			var cmSql = new SQLiteCommand(con);
			{
				string strColName = "MaViThuoc";
				lstColName.Add(strColName);
				cmSql.Parameters.Add("@" + strColName, DbType.Int32).Value = intIdNew;
			}
			{
				string strColName = "TenViThuoc";
				lstColName.Add(strColName);
				cmSql.Parameters.Add("@" + strColName, DbType.String).Value = strName;
			}
			{
				string strColName = "GhiChuViThuoc";
				lstColName.Add(strColName);
				cmSql.Parameters.Add("@" + strColName, DbType.String).Value = strGhiChu;
			}
			{
				string strColName = "IsDeleted";
				lstColName.Add(strColName);
				cmSql.Parameters.Add("@" + strColName, DbType.Int32).Value = intIsDeleted;
			}

			string strQuery = "";
			CreateQueryInsert(ref strQuery, "BangViThuoc", lstColName);

			cmSql.CommandText = strQuery;

			cmSql.ExecuteNonQuery();

		}

	}
}
