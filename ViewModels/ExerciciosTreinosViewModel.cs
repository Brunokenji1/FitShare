using CommunityToolkit.Mvvm.ComponentModel;
using AppFitShare.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace AppFitShare.ViewModels
{
    public partial class ExerciciosTreinosViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Exercicio> listaDeExercicios;

        //cabecalho
        [ObservableProperty]
        private string nomeDoTreino = "Treino de Pernas"; 

        [ObservableProperty]
        private string totalDuracaoFormatada = "0min 0s";

        [ObservableProperty]
        private int totalCalorias;

        [ObservableProperty]
        private string dificuldadeNivel = "Intermediário";

        public ExerciciosTreinosViewModel()
        {
            listaDeExercicios = new ObservableCollection<Exercicio>();
            CarregarExerciciosEmMemoria();
        }

        private void CarregarExerciciosEmMemoria()
        {
            List<Exercicio> dadosDoTreino = new List<Exercicio>
            {
                new Exercicio { Nome = "Agachamento", Calorias = 200, Dificuldade = 2, Duracao = 300, Imagem = "Images/agachamento.png", Series = 3 },
                new Exercicio { Nome = "Leg Press", Calorias = 180, Dificuldade = 3, Duracao = 500, Imagem = "legpress.png", Series = 3 },
                new Exercicio { Nome = "Extensora", Calorias = 100, Dificuldade = 1, Duracao = 240, Imagem = "extensora.png", Series = 4 },
                new Exercicio { Nome = "Avanço", Calorias = 150, Dificuldade = 2, Duracao = 360, Imagem = "avanco.png", Series = 3 }
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

            TotalDuracaoFormatada = $"{minutos}min {segundos}s";
            TotalCalorias = exercicios.Sum(e => e.Calorias);
        }
    }
}