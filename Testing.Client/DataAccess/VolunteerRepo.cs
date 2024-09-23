using System;
using Testing.Client.Models;

namespace Testing.Client.DataAccess
{
    public class VolunteerRepo
        : IVolunteerRepo
    {
        public Volunteer GetVolunteerByPhoneNumber(int phoneNumber)
        {
            throw new NotImplementedException();
        }

        public List<Volunteer> GetVolunteers()
        {
            throw new NotImplementedException();
        }

        public void SaveVolunteer(Volunteer volunteer)
        {
            throw new NotImplementedException();
        }
    }
}
