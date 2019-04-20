using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreUser.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
            Payments = new HashSet<Payments>();
            Review = new HashSet<Review>();
        }

        public int CustomerId { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Username is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
      ErrorMessage = "Please enter valid email id.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "OldPassword is Required")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Confirm NewPassword is Required")]
        [Display(Name = "Confirm NewPassword")]
        [Compare("OldPassword")]
        public string NewPassword { get; set; }
      
        public string Country { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        public string City { get; set; }
        [Required(ErrorMessage = "ZipCode is Required")]
        public long ZipCode { get; set; }
        [Required(ErrorMessage = "Contact is Required")]
        public long Contact { get; set; }
        public bool BillingAddress { get; set; }
        public bool ShippingAddress { get; set; }
        public bool SaveInformation { get; set; }
        public bool PaymentType { get; set; }

        public ICollection<Orders> Orders { get; set; }
        public ICollection<Payments> Payments { get; set; }
        public ICollection<Review> Review { get; set; }
    }
}
