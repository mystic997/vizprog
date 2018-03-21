using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.validator
{
    public enum ValidationStatus { OK, Error }

    class ValidationResult
    {
        public string FeedbackMessage { get; set; }
        public ValidationStatus ValidationStatus { get; set; }

        public ValidationResult()
        {
            FeedbackMessage = "";
            ValidationStatus = new ValidationStatus();
        }
    }
}
