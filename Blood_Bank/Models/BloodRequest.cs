//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blood_Bank.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BloodRequest
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public Nullable<int> Age { get; set; }
        public string Reason { get; set; }
        public int BloodGroup { get; set; }
        public Nullable<int> Unit { get; set; }
        public string Gender { get; set; }
    
        public virtual Blood_group Blood_group { get; set; }
    }
}