
using App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Models
{
    public partial class Publication_ISI
    {
        #region Fields
        public static string Paper_Title ="Paper_Title";
        public static string Source ="Source";
        public static string Language ="Language";
        public static string Abstract ="Abstract";
        public static string Document_Type ="Document_Type";
        public static string Conference_Title ="Conference_Title";
        public static string Conference_Dates ="Conference_Dates";
        public static string Conference_Location ="Conference_Location";
        public static string Keywords ="Keywords";
        public static string Authors_Address ="Authors_Address";
        public static string Reprint_Address ="Reprint_Address";
        public static string Funding_Agency ="Funding_Agency";
        public static string Funding_Text ="Funding_Text";
        public static string Time_Cited ="Time_Cited";
        public static string Publisher ="Publisher";
        public static string ISSN ="ISSN";
        public static string Publication_Date ="Publication_Date";
        public static string Publication_Month ="Publication_Month";
        public static string Publication_Year ="Publication_Year";
        public static string Volume ="Volume";
        public static string Issue ="Issue";
        public static string Wide_Category ="Wide_Category";
        public static string Subject_Category ="Subject_Category";
        public static string Impact_Factor_Last_Year ="Impact_Factor_Last_Year";
        public static string Impact_Factor_Publication_Year ="Impact_Factor_Publication_Year";
        public static string QClass ="QClass";
        public static string CreatedOn ="CreatedOn";
        public static string CreatedBy ="CreatedBy";
        public static string UpdatedOn ="UpdatedOn";
        public static string UpdatedBy ="UpdatedBy";
        public static string Active_flag ="Active_flag";
        public static string Deleted_flag ="Deleted_flag";

        #endregion
    }

    public partial class Publication_ISIController
    {
        #region Fields
        public int Publication_ISI_ID { get; set; }
        public string ISI_Category { get; set; }
        public string WOS_Number { get; set; }
        public string Authors { get; set; }
        public string Paper_Title { get; set; }
        public string Source { get; set; }
        public string Language { get; set; }
        public string Abstract { get; set; }
        public string Document_Type { get; set; }
        public string Conference_Title { get; set; }
        public string Conference_Dates { get; set; }
        public string Conference_Location { get; set; }
        public string Keywords { get; set; }
        public string Authors_Address { get; set; }
        public string Reprint_Address { get; set; }
        public string Funding_Agency { get; set; }
        public string Funding_Text { get; set; }
        public int? Time_Cited { get; set; }
        public string Publisher { get; set; }
        public string ISSN { get; set; }
        public DateTime? Publication_Date { get; set; }
        public string Publication_Month { get; set; }
        public int? Publication_Year { get; set; }
        public string Volume { get; set; }
        public string Issue { get; set; }
        public string Wide_Category { get; set; }
        public string Subject_Category { get; set; }
        public string Impact_Factor_Last_Year { get; set; }
        public string Impact_Factor_Publication_Year { get; set; }
        public string QClass { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public bool? Active_flag { get; set; }
        public bool? Deleted_flag { get; set; }
        #endregion

        #region Methods

        #region List
        public static List<Publication_ISIController> getISIPublicationsAll()
        {
            string strStoredProcedureName = "sp_getAllISIPublications";                        

            DataTable dt = DbAccess.ExecuteQuery(strStoredProcedureName, CommandType.StoredProcedure);

            return helper(dt);
        }

        public static List<Publication_ISIController> getISIPublicationsByFaculty(int id)
        {
            string strStoredProcedureName = "sp_rep_getISIPublicationsByFaculty";

            SqlParameter param = (new SqlParameter("@id", id));

            DataTable dt = DbAccess.ExecuteQuery(strStoredProcedureName, CommandType.StoredProcedure, param);

            return helper(dt);
        }

        public static List<Publication_ISIController> getISIPublicationsByCollege(string college_code)
        {
            string strStoredProcedureName = "sp_rep_getISIPublicationsByCollege";

            SqlParameter param = (new SqlParameter("@college_code", college_code));

            DataTable dt = DbAccess.ExecuteQuery(strStoredProcedureName, CommandType.StoredProcedure, param);

            return helper(dt);
        }
        public static List<Publication_ISIController> getISIPublicationsByDepartment(string dept_code)
        {
            string strStoredProcedureName = "sp_rep_getISIPublicationsByDepartment";

            SqlParameter param = (new SqlParameter("@dept_code", dept_code));

            DataTable dt = DbAccess.ExecuteQuery(strStoredProcedureName, CommandType.StoredProcedure, param);

            return helper(dt);
        }

        public static List<string> GetDistinctISIDocumentTypes()
        {
            string strStoredProcedureName = "sp_rep_GetDistinctISIDocumentTypes";

            DataTable dt = DbAccess.ExecuteQuery(strStoredProcedureName, CommandType.StoredProcedure);

            List<string> list = dt.AsEnumerable()
                           .Select(r => r.Field<string>("Document_Type"))
                           .ToList();

            return list;
        }

        public static List<Publication_ISIController> GetAllISIPublicationsForAllDocTypes()
        {
            string strStoredProcedureName = "sp_rep_GetAllISIPublicationsForAllDocTypes";

            DataTable dt = DbAccess.ExecuteQuery(strStoredProcedureName, CommandType.StoredProcedure);

            return helper(dt);           
        }

        public static DataTable getStatsForISIPublicationsByFaculty(int id)
        {
            string strStoredProcedureName = "sp_rep_getStatsForISIPublicationsByFaculty";

            SqlParameter param = (new SqlParameter("@id", id));

            DataTable dt = DbAccess.ExecuteQuery(strStoredProcedureName, CommandType.StoredProcedure, param);

            return dt;
        }
        public static DataTable getStatsForISIPublications()
        {
            string strStoredProcedureName = "sp_rep_getStatsForISIPublications";            

            DataTable dt = DbAccess.ExecuteQuery(strStoredProcedureName, CommandType.StoredProcedure);

            return dt;
        }
        public static DataTable getStatsForISIPublicationsByCollege(string college_code)
        {
            string strStoredProcedureName = "sp_rep_getStatsForISIPublicationsByCollege";

            SqlParameter param = (new SqlParameter("@college_code", college_code));
            DataTable dt = DbAccess.ExecuteQuery(strStoredProcedureName, CommandType.StoredProcedure, param);

            return dt;
        }
        public static DataTable getStatsForISIPublicationsByDepartment(string dept_code)
        {
            string strStoredProcedureName = "sp_rep_getStatsForISIPublicationsByDepartment";

            SqlParameter param = (new SqlParameter("@dept_code", dept_code));

            DataTable dt = DbAccess.ExecuteQuery(strStoredProcedureName, CommandType.StoredProcedure, param);

            return dt;
        }
        #endregion

        #region Stats

        public static DataTable GetStatsForISIPublicationsForAllDocTypesAllCollegesAllYears()
        {
            string strStoredProcedureName = "sp_rep_GetStatsForISIPublicationsForAllDocTypesAllCollegesAllYears";

            DataTable dt = DbAccess.ExecuteQuery(strStoredProcedureName, CommandType.StoredProcedure);

            return dt;
        }

        public static DataTable GetStatsForISIPublicationsForAllDocTypesSingleCollegeAllYears(string college_code)
        {
            string strStoredProcedureName = "sp_rep_GetStatsForISIPublicationsForAllDocTypesSingleCollegeAllYears";

            SqlParameter param = (new SqlParameter("@college_code", college_code));

            DataTable dt = DbAccess.ExecuteQuery(strStoredProcedureName, CommandType.StoredProcedure, param);

            return dt;
        }

        public static DataTable GetStatsForISIPublicationsForAllDocTypesSingleDepartmentAllYears(string dept_code)
        {
            string strStoredProcedureName = "sp_rep_GetStatsForISIPublicationsForAllDocTypesSingleDepartmentAllYears";

            SqlParameter param = (new SqlParameter("@dept_code", dept_code));

            DataTable dt = DbAccess.ExecuteQuery(strStoredProcedureName, CommandType.StoredProcedure, param);

            return dt;
        }
        #endregion

        #endregion

        #region Helper

        private static List<Publication_ISIController> helper(DataTable dt)
        {
            var list = dt.AsEnumerable()
                .Select(dr =>
                new Publication_ISIController
                {
                    Publication_ISI_ID = Convert.ToInt32(dr.Field<int>("Publication_ISI_ID")),
                    ISI_Category = dr.Field<string>("ISI_Category"),
                    WOS_Number = dr.Field<string>("WOS_Number"),
                    Authors = dr.Field<string>("Authors"),
                    Paper_Title = dr.Field<string>("Paper_Title"),
                    Source = dr.Field<string>("Source"),
                    Language = dr.Field<string>("Language"),
                    Abstract = dr.Field<string>("Abstract"),
                    Document_Type = dr.Field<string>("Document_Type"),
                    Conference_Title = dr.Field<string>("Conference_Title"),
                    Conference_Dates = dr.Field<string>("Conference_Dates"),
                    Conference_Location = dr.Field<string>("Conference_Location"),
                    Keywords = dr.Field<string>("Keywords"),
                    Authors_Address = dr.Field<string>("Authors_Address"),
                    Reprint_Address = dr.Field<string>("Reprint_Address"),
                    Funding_Agency = dr.Field<string>("Funding_Agency"),
                    Funding_Text = dr.Field<string>("Funding_Text"),
                    Time_Cited = Convert.ToInt32(dr.Field<int?>("Time_Cited")),
                    Publisher = dr.Field<string>("Publisher"),
                    ISSN = dr.Field<string>("ISSN"),
                    Publication_Date = dr.Field<System.DateTime?>("Publication_Date"),
                    Publication_Month = dr.Field<string>("Publication_Month"),
                    Publication_Year = Convert.ToInt32(dr.Field<int?>("Publication_Year")),
                    Wide_Category = dr.Field<string>("Wide_Category"),
                    Subject_Category = dr.Field<string>("Subject_Category"),
                    Impact_Factor_Last_Year = dr.Field<string>("Impact_Factor_Last_Year"),
                    Impact_Factor_Publication_Year = dr.Field<string>("Impact_Factor_Publication_Year"),
                    QClass = dr.Field<string>("QClass"),
                    Deleted_flag = dr.Field<bool?>("Deleted_flag"),
                    Active_flag = dr.Field<bool?>("Active_flag"),
                    CreatedBy = dr.Field<string>("CreatedBy"),
                    CreatedOn = dr.Field<System.DateTime>("CreatedOn")
                }
                ).ToList();

            return list;
        }

        #endregion
    }
}
