using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.ENTITIES
{
    public class Quote
    {
           public double price { get; set; }
    public double volume_24h { get; set; }
    public double market_cap { get; set; }
    public double percent_change_1h { get; set; }
    public double percent_change_24h { get; set; }
    public double percent_change_7d { get; set; }
  }
}
