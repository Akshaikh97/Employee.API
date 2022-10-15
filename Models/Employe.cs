using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee.API.Models {
    public class Employe {
        [Display(Name = "Id")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Employee Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; }
        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Mobile is required.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Dob { get; set; }
    }
}