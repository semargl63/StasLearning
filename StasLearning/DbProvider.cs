using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StasLearning
{
    class DbProvider
    {
        private string _connectionString = @"Server=SLACKERHOLE\SQLEXPRESS;Database=Learning;Trusted_Connection=True;";
        private string _readUserById = "SELECT * FROM Users2 WHERE Id = '{0}'";
        private string _writeUserSQL = "INSERT INTO Users2 VALUES ('{0}', '{1}', '{2}')";
        private MSSQL _connection;

        public DbProvider()
        {
            _connection = CreateConnection();
        }

        #region Write methods
        public void WriteToBase(User user)
        {
            try
            { 
                _connection.Execute(string.Format(_writeUserSQL, user.Id, user.Name, user.BirthDate.ToString("yyyy-MM-dd")));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        public User ReadFromBase(string id)
        {
            try
            {
                var reader = _connection.Read(string.Format(_readUserById, id));
                if (reader.Read())
                {
                    return new User { Id = id, Name = reader["Name"].ToString(), BirthDate = DateTime.Parse(reader["BirthDate"].ToString()) };
                }
                else
                {
                    Console.WriteLine($"There is no user with id {id}");
                    return null;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private MSSQL CreateConnection()
        {
            return MSSQL.Connect(_connectionString);
        }
    }
}
