using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace Testing.Client.Services
{
    public class NumberVerificationApiClient
        : INumberVerificationApiClient
    {
        private readonly string _url;
        private readonly string _accessKey;

        public NumberVerificationApiClient(IConfiguration configuration)
        {
            _url = "https://apilayer.net/api/validate";
            _accessKey = configuration["NumVerifierAccessKey"];
        }

        public HttpResponseMessage? GetNumberIsVerifiedResponse(long numberToValidate)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_url);

            // Add an Accept header for JSON format.
            httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var response = httpClient.GetAsync($"?number={numberToValidate}&access_key={_accessKey}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response;
            }

            throw new Exception("Unable to successfully call number verification API");
        }
    }
}
