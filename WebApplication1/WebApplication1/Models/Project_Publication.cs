﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RMS.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Project_Publication
    {
        public int Project_Publication_ID { get; set; }
        public string WOS_Number { get; set; }
        public string Project_Code { get; set; }
        public Nullable<int> Project_ID { get; set; }
        public string Fund_Type { get; set; }
        public string Project_Type { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<bool> Active_flag { get; set; }
        public Nullable<bool> Deleted_flag { get; set; }

        public virtual Project_Publication Project_Publication1 { get; set; }
        public virtual Project_Publication Project_Publication2 { get; set; }
    }
}
