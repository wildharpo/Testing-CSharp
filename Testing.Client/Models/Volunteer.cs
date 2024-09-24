namespace Testing.Client.Models
{
    public class Volunteer
    {
        public Volunteer(string firstName, string lastName, long phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
