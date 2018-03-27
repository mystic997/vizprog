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
        public string FeedbackMessage { get; set; }
        public string ResponseMessage { get; set; }
        public Status ServiceStatus { get; set; }

        public ServiceResponse()
        {
            ServiceStatus = new Status();
            FeedbackMessage = null;
            ResponseMessage = null;
        }
    }
}
