using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.ENTITIES
{
   public class Currency
    {
      public int id { get; set; }
    public string name { get; set; }
    public string symbol { get; set; }
    public string website_slug { get; set; }
    public int rank { get; set; }
    public double circulating_supply { get; set; }
    public double total_supply { get; set; }
    public double? max_supply { get; set; }
    public Quote quotes { get; set; }
    public DateTime last_updated { get; set; }
    }
}
