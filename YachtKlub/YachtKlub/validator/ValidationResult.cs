using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.validator
{
    public enum Status { OK, Error };

    class ValidationResult
    {
        public string FeedbackMessage { get; set; }
        public Status ValidationStatus { get; set; }

        public ValidationResult()
        {
            ValidationStatus = new Status();
            FeedbackMessage = null;
        }
    }
}
