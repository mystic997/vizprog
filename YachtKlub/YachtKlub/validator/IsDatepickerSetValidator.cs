using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace YachtKlub.validator
{
    class IsDatepickerSetValidator : ValidationBase
    {
        DatePicker datePicker;

        public IsDatepickerSetValidator(DatePicker datePicker)
        {
            this.datePicker = datePicker;
        }

        public override void Validate()
        {
            bool isInitaliyed = datePicker.IsInitialized;

            if (!isInitaliyed || datePicker.SelectedDate == null)
            {
                ValidationResult.ValidationStatus = Status.Error;
                ValidationResult.FeedbackMessage = "Nincs minden naptár beállítva!";
            }
            else { ValidationResult.ValidationStatus = Status.OK; }
        }
    }
}
