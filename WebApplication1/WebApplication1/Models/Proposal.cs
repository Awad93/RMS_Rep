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
    using System.Collections.Generic;

    public partial class Proposal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proposal()
        {
            this.Projects = new HashSet<Project>();
        }

        public int Project_ID { get; set; }
        public string Proposal_Code { get; set; }
        public Nullable<double> PI { get; set; }
        public string Proposal_Title { get; set; }
        public string Proposal_Type { get; set; }
        public string Semester { get; set; }
        public string Keywords { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public Nullable<double> Budget { get; set; }
        public string Chairman_Approval { get; set; }
        public string Chairman_Comments { get; set; }
        public bool isFinal_Eval_Complete { get; set; }
        public string Status { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<bool> Active_flag { get; set; }
        public Nullable<bool> Deleted_flag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Projects { get; set; }
    }
}
