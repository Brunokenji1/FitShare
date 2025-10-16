using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Models
{
    internal class User
    {
        public int Id { get; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Idade { get; private set; }
        public double Peso { get; private set; }
        public double Altura { get; private set; }
        public string Metabolismo { get; private set; }
        public string Status { get; set; }

        public User(int id, string nome, string email, string senha, DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            DataCadastro = dataCadastro;
            Status = "Incompleto";
        }
        public void CadastroCompleto(int idade, double peso, double altura, string metabolismo)
        {
            Idade = idade;
            Peso = peso;
            Altura = altura;
            Metabolismo = metabolismo;
            Status = "Ativo";
        }
        public void ExibirDadosUsuario()
        {
            Console.WriteLine($"Usuario: {Nome}");
            Console.WriteLine($"Idade: {Idade}");
            Console.WriteLine($"Peso: {Peso:F2}Kg");
            Console.WriteLine($"Altura: {Altura:F2}m");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine();
        }
    }
}
