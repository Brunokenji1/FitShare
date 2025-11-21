using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Models
{
    public class Lembrete
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public TimeSpan HoraAgendada { get; set; }

        public List<DayOfWeek> DiasDaSemana { get; set; }
        public DateTime? DataUltimaConclusao { get; set; }

        public bool IsAtivo { get; set; } = true;
        public bool JaNotificado { get; set; } = false;
        public bool Concluido { get; set; }
        public bool EhRecorrente => DiasDaSemana != null && DiasDaSemana.Count > 0;
        public Lembrete()
        {
            Id = Guid.NewGuid().ToString();
            DiasDaSemana = new List<DayOfWeek>();
            HoraAgendada = DateTime.Now.TimeOfDay;
        }
        public bool DeveAparecerHoje()
        {
            if (!IsAtivo) return false;
            var hoje = DateTime.Now.Date;

            if (DataUltimaConclusao.HasValue && DataUltimaConclusao.Value.Date == hoje) return false;

            if (EhRecorrente)
            {
                return DiasDaSemana.Contains(DateTime.Now.DayOfWeek);
            }
            else
            {
                return true;
            }
        }

    }
}