using AppFitShare.Models;
using AppFitShare.Repositories;
using AppFitShare.ViewModels;
using System.Collections.ObjectModel;

namespace AppFitShare.Views{

    public partial class Agenda : ContentPage
    {

        public ObservableCollection<Lembrete> Lembretes { get; set; } = new ObservableCollection<Lembrete>();

        private IDispatcherTimer _timer;

        public Agenda()
        {
            InitializeComponent();

            CollectionViewLembretes.ItemsSource = Lembretes;

            ConfigurarTimer();
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

            foreach (var item in Lembretes)
            {
                if (item.Ativo &&
                    item.DiasDaSemana.Contains(agora.DayOfWeek) &&
                    item.Horario.Hours == agora.Hour &&
                    item.Horario.Minutes == agora.Minute)
                {
                    await DisplayAlert("Lembrete!", $"{item.Titulo}\n{item.Descricao}", "OK");

                }
            }
        }

        private async void BtnAdicionarLembrete(object sender, EventArgs e)
        {
            string titulo = await DisplayPromptAsync("Novo Lembrete", "Qual o título do lembrete?");
            if (string.IsNullOrEmpty(titulo)) return;

            string horaString = await DisplayPromptAsync("Horário", "Digite a hora (Ex: 14:30)", initialValue: DateTime.Now.ToString("HH:mm"));
            if (!TimeSpan.TryParse(horaString, out TimeSpan horario))
            {
                await DisplayAlert("Erro", "Horário inválido", "OK");
                return;
            }

            string descricao = await DisplayPromptAsync("Descrição", "Alguma observação?", initialValue: "Tomar remédio");

            bool todosOsDias = await DisplayAlert("Repetição", "Repetir todos os dias?", "Sim", "Apenas Hoje");

            var dias = new List<DayOfWeek>();
            if (todosOsDias)
            {
                dias.AddRange(Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>());
            }
            else
            {
                dias.Add(DateTime.Now.DayOfWeek);
            }

            Lembretes.Add(new Lembrete
            {
                Titulo = titulo,
                Descricao = descricao,
                Horario = horario,
                DiasDaSemana = dias,
                Ativo = true
            });
        }
    }
}
