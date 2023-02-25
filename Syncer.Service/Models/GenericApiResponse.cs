using System;
using System.Collections.Generic;
using System.Text;

namespace Syncer.Service.Models
{
    public class GenericApiResponse
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
    }
}
