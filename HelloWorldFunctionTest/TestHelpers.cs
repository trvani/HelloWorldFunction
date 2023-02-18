using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.WebApiCompatShim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace HelloWorldFunctionTest
{
    public static class TestHelpers
    {
        public static HttpRequestMessage CreateGetReq(string hostName =null,Dictionary<string,string> query=null)
        {
            var requestPath = string.IsNullOrWhiteSpace(hostName) ? "https://localhost":hostName;

            requestPath += query == null ? string.Empty : $"{string.Join("&", query.Select(q => $"{q.Key}={q.Value}"))}";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestPath)
            };

            request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            return request;

        }
    }
}
