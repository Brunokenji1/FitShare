using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Models
{
    internal class Treino
    {
        public List<Exercicio> exercicios { get; set; } = new();
        public int Id { get; set; }
        public int IdUsuario {  get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int DuracaoTotalMinutos => exercicios.Sum(e => e.DuracaoMinutos);

        

    }
}
