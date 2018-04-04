using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YachtKlub.validator
{
    class NameFormatValidator : ValidationBase
    {
        private string name;

        public NameFormatValidator(string name)
        {
            this.name = name;
        }

        public override void Validate()
        {
            Regex regex = new Regex(@"^(([A-Z]|[ÁÉÍÓÖŐÚÜŰ])([a-z]|[áéíóöőúüű])* ?)*$");
            Match match = regex.Match(name);

            if (!match.Success)
            {
                ValidationResult.ValidationStatus = Status.Error;
                ValidationResult.FeedbackMessage = "Nem valós név formátum!";
            }
            else
            {
                ValidationResult.ValidationStatus = Status.OK;
            }
        }
    }
}
