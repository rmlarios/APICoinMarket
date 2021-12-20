using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace APLICATION.Proxies
{
  public class ProxyHttpClient
  {
    private readonly IConfiguration _configuration;
    //private readonly IHttpContextAccessor _httpContextAccesor;

    public ProxyHttpClient(IConfiguration configuration)
    {
      _configuration = configuration;
    //  _httpContextAccesor = httpContextAccessor;
    }

    public HttpClient Get(string key)
    {
      var client = new HttpClient();
      client.BaseAddress = new Uri("https://pro-api.coinmarketcap.com/v1/cryptocurrency/");
      client.DefaultRequestHeaders
      .Accept
      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

      // client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", "813e38ca-7edb-4743-81a1-ceb0a4e51d9a");
      client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", key);

      return client;

    }

  }
}
