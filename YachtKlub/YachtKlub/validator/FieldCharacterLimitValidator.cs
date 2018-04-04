using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.validator
{
    class FieldCharacterLimitValidator : ValidationBase
    {
        private int lowerLimit;
        private int upperLimit;
        private string fieldName;
        private string field;

        public FieldCharacterLimitValidator(string field, int lowerLimit, int upperLimit, string fieldName)
        {
            this.field = field;
            this.lowerLimit = lowerLimit;
            this.upperLimit = upperLimit;
            this.fieldName = fieldName;
        }

        public override void Validate()
        {
            if (field.Length < lowerLimit || field.Length > upperLimit)
            {
                ValidationResult.ValidationStatus = Status.Error;
                ValidationResult.FeedbackMessage = "A(z) " + fieldName + " mező hossza " + lowerLimit + " és " + upperLimit + " közé kell, hogy essen!";
            }
            else
            {
                ValidationResult.ValidationStatus = Status.OK;
            }
        }
    }
}
