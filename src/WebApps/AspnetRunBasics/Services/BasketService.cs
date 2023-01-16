using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CheckoutBasket(BasketCheckoutModel basketModel)
        {
            var response = await _httpClient.PostAsJson("/Basket/Checkout", basketModel);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling the API.");
            }
        }

        public async Task<BasketModel> GetBasket(string userName)
        {
            var response = await _httpClient.GetAsync($"/Basket/{userName}");
            return await response.ReadContentAs<BasketModel>();
        }

        public async Task<BasketModel> UpdateBasket(BasketModel basketModel)
        {
            var response = await _httpClient.PostAsJson("/Basket", basketModel);

            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<BasketModel>();
            }
            else
            {
                throw new Exception("Something went wrong when calling the API.");
            }
        }
    }
}
