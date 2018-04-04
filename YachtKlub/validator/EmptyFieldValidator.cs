using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.validator
{
    class EmptyFieldValidator : ValidationBase
    {
        private string field;
        private string fieldName;

        public EmptyFieldValidator(string field, string fieldName)
        {
            this.field = field;
            this.fieldName = fieldName;
        }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(field))
            {
                ValidationResult.ValidationStatus = Status.Error;
                ValidationResult.FeedbackMessage = "A(z) " + fieldName + " mező nem lehet üres!";
            }
            else
            {
                ValidationResult.ValidationStatus = Status.OK;
            }
        }
    }
}
