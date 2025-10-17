using AppFitShare.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Repositories
{
    internal class RepositorioUsuarios
    {
        public List<Usuario> Usuarios { get; set; }
        public List<Usuario> GetUsers()
        {
            List<Usuario> users = new List<Usuario>();
            users.Add(new Usuario(1, "João Silva", "boa@gmail", "123456"));
            return users;
        }
    }
}
