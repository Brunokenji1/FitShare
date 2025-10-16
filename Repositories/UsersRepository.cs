using AppFitShare.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Repositories
{
    internal class UsersRepository
    {
        public List<User> Usuarios { get; set; }
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User(1, "João Silva", "boa@gmail", "123456", DateTime.Now));
            return users;
        }
    }
}
