using Derivco.Models;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net.Security;
using Xunit.Abstractions;
using NUnit.Framework;

namespace Derivco
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;

        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public async Task  GetDrinksSearchAPIVodka()

        {

            var restClientOptions = new RestClientOptions
            {
                BaseUrl = new Uri("https://www.thecocktaildb.com/"),
                RemoteCertificateValidationCallback = (Sender, certificate, chain, errors) => true
            };
        // Rest Client initialization
        var client = new RestClient(restClientOptions);
       //Rest Request

        var request = new RestRequest("api/json/v1/1/search.php/");
            request.AddQueryParameter("i", "vodka");     
            
           var response = await client.GetAsync<Ingredients>(request);
          
           
           
        }

        [Fact]

        public async Task GetIngredientSearch()
        {

            var restClientOptions = new RestClientOptions
            {
                BaseUrl = new Uri("https://www.thecocktaildb.com/"),
                RemoteCertificateValidationCallback = (Sender, certificate, chain, errors) => true
            };
            // Rest Client initialization
            var client = new RestClient(restClientOptions);
            //Rest Request

            var request = new RestRequest("api/json/v1/1/search.php/");
            request.AddQueryParameter("i", "vodka");

            var response = await client.GetAsync<Ingredients>(request);
            response?.Alcohol.Should().BeNull();
            response?.ABV.Should().NotBeNull();
        }


    

        [Fact]
        public async Task GetNonAlcohol()
        {

            var restClientOptions = new RestClientOptions
            {
                BaseUrl = new Uri("https://www.thecocktaildb.com/"),
                RemoteCertificateValidationCallback = (Sender, certificate, chain, errors) => true
            };
            // Rest Client initialization
            var client = new RestClient(restClientOptions);
            //Rest Request

            var request = new RestRequest("api/json/v1/1/search.php/");
            request.AddQueryParameter("i", "vodka");

            var response = await client.GetAsync<Ingredients>(request);
            response?.Alcohol.Should().BeNull();
            response?.ABV.Should().NotBeNull();

        }

        [Fact]
         public async Task GetAlcohol()
        {
            var restClientOptions = new RestClientOptions
            {
                BaseUrl = new Uri("https://www.thecocktaildb.com/"),
                RemoteCertificateValidationCallback = (Sender, certificate, chain, errors) => true
            };
            // Rest Client initialization
            var client = new RestClient(restClientOptions);
            //Rest Request

            var request = new RestRequest("api/json/v1/1/search.php/");
            request.AddQueryParameter("i", "vodka");

            var response = await client.GetAsync<Ingredients>(request);
            response?.Alcohol.Should().BeNull();
            response?.ABV.Should().NotBeNull();
        }
        [Fact]
        public async Task SeacrhByCockTailName()
        {

            var restClientOptions = new RestClientOptions
            {
                BaseUrl = new Uri("https://www.thecocktaildb.com/"),
                RemoteCertificateValidationCallback = (Sender, certificate, chain, errors) => true
            };
            // Rest Client initialization
            var client = new RestClient(restClientOptions);
            //Rest Request

            var request = new RestRequest("api/json/v1/1/search.php/");
            request.AddQueryParameter("s", "margarita");

            var response = await client.GetAsync<Cocktails>(request);
            response?.strDrink.Should().BeUpperCased();
            

        }

        [Fact]
        public async Task SearchCockTailNotExist()
        {

            var restClientOptions = new RestClientOptions
            {
                BaseUrl = new Uri("https://www.thecocktaildb.com/"),
                RemoteCertificateValidationCallback = (Sender, certificate, chain, errors) => true
            };
            // Rest Client initialization
            var client = new RestClient(restClientOptions);
            //Rest Request

            var request = new RestRequest("api/json/v1/1/search.php/");
            request.AddQueryParameter("s", "margarita");
            request.AddQueryParameter("s", " ");

            var response = await client.GetAsync<Cocktails>(request);
            response?.drinks.Should().BeNull();
            
        }

    }
}