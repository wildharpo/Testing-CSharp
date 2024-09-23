using Testing.Client.Helpers;
using Testing.Client.Services;

namespace Testing.Client
{
    public class Client
    {
        private readonly INumberFormatter _numberFormatter;
        private readonly INumberVerificationApi _numberVerificationApi;

        public Client(INumberFormatter numberFormatter, INumberVerificationApi numberVerificationApi)
        {
            _numberFormatter = numberFormatter;
            _numberVerificationApi = numberVerificationApi;
        }

        public void Run()
        {
            Console.WriteLine("Please enter a phone number to verify: ");
            var phoneNumberStr = Console.ReadLine();

            Console.WriteLine("Formatting number...");
            var phoneNumber = _numberFormatter.GetFormattedNumber(phoneNumberStr);

            Console.WriteLine("Customer does not exist in database. Verifying provided number...");
            var numberIsVerified = _numberVerificationApi.NumberIsVerified(phoneNumber);
        }
    }
}
