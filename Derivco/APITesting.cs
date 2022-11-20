using Derivco.Models;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using Xunit.Abstractions;

namespace Derivco
{
    public class APITesting
    {
        private readonly ITestOutputHelper _output;

        public APITesting(ITestOutputHelper output)
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
            
           var response = await client.ExecuteGetAsync<Ingredients>(request);
      
                     
        }

        [TestCase("an ingredient is non-alcoholic, Alcohol is yes and ABV is not null")]
        [Fact]
        public async Task TestCaseOne()

        {

            var restClientOptions = new RestClientOptions
            {
                BaseUrl = new Uri("https://www.thecocktaildb.com/"),
                RemoteCertificateValidationCallback = (Sender, certificate, chain, errors) => true
            };
            var client = new RestClient(restClientOptions);
            var request = new RestRequest("api/json/v1/1/search.php/");
            request.AddQueryParameter("i", "vodka");
            var response = await client.ExecuteGetAsync<Ingredients>(request);
            response?.Data.strIngredient.Contains("non-alcoholic");
            response?.Data.strAlcohol.Should().BeNull();
            response?.Data.strABV.Should().NotBeNull();

           

        }
        [TestCase("an ingredient alcoholic, Alcohol is null and ABV is null")]
        [Fact]
        public async Task TestCaseTwo()

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
            var response = await client.ExecuteGetAsync<Ingredients>(request);
            response?.Data.strIngredient.Contains("alcoholic");
            response?.Data.strAlcohol.Should().Contain("\"strAlcohol\": \"Yes\"");
            response?.Data.strABV.Should().NotBeNull();
            
           // response?.StatusCode.Should().Be(HttpResponseMessage.Equals("yes"));

        }

        [TestCase("The system shall include a method to search by cocktail name")]
        [Fact]
        public async Task TestCaseThree()

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

            var response = await client.ExecuteGetAsync<Cocktails>(request);

            response?.Data.strDrink.DefaultIfEmpty().Should().BeNull();
            

        }

        [TestCase("Searching for a cocktail by name is case-insensitive")]
        [Fact]
        public async Task TestCaseFour()

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

            var response = await client.ExecuteGetAsync<Cocktails>(request);

            response?.Data.strDrink.Should().NotBeUpperCased();


        }

        [TestCase("Verifying Headers Content Type")]
        [Fact]
        public async Task TestCaseFive()

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

            var response = await client.ExecuteGetAsync<Cocktails>(request);

            response?.ContentType.Should().Be("application/json");


        }

     

    }


    
}