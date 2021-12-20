﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.ENTITIES
{
   public class Status
    {
        public DateTime timestamp { get; set; }
        public int error_code { get; set; }
        public object error_message { get; set; }
        public int elapsed { get; set; }
        public int credit_count { get; set; }
        public object notice { get; set; }
    }
}
