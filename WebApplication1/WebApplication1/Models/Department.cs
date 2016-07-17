using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using App_Code;

namespace Models
{
    public partial class Department
    {
        #region Fields
        public static string Department_ID = "Department_ID";
        public static string Department_Name = "Department_Name";
        public static string Department_Code = "Department_Code";
        public static string Parent_Department_ID = "Parent_Department_ID";
        public static string Parent_Department_Code = "Parent_Department_Code";
        public static string Department_Level = "Department_Level";
        public static string Department_Type = "Department_Type";
        public static string CreatedOn = "CreatedOn";
        public static string CreatedBy = "CreatedBy";
        public static string UpdatedOn = "UpdatedOn";
        public static string UpdatedBy = "UpdatedBy";
        public static string Active_flag = "Active_flag";
        public static string Deleted_flag = "Deleted_flag";
        #endregion
    }

    public partial class DepartmentController
    {
        #region Fields
        public int Department_ID { get; set; }
        public string Department_Name { get; set; }
        public string Department_Code { get; set; }
        public int? Parent_Department_ID { get; set; }
        public string Parent_Department_Code { get; set; }
        public int? Department_Level { get; set; }
        public string Department_Type { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public bool? Active_flag { get; set; }
        public bool? Deleted_flag { get; set; }
        #endregion

        #region Methods

        public static List<DepartmentController> getAllColleges()
        {
            string strStoredProcedureName = "sp_rep_GetCollegesAll";

            DataTable dt = DbAccess.ExecuteQuery(strStoredProcedureName, CommandType.StoredProcedure);

            return ConvertDataTableToList(dt);
        }

        public static List<DepartmentController> getDepartmentsByCollege(string college_code)
        {
            string strStoredProcedureName = "sp_rep_getDepartmentsByCollege";

            SqlParameter param = (new SqlParameter("@college_code", college_code));

            DataTable dt = DbAccess.ExecuteQuery(strStoredProcedureName, CommandType.StoredProcedure, param);

            return ConvertDataTableToList(dt);
        }

        private static List<DepartmentController> ConvertDataTableToList(DataTable dt)
        {
            var list = dt.AsEnumerable()
                .Select(dr =>
                new DepartmentController
                {
                    Department_ID = dr.Field<int>("Department_ID"),
                    Department_Name = dr.Field<string>("Department_Name"),
                    Department_Code = dr.Field<string>("Department_Code"),
                    Parent_Department_Code = dr.Field<string>("Parent_Department_Code"),
                    Department_Level = dr.Field<int?>("Department_Level"),
                    Department_Type = dr.Field<string>("Department_Type"),
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



//private static List<rms_Departments> helper(DataTable dt)
//{
//    var list = dt.AsEnumerable()             
//        .Select(dr =>
//        new rms_Departments
//        {
//            Department_ID = Convert.ToInt32(dr.Field<int>("Department_ID")),
//            DeptCode = dr.Field<string>("DeptCode"),
//            Deptartment = dr.Field<string>("Deptartment"),
//            College = dr.Field<string>("College"),
//            Colg = dr.Field<string>("Colg"),
//            isDeleted = dr.Field<bool>("isDeleted"),
//            isActive = dr.Field<bool>("isActive"),
//            CreatedBy = dr.Field<string>("CreatedBy"),
//            CreatedOn = dr.Field<System.DateTime>("CreatedOn")
//        }
//        ).ToList();
//    return list;
//}
