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
    
    public partial class Donor
    {
        public int donor_id { get; set; }
        public Nullable<int> donor_reg_no { get; set; }
        public Nullable<int> city_id { get; set; }
        public string donor_name { get; set; }
        public Nullable<int> donor_mobile { get; set; }
        public Nullable<System.DateTime> donor_birth_day { get; set; }
        public Nullable<System.DateTime> last_donate_date { get; set; }
        public Nullable<int> donation_count { get; set; }
        public Nullable<int> blood_group_id { get; set; }
        public string address { get; set; }
        public string sex { get; set; }
    
        public virtual Blood_group Blood_group { get; set; }
        public virtual City City { get; set; }
    }
}
