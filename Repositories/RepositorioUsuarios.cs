using AppFitShare.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace AppFitShare.Repositories
{
    public class RepositorioUsuarios
    {
        private static string path = Path.Combine(FileSystem.AppDataDirectory, "usuarios.json");
        private static List<Usuario> listaUsuarios = new List<Usuario>();
        static RepositorioUsuarios()
        {
            CarregarUsuarios();
        }
        public static void Cadastrar(Usuario usuario)
        {
            listaUsuarios.Add(usuario);
            SalvarUsuarios();
        }
        public static Usuario? ObterPorNome(string nome)
        {
            return listaUsuarios.FirstOrDefault(u => u.Nome.Equals(nome));
        }
        public static Usuario? ObterPorEmail(string email)
        {
            return listaUsuarios.FirstOrDefault(u => u.Email.Equals(email));
        }
        public static List<Usuario> ListarTodos()
        {
            return listaUsuarios;
        }
        public static void Atualizar(Usuario usuario)
        {
            var index = listaUsuarios.FindIndex(u => u.Email == usuario.Email);

            if (index >= 0)
            {
                listaUsuarios[index] = usuario;
                SalvarUsuarios();
            }
        }
        private static void SalvarUsuarios()
        {
            string json = JsonSerializer.Serialize(listaUsuarios);
            File.WriteAllText(path, json);
        }

        private static void CarregarUsuarios()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                listaUsuarios = JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();
            }
        }

    
    }
}
