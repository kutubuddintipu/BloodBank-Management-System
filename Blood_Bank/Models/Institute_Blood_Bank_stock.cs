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
    
    public partial class Institute_Blood_Bank_stock
    {
        public int stock_id { get; set; }
        public Nullable<int> rel_institute_city_id { get; set; }
        public Nullable<int> blood_group_id { get; set; }
        public Nullable<int> blood_bag_qty { get; set; }
    
        public virtual Blood_group Blood_group { get; set; }
        public virtual rel_institute_city rel_institute_city { get; set; }
    }
}
