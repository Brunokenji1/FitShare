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
        private static List<Usuario> usuarios = new List<Usuario>();
        static RepositorioUsuarios()
        {
            CarregarUsuarios();
        }
        public static void Cadastrar(Usuario usuario)
        {
            usuarios.Add(usuario);
            SalvarUsuarios();
        }
        public static Usuario? ObterPorNome(string nome)
        {
            return usuarios.FirstOrDefault(u => u.Nome.Equals(nome));
        }
        public static Usuario? ObterPorEmail(string email)
        {
            return usuarios.FirstOrDefault(u => u.Email.Equals(email));
        }
        public static List<Usuario> ListarTodos()
        {
            return usuarios;
        }
        public static void Atualizar(Usuario usuario)
        {
            var index = usuarios.FindIndex(u => u.Email == usuario.Email);

            if (index >= 0)
            {
                usuarios[index] = usuario;
                SalvarUsuarios();
            }
        }
        private static void SalvarUsuarios()
        {
            string json = JsonSerializer.Serialize(usuarios);
            File.WriteAllText(path, json);
        }

        private static void CarregarUsuarios()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                usuarios = JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();
            }
        }

    
    }
}
