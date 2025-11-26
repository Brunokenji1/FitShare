using AppFitShare.Models;
using AppFitShare.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        public ObservableCollection<DiasStreak> StreakSemanal { get; set; } = new ObservableCollection<DiasStreak>();
        [ObservableProperty]
        private string textoSequencia;

        public HomeViewModel()
        {
            CarregarDados();
        }
        public void CarregarDados()
        {
            int dias = RepositorioHistorico.CalcularSequencuiaAtual();
            TextoSequencia = $"{dias} dias";

            StreakSemanal.Clear();

            DateTime hoje = DateTime.Today;
            int diferencaParaDomingo = (int)hoje.DayOfWeek;
            DateTime domingo = hoje.AddDays(-diferencaParaDomingo);

            for(int i=0; i<7; i++)
            {
                DateTime dataAtual = domingo.AddDays(i);
                StreakSemanal.Add(new DiasStreak
                {
                    LetraDia = ObterLetraDia(dataAtual.DayOfWeek),
                    Concluido = RepositorioHistorico.VerificarTreinouNoDia(dataAtual),
                    Data = dataAtual
                });
            }

        }
        private string ObterLetraDia(DayOfWeek diaSemana) => diaSemana switch
        {

            DayOfWeek.Sunday => "D",
            DayOfWeek.Monday => "S",
            DayOfWeek.Tuesday => "T",
            DayOfWeek.Wednesday => "Q",
            DayOfWeek.Thursday => "Q",
            DayOfWeek.Friday => "S",
            DayOfWeek.Saturday => "S",
            _ => "?"

        };

    }
}
