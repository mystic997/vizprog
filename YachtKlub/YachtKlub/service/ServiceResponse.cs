using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.validator;
using System.Windows;


namespace YachtKlub.service
{
    class ServiceResponse
    {
        public string FeedbackMessage { get; set; }
        public Dictionary<string, string> ResponseMessage { get; set; }
        public Status ServiceStatus { get; set; }

        public ServiceResponse()
        {
            ServiceStatus = new Status();
            ResponseMessage = new Dictionary<string, string>();
            FeedbackMessage = null;
        }
    }
}
