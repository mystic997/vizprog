using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.validator
{
    class Validator
    {
        public List<ValidationBase> ValidationComponents;

        public Validator()
        {
            ValidationComponents = new List<ValidationBase>();
        }

        public void ValidateElements()
        {
            for (int i = 0; i < ValidationComponents.Count; i++)
            {
                ValidationComponents[i].Validate();
            }

            PrintFeedbackMessages();
        }

        private void PrintFeedbackMessages()
        {
            bool hasError = false;

            for (int i = 0; i < ValidationComponents.Count; i++)
            {
                if (ValidationComponents[i].ValidationResult.ValidationStatus == Status.Error)
                {
                    hasError = true;
                }

                if (!string.IsNullOrEmpty(ValidationComponents[i].ValidationResult.FeedbackMessage) && !string.IsNullOrWhiteSpace(ValidationComponents[i].ValidationResult.FeedbackMessage))
                {
                    new PrintMessageBox(ValidationComponents[i].ValidationResult.FeedbackMessage, ValidationComponents[i].ValidationResult.ValidationStatus);
                }
            }

            if (hasError)
            {
                throw new Exception();
            }
        }
    }
}
