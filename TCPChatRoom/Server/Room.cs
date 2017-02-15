using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide
{
    public class Room
    {
        Dictionary<User, int> users;
        public string name;
        public string password;
        public Room()
        {
            users = new Dictionary<User, int>();
        }
    }
}
