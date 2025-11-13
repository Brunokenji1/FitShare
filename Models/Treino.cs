using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Models
{
    public class Treino
    {
        public List<Exercicio> ListaDeExercicios { get; set; } = new();
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Duracao { get; set; }
        public int Calorias { get; set; }
        public string Dificuldade { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
