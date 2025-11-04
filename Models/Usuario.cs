using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Models
{
    public class Usuario : INotifyPropertyChanged
    {
        //Dados cadastro basico usuario
        public int Id { get; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }

        //Dados cadastro completo usuario
        public int _idade;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public int Idade
        {
            get { return _idade; }
            set { _idade = value; OnPropertyChanged(nameof(Idade)); }
        }
        public double Peso { get; private set; }
        public double Altura { get; private set; }
        public string Metabolismo { get; private set; }
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
