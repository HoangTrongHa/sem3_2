//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InstituteofFineArts.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Manager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manager()
        {
            this.Exams = new HashSet<Exam>();
        }
    
        public int Id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public Nullable<int> phone { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Nullable<int> role { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exam> Exams { get; set; }
    }
}
