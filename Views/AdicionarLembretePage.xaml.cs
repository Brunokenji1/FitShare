using System.Collections.Generic;
using AppFitShare.Models;
using AppFitShare.Repositories;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace AppFitShare.Views
{
    public partial class AdicionarLembretePage : ContentPage
    {
        private List<DayOfWeek> _diasSelecionados = new List<DayOfWeek>();

        private readonly Color _corSelecionada = Color.FromArgb("#01b853"); 
        private readonly Color _corTextoSelecionado = Color.FromArgb("#01b853");
        private readonly Color _corTransparente = Colors.Transparent;
        private readonly Color _corTextoPadrao = Colors.Gray; 

        public AdicionarLembretePage()
        {
            InitializeComponent();
            RepositorioUsuarios.IniciarUsuarioTemp();
        }

        private void Dia_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (Enum.TryParse<DayOfWeek>(button.ClassId, out DayOfWeek diaClicado))
            {
                if (_diasSelecionados.Contains(diaClicado))
                {
                    _diasSelecionados.Remove(diaClicado);
                }
                else
                {
                    _diasSelecionados.Add(diaClicado);
                }

                AtualizarVisualBotoes();
            }
        }

        private void AtualizarVisualBotoes()
        {
            var listaBotoes = new List<Button> { btn_segunda, btn_terca, btn_quarta, btn_quinta, btn_sexta, btn_sabado, btn_domingo };

            foreach (var btn in listaBotoes)
            {
                if (Enum.TryParse<DayOfWeek>(btn.ClassId, out DayOfWeek diaDoBotao))
                {
                    if (_diasSelecionados.Contains(diaDoBotao))
                    {
                        btn.BackgroundColor = _corSelecionada;
                        btn.TextColor = _corTextoSelecionado;
                    }
                    else
                    {
                        btn.BackgroundColor = _corTransparente;
                        btn.TextColor = _corTextoPadrao;
                    }
                }
            }
        }

        private async void BtnSalvarLembrete(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTitulo.Text))
                {
                    await DisplayAlert("Erro", "O título do treino é obrigatório.", "OK");
                    return;
                }

                var novoLembrete = new Lembrete
                {
                    Titulo = txtTitulo.Text,
                    Descricao = txtDescricao.Text,
                    Horario = pickerHora.Time,
                    DiasDaSemana = _diasSelecionados, 
                    Ativo = true
                };

                var usuarioLogadoTemp = RepositorioUsuarios.ObterUsuarioTemp();

                string mensagemConfirmacao = _diasSelecionados.Count > 0
                    ? "Criar lembrete recorrente?"
                    : "Criar lembrete único para hoje?";

                bool confirmacao = await DisplayAlert("Confirmação", mensagemConfirmacao, "Sim", "Não");

                if (confirmacao)
                {
                    usuarioLogadoTemp.Lembretes.Add(novoLembrete);
                    RepositorioUsuarios.Atualizar(usuarioLogadoTemp);

                    await DisplayAlert("Sucesso", "Lembrete cadastrado com sucesso!", "Fechar");
                    App.Current.MainPage = new NavigationPage(new TabbedPageMenu());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Ocorreu um erro ao salvar o lembrete: {ex.Message}", "OK");
            }
        }

        private async void BtnCancelar(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Ocorreu um erro ao cancelar: {ex.Message}", "OK");
            }
        }
    }
}