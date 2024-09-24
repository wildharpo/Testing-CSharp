using Testing.Client.DataAccess;
using Testing.Client.Helpers;
using Testing.Client.Models;
using Testing.Client.Services;

namespace Testing.Client
{
    public class Client
    {
        private readonly INumberFormatter _numberFormatter;
        private readonly INumberVerificationApi _numberVerificationApi;
        private readonly IVolunteerRepo _volunteerRepo;

        public Client(INumberFormatter numberFormatter,
            INumberVerificationApi numberVerificationApi,
            IVolunteerRepo volunteerRepo)
        {
            _numberFormatter = numberFormatter;
            _numberVerificationApi = numberVerificationApi;
            _volunteerRepo = volunteerRepo;
        }

        public void Run()
        {
            Console.WriteLine("Please enter a phone number to verify: ");
            var phoneNumberStr = Console.ReadLine();

            Console.WriteLine("Formatting number...");
            var phoneNumber = _numberFormatter.GetFormattedNumber(phoneNumberStr);

            Console.WriteLine("Seeing if number already exists in database...");
            var existingCustomer = _volunteerRepo.GetVolunteerByPhoneNumber(phoneNumber);

            if (existingCustomer != null)
                Console.WriteLine($"This customer already exists! Phone number {existingCustomer.PhoneNumber} belongs to {existingCustomer.FirstName} {existingCustomer.LastName}");
            else
            {
                Console.WriteLine("Customer does not exist in database. Verifying provided number...");
                var numberIsVerified = _numberVerificationApi.NumberIsVerified(phoneNumber);

                if (numberIsVerified)
                {
                    Console.WriteLine("Phone number is valid, please enter additional fields.");
                    Console.Write("First Name: ");
                    var firstName = Console.ReadLine();
                    Console.Write("Last Name: ");
                    var lastName = Console.ReadLine();
                    Console.Write("Email: ");
                    var email = Console.ReadLine();

                    Console.WriteLine("Saving new user to database...");
                    var volunteer = new Volunteer(firstName, lastName, phoneNumber, email);
                    _volunteerRepo.SaveVolunteer(volunteer);
                    Console.WriteLine("User saved!");
                }
                else
                    Console.WriteLine("Provided number was invalid.");
            }
        }
    }
}
