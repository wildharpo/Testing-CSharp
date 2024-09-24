using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Testing.Client.Models;

namespace Testing.Client.DataAccess
{
    public class VolunteerRepo
        : IVolunteerRepo
    {
        private readonly string _server;
        private readonly string _username;
        private readonly string _password;

        public VolunteerRepo(IConfiguration configuration)
        {
            _server = configuration["Server"];
            _username = configuration["User"];
            _password = configuration["Password"];
        }

        private MySqlConnection GetDbServerConn()
        {
            var dbServerConn = new MySqlConnection($"server={_server};user id={_username};password={_password};database=volunteer;port=3306");
            return dbServerConn;
        }

        public List<Volunteer> GetVolunteers()
        {
            using (var dbServerConn = GetDbServerConn())
            {
                var results = dbServerConn.Query<Volunteer>("SELECT * FROM volunteer");
                foreach (var result in results)
                    Console.WriteLine(result);

                return results.ToList();
            }
        }

        public Volunteer GetVolunteerByPhoneNumber(long phoneNumber)
        {
            using (var dbServerConn = GetDbServerConn())
            {
                var result = dbServerConn.QueryFirstOrDefault<Volunteer>($"SELECT * FROM volunteer WHERE PhoneNumber = {phoneNumber}");
                return result;
            }
        }

        public void SaveVolunteer(Volunteer volunteer)
        {
            throw new NotImplementedException();
        }

        private void InsertVolunteer(Volunteer volunteer)
        {
            using (var dbServerConn = GetDbServerConn())
            {
                var sql = $"UPDATE volunteer SET FirstName='{volunteer.FirstName}', LastName='{volunteer.LastName}', Email='{volunteer.Email}' WHERE PhoneNumber={volunteer.PhoneNumber}";
                dbServerConn.Execute(sql);
            }
        }

        private void UpdateVolunteer(Volunteer volunteer)
        {
            using (var dbServerConn = GetDbServerConn())
            {
                var sql = $"INSERT INTO volunteer (FirstName, LastName, PhoneNumber, Email) VALUES ('{volunteer.FirstName}', '{volunteer.LastName}', {volunteer.PhoneNumber}, '{volunteer.Email}')";
                dbServerConn.Execute(sql);
            }
        }
    }
}
