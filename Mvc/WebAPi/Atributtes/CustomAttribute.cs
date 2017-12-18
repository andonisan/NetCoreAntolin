using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPi.Atributtes
{
    public class CustomAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if ((string) value == "X")
            {
                return false;
            }

            return base.IsValid(value);
        }
    }
}
