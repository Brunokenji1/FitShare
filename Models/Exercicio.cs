using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Models
{
    public class Exercicio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Series { get; set; }
        public int Repeticoes {  get; set; }
        public int DuracaoMinutos { get; set; }
        public string ImagemUrl { get; set; }
    }
}
