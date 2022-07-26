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


    public partial class management
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public management()
        {
            this.allocations = new HashSet<allocation>();
        }
        public int management_id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Email is required")]

        [RegularExpression(@"[a-z0-9]+@[a-z]+\.[a-z]{2,3}", ErrorMessage = "Invalid Email")]
        [DisplayName("E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        
        [Required(ErrorMessage = "phone is required")]
        [DisplayName("Phone-No")]
        [DataType(DataType.PhoneNumber)]
        public string phone_no { get; set; }
        [Required(ErrorMessage = "userName is required")]
        [DisplayName("User-Name")]
        [StringLength(20,MinimumLength =5,ErrorMessage ="username should be IN-Between 10 To 20 characters")]

        public string user_name { get; set; }
        [Required(ErrorMessage = "password is required")]
         [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = " password is not in right pattern")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "confirm Password is required")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = " password is not in right pattern")]
        [Compare("password", ErrorMessage = "Password dosen't match")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm-Password")]
        public string confirm_password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<allocation> allocations { get; set; }
    }
}