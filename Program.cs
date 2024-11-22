using sportesemény;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace sportesemény
{
    internal class Program
    {
        static Connect conn = new Connect();


        public static void GetAllData()
        {
            conn.Connection.Open();
            string sql = "SELECT * FROM Users";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            Console.WriteLine("Felhasználók listája:");

            while (dr.Read())
            {
                var user = new
                {
                    Id = dr.GetInt32(0),
                    UserName = dr.GetString(1),
                    Email = dr.GetString(2),
                    RegistrationTime = dr.GetDateTime(4),
                    UpdatedTime = dr.GetDateTime(5)
                };

                Console.WriteLine($"ID: {user.Id}, Név: {user.UserName}, Sportág: {user.}, Regisztrált: {user.RegistrationTime}, Módosítva: {user.UpdatedTime}");
            }

            dr.Close();
            conn.Connection.Close();
        }

        static void Main(string[] args)
        {
            GetAllData();
        }
    }
}
