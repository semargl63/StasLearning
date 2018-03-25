using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StasLearning
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class UsersList
    {
        public List<User> Users { get; set; }
    }
}
