using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace App_Code
{
    public class Summary
    {
        #region Methods
        public static DataTable SummaryAll(int start_year, int end_year)
        {
            string strStoredProcedureName = "sp_rep_StatsAll";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@start_year", start_year));
            param.Add(new SqlParameter("@end_year", end_year));

            DataTable dt = DbAccess.ExecuteQuery(strStoredProcedureName, CommandType.StoredProcedure, param);

            return dt;
        }
        #endregion
    }
}