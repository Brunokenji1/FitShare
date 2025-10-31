using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Models
{
    internal class Treino
    {
        public int ID {  get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Exercicio> Exercicios { get; set; } = new();


    }
}
