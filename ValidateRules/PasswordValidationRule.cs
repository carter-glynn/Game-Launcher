using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameLauncher.ValidateRules {
    public class PasswordValidationRule : ValidationRule {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
            var str = value as string;

            if(str == "") {
                return ValidationResult.ValidResult;
            }
            if(!Regex.IsMatch(str, @"^[A-Za-z0-9!$#&]+$")) {
                return new ValidationResult(false, "Failure");
            }
            else {
                return ValidationResult.ValidResult;
            }
        }
    }
}
