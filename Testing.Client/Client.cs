using Testing.Client.Helpers;

namespace Testing.Client
{
    public class Client
    {
        private readonly INumberFormatter _numberFormatter;

        public Client(INumberFormatter numberFormatter)
        {
            _numberFormatter = numberFormatter;
        }
    }
}
