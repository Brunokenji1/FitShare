using AppFitShare.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppFitShare.ViewModels
{
    public partial class ExerciciosPosturaColuna : ObservableObject
        {
            [ObservableProperty]
            private ObservableCollection<Exercicio> listaDeExercicios = new ObservableCollection<Exercicio>();
            public ExerciciosPosturaColuna()
            {
                ToggleSelecaoCommand = new Command<Exercicio>(ToggleSelecao);
                CarregarExerciciosEmMemoria();
            }
            private void CarregarExerciciosEmMemoria()
            {
                List<Exercicio> dadosDoTreino = new List<Exercicio>
            {
                new Exercicio{ Nome = "Alongamento Peitoral", Calorias = 50, Dificuldade = 1, Duracao = 120, Imagem = "alongamentopeitoral.png", Series = 2, Repeticoes = 10 },
                new Exercicio{ Nome = "Alongamento Dorsais", Calorias = 50, Dificuldade = 1, Duracao = 120, Imagem = "alongamentodorsal.pmg", Series = 2, Repeticoes = 10 },
                new Exercicio{ Nome = "Alongamento Glúteo", Calorias = 50, Dificuldade = 1, Duracao = 120, Imagem = "alongamentogluteo.png", Series = 2, Repeticoes = 10 },
                new Exercicio{ Nome = "Mobilidade Quadril", Calorias = 50, Dificuldade = 1, Duracao = 30, Imagem = "mobilidadequadril.pmg", Series = 2, Repeticoes = 10 },
                new Exercicio{ Nome = "Mobilidade Escápula", Calorias = 50, Dificuldade = 1, Duracao = 120, Imagem = "mobilidadeescapula.png", Series = 2, Repeticoes = 30 },
                new Exercicio{ Nome = "Prancha Frontal", Calorias = 50, Dificuldade = 2, Duracao = 120, Imagem = "pranchafrontal.png", Series = 2, Repeticoes = 12 },
                new Exercicio{ Nome = "Prancha Lateral", Calorias = 50, Dificuldade = 3, Duracao = 120, Imagem = "pranchalateral.png", Series = 2, Repeticoes = 12 },
                new Exercicio{ Nome = "Superman Deitado", Calorias = 50, Dificuldade = 2, Duracao = 120, Imagem = "supermandeitado.png", Series = 2, Repeticoes = 12 },
                new Exercicio{ Nome = "Elevação Pélvica", Calorias = 50, Dificuldade = 3, Duracao = 120, Imagem = "elevacaopelvica.png", Series = 2, Repeticoes = 12 },
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
