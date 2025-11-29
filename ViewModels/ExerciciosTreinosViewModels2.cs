using CommunityToolkit.Mvvm.ComponentModel;
using AppFitShare.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace AppFitShare.ViewModels
{
    public partial class ExerciciosTreinosViewModels2 : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Exercicio> listaDeExercicios;
        
        [ObservableProperty]
        private string nomeDoTreino = "Membros Inferiores";

        [ObservableProperty]
        private string totalDuracaoFormatada = "0min 0s";

        [ObservableProperty]
        private int totalCalorias = 0;

        [ObservableProperty]
        private string dificuldadeNivel = "Intermediário";

        public ExerciciosTreinosViewModels2()
        {
            listaDeExercicios = new ObservableCollection<Exercicio>();
            CarregarExerciciosEmMemoria();
        }

        private void CarregarExerciciosEmMemoria()
        {
            List<Exercicio> dadosDoTreino = new List<Exercicio>
            {
                new Exercicio { Nome = "Alongamento Peitoral", Calorias = 50, Dificuldade = 1, Duracao = 120, Imagem = "alongamentopeitoral.png", Series = 2, Repeticoes = 10 },
                new Exercicio { Nome = "Alongamento Dorsais", Calorias = 50, Dificuldade = 1, Duracao = 120, Imagem = "alongamentodorsal.pmg", Series = 2, Repeticoes = 10 },
                new Exercicio { Nome = "Mobilidade Quadril", Calorias = 50, Dificuldade = 1, Duracao = 30, Imagem = "mobilidadequadril.pmg", Series = 2, Repeticoes = 10 },
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