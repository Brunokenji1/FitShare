using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppFitShare.Models
{
    public class Lembrete : INotifyPropertyChanged
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public TimeSpan Horario { get; set; }
        public List<DayOfWeek> DiasDaSemana { get; set; } = new List<DayOfWeek>();
        public bool Ativo { get; set; }

        private Color _corDeFundo = Color.FromArgb("#f0f0f0"); 

        public Color CorDeFundo
        {
            get => _corDeFundo;
            set
            {
                if (_corDeFundo != value)
                {
                    _corDeFundo = value;
                    OnPropertyChanged(); 
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string DiasDaSemanaFormatado
        {
            get
            {
                if (DiasDaSemana == null || DiasDaSemana.Count == 0)
                {
                    return "Único (Próximo Ciclo)"; 
                }

                var abbreviations = new Dictionary<DayOfWeek, string>
        {
            { DayOfWeek.Sunday, "Dom" },
            { DayOfWeek.Monday, "Seg" },
            { DayOfWeek.Tuesday, "Ter" },
            { DayOfWeek.Wednesday, "Qua" },
            { DayOfWeek.Thursday, "Qui" },
            { DayOfWeek.Friday, "Sex" },
            { DayOfWeek.Saturday, "Sáb" }
        };

                var selectedDays = DiasDaSemana
                    .OrderBy(d => d)
                    .Select(d => abbreviations[d]);

                return string.Join(", ", selectedDays);
            }
        }
    }
}