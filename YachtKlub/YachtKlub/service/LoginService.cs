using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.validator;

namespace YachtKlub.service
{
    class LoginService
    {
        private string email;
        private string password;

        public LoginService(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public ServiceResponse Login()
        {
            Validator val = new Validator();
            // lehet jobb lenne a mezőket kijelölni inkább
            val.ValidationComponents.Add(new EmptyFieldValidator(email, "e-mail cím"));
            val.ValidationComponents.Add(new EmptyFieldValidator(password, "jelszó"));
            val.ValidationComponents.Add(new EmailFormatValidator(email));
            val.ValidateElements();

            ServiceResponse response = new ServiceResponse();
            for (int i = 0; i < val.ValidationComponents.Count; i++)
            {
                if (!string.IsNullOrEmpty(val.ValidationComponents[i].ValidationResult.FeedbackMessage))
                    response.FeedbackMessages.Add(val.ValidationComponents[i].ValidationResult.FeedbackMessage);
            }

            return response;
        }
    }
}
