﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;

    public partial class clsPatent_Applied_Author
    {
        #region Fields
        public static string Patent_Applied_Author_ID = "Patent_Applied_Author_ID";
        public static string Patent_Applied_ID = "Patent_Applied_ID";
        public static string KFUPMID = "KFUPMID";
        public static string Role = "Role";
        public static string Remarks = "Remarks";
        public static string CreatedOn = "CreatedOn";
        public static string CreatedBy = "CreatedBy";
        public static string UpdatedOn = "UpdatedOn";
        public static string UpdatedBy = "UpdatedBy";
        public static string Active_flag = "Active_flag";
        public static string Deleted_flag = "Deleted_flag";
        #endregion
    }

    public partial class Patent_Applied_AuthorController
    {
        #region Fields
        public int Patent_Applied_Author_ID { get; set; }
        public int? Patent_Applied_ID { get; set; }
        public double? KFUPMID { get; set; }
        public string Role { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public bool? Active_flag { get; set; }
        public bool? Deleted_flag { get; set; }
        #endregion

        #region Methods
        #endregion
    }
}
