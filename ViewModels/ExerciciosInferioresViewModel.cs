using AppFitShare.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace AppFitShare.ViewModels
{
    public partial class ExerciciosInferioresViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Exercicio> listaDeExercicios = new ObservableCollection<Exercicio>();

        public ExerciciosInferioresViewModel()
        {
            ToggleSelecaoCommand = new Command<Exercicio>(ToggleSelecao);
            CarregarExerciciosEmMemoria();
        }

        private void CarregarExerciciosEmMemoria()
        {
            List<Exercicio> dadosDoTreino = new List<Exercicio>
            {
                new Exercicio { Nome = "Alongamento coxa", Calorias = 50, Dificuldade = 1, Duracao = 120, Imagem = "alongamento_coxa.png", Series = 2, Repeticoes = 30 },
                new Exercicio { Nome = "Alongamento posterior", Calorias = 50, Dificuldade = 1, Duracao = 120, Imagem = "alongamento_posterior_coxa.png", Series = 2 , Repeticoes = 30},
                new Exercicio { Nome = "Alongamento panturrilha", Calorias = 50, Dificuldade = 1, Duracao = 120, Imagem = "panturrilha.png", Series = 2 , Repeticoes = 30},
                new Exercicio { Nome = "Agachamento livre", Calorias = 210, Dificuldade = 2, Duracao = 240, Imagem = "agachamento.png" , Series= 3, Repeticoes=15 },
                new Exercicio { Nome = "Abdutor", Calorias = 180, Dificuldade = 1, Duracao = 180, Imagem = "abdutora.png" , Series= 3, Repeticoes=15 },
                new Exercicio { Nome = "Panturrilha", Calorias = 150, Dificuldade = 1, Duracao = 180, Imagem = "panturrilha.png" , Series= 3, Repeticoes=15 },
                new Exercicio { Nome = "Afundo", Calorias = 200, Dificuldade = 2, Duracao = 300, Imagem = "afundo.png" , Series= 3, Repeticoes=15 },
                new Exercicio { Nome = "Panturrilha sentado", Calorias = 150, Dificuldade = 2, Duracao = 300, Imagem = "panturrilha_sentado.png" , Series= 3, Repeticoes=15 },
            };

            if (dadosDoTreino.Any())
            {
                ListaDeExercicios.Clear();

                foreach (var exercicio in dadosDoTreino)
                {
                    ListaDeExercicios.Add(exercicio);
                }

                CalcularMetricas(dadosDoTreino);
            }
        }

        private void CalcularMetricas(List<Exercicio> exercicios)
        {
            int totalSegundos = exercicios.Sum(e => e.Duracao);
            int minutos = totalSegundos / 60;
            int segundos = totalSegundos % 60;
        }
        public ICommand ToggleSelecaoCommand { get; private set; }
        private void ToggleSelecao(Exercicio exercicio)
        {
            if (exercicio != null)
            {
                exercicio.EstaSelecionado = !exercicio.EstaSelecionado;
            }
        }
    }
}