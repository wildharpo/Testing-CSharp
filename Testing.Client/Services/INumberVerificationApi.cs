namespace Testing.Client.Services
{
    public interface INumberVerificationApi
    {
        bool NumberIsVerified(long numberToValidate);
    }
}
