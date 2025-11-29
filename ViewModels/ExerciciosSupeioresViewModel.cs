using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFitShare.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace AppFitShare.ViewModels
{
    public partial class ExerciciosSupeioresViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Exercicio> listaDeExercicios = new ObservableCollection<Exercicio>();
        public ExerciciosSupeioresViewModel()
        {
            ToggleSelecaoCommand = new Command<Exercicio>(ToggleSelecao);
            CarregarExerciciosEmMemoria();
        }
        private void CarregarExerciciosEmMemoria()
        {
            List<Exercicio> dadosDoTreino = new List<Exercicio>
            {
                new Exercicio{ Nome = "Alongamento Braço", Calorias = 50, Dificuldade = 1, Duracao = 120, Imagem = "alongamentobraco.png", Series = 2, Repeticoes = 10 },
                new Exercicio{ Nome = "Alongamento Ombro", Calorias = 50, Dificuldade = 1, Duracao = 120, Imagem = "alongamentoombro.pmg", Series = 2, Repeticoes = 10 },
                new Exercicio{ Nome = "Alongamento Punho", Calorias = 50, Dificuldade = 1, Duracao = 120, Imagem = "alongamentopunho.png", Series = 2, Repeticoes = 10 },
                new Exercicio{ Nome = "Mobilidade Escápula", Calorias = 50, Dificuldade = 1, Duracao = 120, Imagem = "mobilidadeescapula.png", Series = 2, Repeticoes = 30 },
                new Exercicio{ Nome = "Remada Horizontal", Calorias = 50, Dificuldade = 2, Duracao = 120, Imagem = "remadahorizontal.png", Series = 3, Repeticoes = 15 },
                new Exercicio{ Nome = "Flexão de Braço", Calorias = 50, Dificuldade = 3, Duracao = 120, Imagem = "flexaodebraco.png", Series = 3, Repeticoes = 15 },
                new Exercicio{ Nome = "Bíceps", Calorias = 50, Dificuldade = 2, Duracao = 120, Imagem = "biceps.png", Series = 3, Repeticoes = 15 },
                new Exercicio{ Nome = "Tríceps", Calorias = 50, Dificuldade = 3, Duracao = 120, Imagem = "triceps.png", Series = 3, Repeticoes = 15 },
                new Exercicio{ Nome = "Supino", Calorias = 50, Dificuldade = 3, Duracao = 120, Imagem = "supino.png", Series = 3, Repeticoes = 15 },

            };

            if (dadosDoTreino.Any())
            {
                listaDeExercicios.Clear();

                foreach (var exercicio in dadosDoTreino)
                {
                    listaDeExercicios.Add(exercicio);
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
