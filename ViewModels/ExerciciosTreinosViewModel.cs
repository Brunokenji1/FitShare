using AppFitShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AppFitShare.ViewModels
{
    public partial class ExerciciosTreinosViewModel : ObservableObject
    {
        [ObservableProperty]
        private Treino treinoSelecionado;
        public ObservableCollection<Exercicio> Exercicios { get; set; } = new ObservableCollection<Exercicio>();
        public ICommand IniciarTreinoCommand { get; }
        public ExerciciosTreinosViewModel()
        {
            var treinoA = new Treino
            {
                Nome = "TREINO X",
                Duracao = "X",
                Series= 2,
                Calorias = 1,
                Dificuldade = "X",
                ListaDeExercicios = new List<Exercicio>
                {
                    new Exercicio{ Nome="Agachamento", Series= 2, Repeticoes= 12},
                    new Exercicio{Nome ="Supino", Series=3, Repeticoes=12 },
                }
            };
            IniciarTreinoCommand = new RelayCommand(IniciarTreino);
            treinoSelecionado = treinoA;
            foreach(var exercicio in treinoA.ListaDeExercicios)
            {
                Exercicios.Add(exercicio);
            }
        }
        private void IniciarTreino()
        {

        }
    }
}
