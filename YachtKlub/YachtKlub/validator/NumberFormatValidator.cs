using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.validator
{
    class NumberFormatValidator : ValidationBase
    {
        string number;

        public NumberFormatValidator(string number)
        {
            this.number = number;
        }

        public override void Validate()
        {
            int n;
            bool isNumber = int.TryParse(number, out n);

            if (!isNumber)
            {
                ValidationResult.ValidationStatus = Status.Error;
                ValidationResult.FeedbackMessage = "Nem szám formátum egy számot elfogadó mezőben!";
            }
            else
            {
                ValidationResult.ValidationStatus = Status.OK;
            }
        }
    }
}
