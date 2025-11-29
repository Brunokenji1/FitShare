using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppFitShare.Models
{

    public class Exercicio : INotifyPropertyChanged
    {
        public Treino? Treino { get; set; }
        public string? Nome { get; set; }
        public int Calorias { get; set; }
        public int Dificuldade { get; set; }
        public int Duracao { get; set; }
        public int Series { get; set; }
        public int Repeticoes { get; set; }
        public string Imagem { get; set; }
        public string TipoTreino { get; set; }

        private bool _estaSelecionado;
        public bool EstaSelecionado
        {
            get => _estaSelecionado;
            set
            {
                if (_estaSelecionado != value)
                {
                    _estaSelecionado = value;
                    OnPropertyChanged();
                }
            }
        }
        public string DuracaoFormatada
        {
            get
            {
                int minutos = Duracao / 60;
                int segundos = Duracao % 60;
                return $"{minutos}min : {segundos}s";
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
