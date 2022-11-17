using FluentAssertions;
using RestSharp;
using System.Net.Security;
using Xunit.Abstractions;

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
        public async Task  Test1()

        {

            var restClientOptions = new RestClientOptions
            {
                BaseUrl = new Uri("https://www.thecocktaildb.com/"),
                RemoteCertificateValidationCallback = (Sender, certificate, chain, errors) => true
            };
        // Rest Client initialization
        var client = new RestClient(restClientOptions);
       //Rest Request

        var request = new RestRequest("api/json/v1/1/search.php?i=vodka");       
            
            var response = await client.GetAsync(request);
 
            response.Should().NotBeNull();
        _output.WriteLine("Executing first Test");
        }
    }
}