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
        }

        public List<string> GetFeedbackMessages()
        {
            List<string> feedbackMessages = new List<string>();

            for (int i = 0; i < ValidationComponents.Count; i++)
            {
                if (!string.IsNullOrEmpty(ValidationComponents[i].ValidationResult.FeedbackMessage) && !string.IsNullOrWhiteSpace(ValidationComponents[i].ValidationResult.FeedbackMessage))
                    feedbackMessages.Add(ValidationComponents[i].ValidationResult.FeedbackMessage);
            }

            return feedbackMessages;
        }
    }
}
