//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;


    public partial class allocation
    {
        public int allocation_id { get; set; }
        [DisplayName("Librarian-Name")]
        public int management_id { get; set; }
        [DisplayName("Student-Name")]
        public int student_id { get; set; }
        [DisplayName("Book-Name")]
        public int book_id { get; set; }
      //  [DisplayFormat(DataFormatString ="dd-mm-yy")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> allocation_date { get; set; }
    
        public virtual book book { get; set; }
        public virtual management management { get; set; }
        public virtual student student { get; set; }
    }
}
