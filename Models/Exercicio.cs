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
        public int Calorias { get; set; }
        public int Dificuldade { get; set; }
        public int Duracao { get; set; }
        public int Series { get; set; }
        public int Repeticoes {  get; set; }
        public string Imagem { get; set; }

        public string DuracaoFormatada
        {
            get
            {
                int minutos = Duracao / 60;
                int segundos = Duracao % 60;
                return $"{minutos}min {segundos}s";
            }
        }

    }
}
