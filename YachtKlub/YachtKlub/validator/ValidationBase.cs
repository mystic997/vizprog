using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.validator
{
    abstract class ValidationBase
    {
        public ValidationResult ValidationResult { get; set; }
        public abstract void Validate();
        public ValidationBase()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
