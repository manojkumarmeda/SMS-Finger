//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmsFinger.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class user
    {
        public int id { get; set; }
        [DisplayName("Account ID")]
        public Nullable<int> acid { get; set; }
        [DisplayName("First Name")]
        public string firstname { get; set; }
        [DisplayName("Last Name")]
        public string lastname { get; set; }
        [DisplayName("Gender")]
        public string gender { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Password")]
        public string password { get; set; }
        [DisplayName("Status")]
        public Nullable<int> status { get; set; }
        public Nullable<System.DateTime> datecreated { get; set; }
        public Nullable<int> usercreated { get; set; }
    }
}
