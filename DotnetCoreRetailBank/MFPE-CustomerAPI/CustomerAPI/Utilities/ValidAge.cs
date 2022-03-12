using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.Utilities
{
    public class ValidAge : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dob = DateTime.Parse(value.ToString());
            int age = DateTime.Now.Year - dob.Year;
            if (DateTime.Now.DayOfYear < dob.DayOfYear)
                age--;
            /*return base.IsValid(value);*/
            return age >= 18;
        }
    }
}
