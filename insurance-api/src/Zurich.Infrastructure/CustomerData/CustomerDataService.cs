using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zurich.Insurance.Application.Interfaces;

namespace Zurich.Insurance.Infrastructure.CustomerData
{
    public sealed class CustomerDataService : ICustomerData
    {
        public const string HttpClientName = "Fixer";

        private const string _customerUrl = "https://api.exchangeratesapi.io/latest?base=USD";

        private readonly IHttpClientFactory _httpClientFactory;


        public CustomerDataService(IHttpClientFactory httpClientFactory) =>
            this._httpClientFactory = httpClientFactory;

        /// <summary>
        ///     Converts allowed currencies into USD.
        /// </summary>
        /// <returns>Money.</returns>
        public async Task<Domain.Model.CustomerData> GetCustomerData(string externalId)
        {
            HttpClient httpClient = this._httpClientFactory.CreateClient(HttpClientName);
            Uri requestUri = new Uri(_customerUrl);

            HttpResponseMessage response = await httpClient.GetAsync(requestUri)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            string responseJson = await response
                .Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            JObject customer = JObject.Parse(responseJson);


            return new Domain.Model.CustomerData();
        }
    }
}
