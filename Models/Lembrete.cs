using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Models
{
    public class Lembrete
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public TimeSpan Horario { get; set; }
        public List<DayOfWeek> DiasDaSemana { get; set; } // Ex: Segunda, Quarta...
        public bool Ativo { get; set; } = true;

        // Propriedades formatadas para exibir no XAML
        public string HorarioFormatado => Horario.ToString(@"hh\:mm");
        public string DiasResumo => DiasDaSemana.Count == 7 ? "Todos os dias" : string.Join(", ", DiasDaSemana);
    }
}