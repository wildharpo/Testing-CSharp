using Testing.Client.Models;

namespace Testing.Client.Services
{
    public class NumberVerificationApi
        : INumberVerificationApi
    {
        private readonly INumberVerificationApiClient _numberVerificationApiClient;

        public NumberVerificationApi(INumberVerificationApiClient numberVerificationApi)
        {
            _numberVerificationApiClient = numberVerificationApi;
        }

        public bool NumberIsVerified(long numberToValidate)
        {
            HttpResponseMessage? response;
            NumberVerificationApiResponse apiResponse;

            // attempt to verify the number via the public API
            try
            {
                response = _numberVerificationApiClient.GetNumberIsVerifiedResponse(numberToValidate);
            }
            catch(Exception ex)
            {
                throw new Exception("Unable to successfully call number verification API", ex);
            }

            try
            {
                // attempt to parse the API response into a JSON object for examination
                var dataString = response.Content.ReadAsStringAsync().Result;
                apiResponse = System.Text.Json.JsonSerializer.Deserialize<NumberVerificationApiResponse>(dataString);
            }
            catch(Exception ex)
            {
                throw new Exception("Unable to convert API response object to JSON object");
            }

            // return whether or not the number is valid, according to the value of the 'valid' field on the JSON object
            return apiResponse.valid;
        }
    }
}
