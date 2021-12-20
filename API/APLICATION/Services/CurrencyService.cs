using APLICATION.Proxies;
using APLICATION.Wrappers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APLICATION.Services
{
    public class CurrencyService
    {
        private readonly ProxyHttpClient _proxy;
        public CurrencyService(ProxyHttpClient proxy)
        {
            _proxy = proxy;
        }
        public async Task<ApiResponse> GetCurrencyList(string key)
        {
            var client = _proxy.Get(key);
            var response =  client.GetAsync("quotes/latest?symbol=BTC,ETH,BNB,USDT,ADA",System.Net.Http.HttpCompletionOption.ResponseHeadersRead).Result;

            if (response.StatusCode != HttpStatusCode.BadRequest && response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(response.ReasonPhrase);
            }
            else
            {
                var data = await response.Content.ReadAsStringAsync();
                var Json = JsonConvert.DeserializeObject<ApiResponse>(data);
                return Json;
            }




        }
    }
}
