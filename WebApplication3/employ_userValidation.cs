using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication3.customValidation;



namespace WebApplication3
{
    public class employ_userValidation
    {
        [Required]
        public int id { get; set; }
        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage ="User name is not valid")]
        public string name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$", ErrorMessage = "The conditions are string must be between 8 and 15 characters long." +
            " string must contain at least one number. string must contain at least one uppercase letter. string must contain at least one lowercase letter.")]
        public string Password { get; set; }
        [Required]
        public Nullable<System.DateTime> date { get; set; }
        [Required]
        public Nullable<int> departmentId { get; set; }
        [Required]
        public Nullable<int> DesignationId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Invalid Mobile Number.")]
        public string phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        
        public string email { get; set; }
      


    }
    [MetadataType(typeof(employ_userValidation))]
    public partial class employ_user
    {
    }
}