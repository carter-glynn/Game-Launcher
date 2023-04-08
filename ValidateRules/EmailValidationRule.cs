using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameLauncher.ValidateRules {
    public class EmailValidationRule : ValidationRule {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
            var str = value as string;

            if(str == "") {
                return ValidationResult.ValidResult;
            }
            if(!Regex.IsMatch(str, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")) {
                return new ValidationResult(false, "Failure");
            }
            else {
                return ValidationResult.ValidResult;
            }
        }
    }
}
