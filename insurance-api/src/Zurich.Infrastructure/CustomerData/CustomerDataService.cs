using Newtonsoft.Json;
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

        private const string _customerUrl = "http://localhost:3000/customers";

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
            Uri requestUri = new Uri($"{_customerUrl}/{externalId}");

            HttpResponseMessage response = await httpClient.GetAsync(requestUri)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            string responseJson = await response
                .Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            return ParseCustomer(responseJson);
        }

        private Domain.Model.CustomerData ParseCustomer(string responseJson)
        {
            JObject customer = JObject.Parse(responseJson);
            return new Domain.Model.CustomerData
            {
                CustomerExternalId = customer["id"].Value<string>(),
                BirthDate = customer["birthDate"].Value<DateTime>(),
                Name = customer["name"].Value<string>(),
                DocId = customer["docId"].Value<string>(),
            };
        }
    }
}
