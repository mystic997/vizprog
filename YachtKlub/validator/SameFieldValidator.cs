using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.validator
{
    class SameFieldValidator : ValidationBase
    {
        private string firstFieldText;
        private string secondFieldText;
        private string fieldName;

        public SameFieldValidator(string firstFieldText, string secondFieldText, string fieldName)
        {
            this.firstFieldText = firstFieldText;
            this.secondFieldText = secondFieldText;
            this.fieldName = fieldName;
        }

        public override void Validate()
        {
            if (!firstFieldText.Equals(secondFieldText))
            {
                ValidationResult.ValidationStatus = Status.Error;
                ValidationResult.FeedbackMessage = "Nem egyforma " + fieldName + " mező";
            }
            else
            {
                ValidationResult.ValidationStatus = Status.OK;
            }
        }
    }
}
