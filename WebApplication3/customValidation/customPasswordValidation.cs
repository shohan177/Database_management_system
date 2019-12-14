using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApplication3.customValidation
{
    public class customPasswordValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            bool validPassword = false;
            string reason = String.Empty;
            string Password = value == null ? String.Empty : value.ToString();
            if (String.IsNullOrEmpty(Password) || Password.Length < 8)
            {
                reason = "Your new password must be at least 8 characters long. ";
            }
            else
            {
                Regex reSymbol = new Regex("[^a-zA-Z0-9]");
                Regex reUperCase = new Regex("[^A-Z]");
                Regex reLowerCase = new Regex("[^a-z]");
                Regex reNumber= new Regex("[^0-9]");
              
                if (!reSymbol.IsMatch(Password))
                {
                    reason += "must a use a symbol";

                }
                else if (reUperCase.IsMatch(Password))
                {
                    reason += "must a uper case charecter";

                }
                else if (reLowerCase.IsMatch(Password))
                {
                    reason += "must a lower case charecter";

                }
                else if (reNumber.IsMatch(Password))
                {
                    reason += "must a number ";

                }


                else
                {
                    validPassword = true;
                }
            }
            if (validPassword)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(reason);
            }
        }
    }
}