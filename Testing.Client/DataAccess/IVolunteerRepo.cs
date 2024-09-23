using Testing.Client.Models;

namespace Testing.Client.DataAccess
{
    public interface IVolunteerRepo
    {
        List<Volunteer> GetVolunteers();
        Volunteer GetVolunteerByPhoneNumber(int phoneNumber);
        void SaveVolunteer(Volunteer volunteer);

    }
}
