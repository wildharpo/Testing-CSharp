namespace Testing.Client.Services
{
    public interface INumberVerificationApiClient
    {
        HttpResponseMessage? GetNumberIsVerifiedResponse(long numberToValidate);
    }
}
