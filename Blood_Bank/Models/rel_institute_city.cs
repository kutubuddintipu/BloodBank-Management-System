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
    
    public partial class rel_institute_city
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rel_institute_city()
        {
            this.Institute_Blood_Bank_stock = new HashSet<Institute_Blood_Bank_stock>();
        }
    
        public int rel_institute_city_id { get; set; }
        public Nullable<int> inst_id { get; set; }
        public Nullable<int> city_id { get; set; }
        public Nullable<int> inst_branch_code { get; set; }
        public string inst_branch_name { get; set; }
        public Nullable<int> inst_branch_contact_no { get; set; }
        public Nullable<int> inst_branch_emergency_no { get; set; }
        public string inst_branch_manager { get; set; }
        public Nullable<int> inst_branch_manager_no { get; set; }
        public string inst_branch_address { get; set; }
    
        public virtual City City { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Institute_Blood_Bank_stock> Institute_Blood_Bank_stock { get; set; }
    }
}