using Derivco.Models;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net.Security;
using Xunit.Abstractions;

using System;
using System.ComponentModel;

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



        // The below Test Case Searching for a cocktail by name is case-insensitive
        [Fact]
         public async Task SeacrhCockTailNameIncase()
       
        {

            var restClientOptions = new RestClientOptions
            {
                BaseUrl = new Uri("https://www.thecocktaildb.com/"),
                RemoteCertificateValidationCallback = (Sender, certificate, chain, errors) => true
            };
            // Rest Client initialization
            var client = new RestClient(restClientOptions);
            //Rest Request and the prameters used

            var request = new RestRequest("api/json/v1/1/search.php/");
            request.AddQueryParameter("s", "margarita");

            //Below is the Request response

            var response = await client.GetAsync<Ingredients>(request);

            // Below is the assertion for the Name to be in case Sensitive
            response?.Alcohol.Should().NotBeUpperCased("margarita");
           

        }

        [Fact]
         public async Task SeacrhameIncase()
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

            var response = await client.GetAsync(request);
            //await response.Should().("AB");
            response.Should().BeSameAs("Alcoholic");
            

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

            // Adding the parameter request for the cocktail that does not exists
            request.AddQueryParameter("s", "margaritas");

            // The response for cocktail that does not exist
            var response = await client.GetAsync<Cocktails>(request);
            
            response?.strDrink.Should().BeNull();
            
        }

        [Fact]
        public async Task SearchCocktailName()
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
            response?.strDrink.Should().ContainAny("m");

        }

    }
}