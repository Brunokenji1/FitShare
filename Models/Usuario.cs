using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Models
{
    public class Usuario
    {
        //Dados cadastro basico usuario
        public int Id { get; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }


        //Dados cadastro completo usuario
        public string FotoPath { get; set; }

        public int Idade { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public string Metabolismo { get; set; }
        public string Status { get; set; }
        public string Telefone { get; set; }
        public UsuarioCompleto? CadastroCompleto { get; set; }

        public Usuario(int id, string nome, string username, string email, string senha, DateTime DataCdastro)
        {
            Id = id;
            Nome = nome;
            Username = username;
            Email = email;
            Senha = senha;
            Status = "Incompleto";
            DataCadastro = DataCdastro;
        }

    }
}
