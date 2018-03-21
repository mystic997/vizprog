using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.validator;

namespace YachtKlub.service
{
    class ServiceResponse
    {
        public List<string> FeedbackMessages { get; set; }

        public ServiceResponse()
        {
            FeedbackMessages = new List<string>();
        }
    }
}
