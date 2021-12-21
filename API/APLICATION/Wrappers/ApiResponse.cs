using System;
using System.Collections.Generic;
using System.Text;
using DOMAIN.ENTITIES;

namespace APLICATION.Wrappers
{
    public class ApiResponse
    {
      public IDictionary<String, Currency> data { get; set; }

        public Status status{ get; set; }
    
  }
}
