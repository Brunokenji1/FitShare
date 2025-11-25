using System.Collections.ObjectModel;
using AppFitShare.Models; 
using AppFitShare.Repositories;
using Microsoft.Maui.Controls;

namespace AppFitShare.Views
{
    public partial class Agenda : ContentPage
    {
        private readonly Color _corPadrao = Color.FromArgb("#f0f0f0");
        private readonly Color _corAtrasada = Color.FromArgb("#ffcccc");

        public ObservableCollection<Lembrete> Lembretes { get; set; } = new ObservableCollection<Lembrete>();
        private IDispatcherTimer _timer;

        public Agenda()
        {
            InitializeComponent();
            CollectionViewLembretes.ItemsSource = Lembretes;
            ConfigurarTimer();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CarregarDados();
        }

        private void CarregarDados()
        {
            var dadosDoRepo = RepositorioUsuarios.ObterLembretesUsuarioLogado();
            Lembretes.Clear();

            if (dadosDoRepo != null)
            {
                foreach (var item in dadosDoRepo)
                {
                    item.CorDeFundo = _corPadrao;
                    Lembretes.Add(item);
                }
            }
        }

        private async void BtnAdicionarLembrete(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdicionarLembretePage());
        }

        private void ConfigurarTimer()
        {
            _timer = Dispatcher.CreateTimer();
            _timer.Interval = TimeSpan.FromSeconds(30);
            _timer.Tick += VerificarLembretes;
            _timer.Start();
        }

        private async void VerificarLembretes(object sender, EventArgs e)
        {
            var agora = DateTime.Now;
            var diaAtual = agora.DayOfWeek;

            foreach (var item in Lembretes.ToList())
            {
                if (!item.Ativo)
                {
                    item.CorDeFundo = _corPadrao;
                    continue;
                }

                bool ehDiaCerto = item.DiasDaSemana.Count == 0 || item.DiasDaSemana.Contains(diaAtual);

                if (!ehDiaCerto) continue;

                bool horarioAtrasado = agora.TimeOfDay > item.Horario;

                bool naoDeveFicarVermelhoHoje = item.DiasDaSemana.Count == 0 && horarioAtrasado;

                if (horarioAtrasado && !naoDeveFicarVermelhoHoje)
                {
                    item.CorDeFundo = _corAtrasada;
                }
                else
                {
                    item.CorDeFundo = _corPadrao;
                }

                bool horaDeTocar = item.Horario.Hours == agora.Hour &&
                                   item.Horario.Minutes == agora.Minute;

                if (horaDeTocar && item.Ativo)
                {
                    item.Ativo = false;

                    await DisplayAlert("Lembrete!", $"{item.Titulo}\n{item.Descricao}", "OK");

                    Lembretes.Remove(item);

                    var usuario = RepositorioUsuarios.ObterUsuarioTemp();
                    var lembreteParaRemover = usuario.Lembretes
                        .FirstOrDefault(l => l.Titulo == item.Titulo && l.Horario == item.Horario);

                    if (lembreteParaRemover != null)
                    {
                        usuario.Lembretes.Remove(lembreteParaRemover);
                        RepositorioUsuarios.Atualizar(usuario);
                    }
                }
            }
        }

        private void OnLembreteToggled(object sender, ToggledEventArgs e)
        {
            var toggleSwitch = sender as Switch;
            if (toggleSwitch == null) return;

            var lembreteAlterado = toggleSwitch.BindingContext as Lembrete;
            if (lembreteAlterado == null) return;

            var usuario = RepositorioUsuarios.ObterUsuarioTemp();
            if (usuario == null) return;

            var lembreteNoRepositorio = usuario.Lembretes
                .FirstOrDefault(l => l.Titulo == lembreteAlterado.Titulo && l.Horario == lembreteAlterado.Horario);

            if (lembreteNoRepositorio != null)
            {
                bool novoEstadoAtivo = e.Value;
                lembreteNoRepositorio.Ativo = novoEstadoAtivo;

                if (novoEstadoAtivo == false)
                {
                    lembreteAlterado.CorDeFundo = _corPadrao;
                    lembreteNoRepositorio.CorDeFundo = _corPadrao;
                }
                else
                {
                    lembreteAlterado.CorDeFundo = _corPadrao;
                    lembreteNoRepositorio.CorDeFundo = _corPadrao;
                }

                RepositorioUsuarios.Atualizar(usuario);
            }
        }
    }
}