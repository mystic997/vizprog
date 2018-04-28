using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.validator
{
    class EnoughSpaceValidator : ValidationBase
    {
        private int neededPerson;
        private int maxPerson;

        public EnoughSpaceValidator(int neededPerson, int maxPerson)
        {
            this.neededPerson = neededPerson;
            this.maxPerson = maxPerson;
        }

        public override void Validate()
        {
            if (neededPerson > maxPerson)
            {
                ValidationResult.ValidationStatus = Status.Error;
                ValidationResult.FeedbackMessage = "Nem lehet több utast szállítani, mint amennyi elfér!";
            }
            else
            {
                ValidationResult.ValidationStatus = Status.OK;
            }
        }
    }
}
