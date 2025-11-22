using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Dispatching;
using System.Collections.ObjectModel;
using AppFitShare.Models;
using AppFitShare.Repositories;
using AppFitShare.Views; // Para achar a página de adicionar

namespace AppFitShare.ViewModels
{
    public partial class LembretesViewModel : ObservableObject
    {
        public ObservableCollection<Lembrete> LembretesVisiveis { get; set; } = new ObservableCollection<Lembrete>();

        // Botões de dias (D, S, T...)
        public ObservableCollection<bool> DiasSelecaoUI { get; set; }
            = new ObservableCollection<bool> { false, false, false, false, false, false, false };

        [ObservableProperty] private string novoLembreteTexto;
        [ObservableProperty] private TimeSpan horaSelecionada;

        private readonly IDispatcherTimer _timerVigia;

        public LembretesViewModel()
        {
            HoraSelecionada = DateTime.Now.TimeOfDay;
            AtualizarListaVisivel();

            // Timer para o Alarme (Roda em primeiro plano)
            _timerVigia = Application.Current.Dispatcher.CreateTimer();
            _timerVigia.Interval = TimeSpan.FromSeconds(10);
            _timerVigia.Tick += VerificarHorarios;
            _timerVigia.Start();
        }

        public void AtualizarListaVisivel()
        {
            LembretesVisiveis.Clear();
            foreach (var item in RepositorioLembretes.ListaLembretes)
            {
                if (item.DeveAparecerHoje())
                {
                    // Reseta notificação se virou o dia
                    if (item.DataUltimaConclusao?.Date != DateTime.Now.Date) item.JaNotificado = false;
                    LembretesVisiveis.Add(item);
                }
            }
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
            try { Vibration.Default.Vibrate(TimeSpan.FromSeconds(1)); } catch { }
            Application.Current.MainPage.DisplayAlert("Lembrete", $"Hora de: {item.Descricao}", "OK");
        }

        // --- NAVEGAÇÃO ---

        [RelayCommand]
        private async Task GoToAdicionar()
        {
            NovoLembreteTexto = "";
            // Navega para a tela de cadastro usando PushAsync (funciona com TabbedPage)
            await Application.Current.MainPage.Navigation.PushAsync(new AdicionarLembretePage());
        }

        [RelayCommand]
        private async Task SalvarLembrete()
        {
            if (string.IsNullOrWhiteSpace(NovoLembreteTexto)) return;

            var novoItem = new Lembrete
            {
                Descricao = NovoLembreteTexto,
                HoraAgendada = HoraSelecionada,
                DiasDaSemana = ConverterBotoes(),
                IsAtivo = true
            };

            RepositorioLembretes.Adicionar(novoItem);

            // Volta para a lista
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        private void Concluir(Lembrete item)
        {
            item.DataUltimaConclusao = DateTime.Now;
            item.Concluido = false;
            LembretesVisiveis.Remove(item);
        }

        [RelayCommand]
        private void Excluir(Lembrete item)
        {
            if (RepositorioLembretes.ListaLembretes.Contains(item)) RepositorioLembretes.Remover(item);
            if (LembretesVisiveis.Contains(item)) LembretesVisiveis.Remove(item);
        }

        [RelayCommand]
        private void ToggleDia(string indexStr)
        {
            if (int.TryParse(indexStr, out int index)) DiasSelecaoUI[index] = !DiasSelecaoUI[index];
        }

        private List<DayOfWeek> ConverterBotoes()
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