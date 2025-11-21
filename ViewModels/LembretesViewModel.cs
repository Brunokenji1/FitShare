using AppFitShare.Models;
using AppFitShare.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.ViewModels
{
    public partial class LembretesViewModel : ObservableObject
    {
        public ObservableCollection<Lembrete> LembretesVisiveis { get; set; } = new ObservableCollection<Lembrete>();
        public ObservableCollection<bool> DiasSelecaoUI { get; set; } = new ObservableCollection<bool> { false, false, false, false, false, false, false };

        [ObservableProperty] private string novoLembreteTexto;
        [ObservableProperty] private TimeSpan horaSelecionada;

        private readonly IDispatcherTimer _timerVigia;

        public LembretesViewModel()
        {
            horaSelecionada = DateTime.Now.TimeOfDay;
            AtualizarListaVisivel();

            _timerVigia = Application.Current.Dispatcher.CreateTimer();
            _timerVigia.Interval = TimeSpan.FromSeconds(10);
            _timerVigia.Tick += VerificarHorarios;
            _timerVigia.Start();
        }
        private void VerificarHorarios(object sender, EventArgs e)
        {
            var agora = DateTime.Now;
            foreach (var item in LembretesVisiveis)
            {
                if (item.IsAtivo && !item.Concluido && !item.JaNotificado && agora.TimeOfDay >= item.HoraAgendada)
                {
                    item.JaNotificado = true;
                    DispararAlarme(item);
                }
            }
        }
        private void DispararAlarme(Lembrete item)
        {
            try
            {
                Vibration.Default.Vibrate(TimeSpan.FromSeconds(1));
            }
            catch { }
            Shell.Current.DisplayAlert("Lembrete", $"Hora de: {item.Descricao}", "OK");
        }

        public void AtualizarListaVisivel()
        {
            LembretesVisiveis.Clear();
            foreach (var item in RepositorioLembretes.ListaLembretes)
            {
                if (item.DeveAparecerHoje())
                {
                    if (item.DataUltimaConclusao?.Date != DateTime.Now.Date) item.JaNotificado = false;
                    LembretesVisiveis.Add(item);
                }
            }
        }
        [RelayCommand]
        private void AdicionarLembrete()
        {
            if (string.IsNullOrWhiteSpace(NovoLembreteTexto)) return;
            var novoItem = new Lembrete
            {
                Descricao = NovoLembreteTexto,
                HoraAgendada = HoraSelecionada,
                DiasDaSemana = ConverterBotoesParaDias(),
                IsAtivo = true
            };

            RepositorioLembretes.Adicionar(novoItem);

            if (novoItem.DeveAparecerHoje())
            {
                LembretesVisiveis.Add(novoItem);
            }
            NovoLembreteTexto = string.Empty;
        }

        [RelayCommand]
        private void ConcluirTarefa(Lembrete item)
        {
            item.DataUltimaConclusao = DateTime.Now;
            item.Concluido = false;

            LembretesVisiveis.Remove(item);
        }

        [RelayCommand]
        private void ExcluirLembrete(Lembrete item)
        {
            RepositorioLembretes.Remover(item);
            LembretesVisiveis.Remove(item);
        }

        [RelayCommand]
        private void ToggleDia(string indexStr)
        {
            if (int.TryParse(indexStr, out int index))
            {
                DiasSelecaoUI[index] = !DiasSelecaoUI[index];
            }
        }

        private List<DayOfWeek> ConverterBotoesParaDias()
        {
            var lista = new List<DayOfWeek>();
            if (DiasSelecaoUI[0]) lista.Add(DayOfWeek.Sunday);
            if (DiasSelecaoUI[1]) lista.Add(DayOfWeek.Monday);
            if (DiasSelecaoUI[2]) lista.Add(DayOfWeek.Tuesday);
            if (DiasSelecaoUI[3]) lista.Add(DayOfWeek.Wednesday);
            if (DiasSelecaoUI[4]) lista.Add(DayOfWeek.Thursday);
            if (DiasSelecaoUI[5]) lista.Add(DayOfWeek.Friday);
            if (DiasSelecaoUI[6]) lista.Add(DayOfWeek.Saturday);
            return lista;
        }

    }
}
