using Testing.Client.Models;

namespace Testing.Client.DataAccess
{
    public interface IVolunteerRepo
    {
        List<Volunteer> GetVolunteers();
        Volunteer GetVolunteerByPhoneNumber(long phoneNumber);
        void SaveVolunteer(Volunteer volunteer);

    }
}
