using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Models
{
    public class PlanoAlimentarCafeManha
    {
        public string Nome { get; set; }
        public int Calorias { get; set; }
        public int TotalCalorias { get; set; }
        public int MetaCalorias { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Imagem { get; set; }
    }
    public class PlanoAlimentarAlmoco
    {
        public string Nome { get; set; }
        public int Calorias { get; set; }
        public int TotalCalorias { get; set; }
        public int MetaCalorias { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Imagem { get; set; }
    }

    public class PlanoAlimentarCafeTarde
    {
        public string Nome { get; set; }
        public int Calorias { get; set; }
        public int TotalCalorias { get; set; }
        public int MetaCalorias { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Imagem { get; set; }
    }
    public class PlanoAlimentarJantar
    {
        public string Nome { get; set; }
        public int Calorias { get; set; }
        public int TotalCalorias { get; set; }
        public int MetaCalorias { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Imagem { get; set; }
    }
}
