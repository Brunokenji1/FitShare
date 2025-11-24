using System.Collections.Generic;
using AppFitShare.Repositories;
using Microsoft.Maui.Controls;

namespace AppFitShare.Views.TelasCadastroCompleto
{
    public partial class CadastroAlergiaAlimentar : ContentPage
    {
        private List<string> _alergiasSelecionadas = new List<string>();
         
        private readonly Color _corSelecionada = Color.FromArgb("#01b853");
        private readonly Color _corTransparente = Colors.Transparent;

        public CadastroAlergiaAlimentar()
        {
            InitializeComponent();
            RepositorioUsuarios.IniciarUsuarioTemp();
        }

        private void GerenciarSelecao(string alergia)
        {
           
            if (alergia == "Não")
            {
                if (_alergiasSelecionadas.Contains("Não"))
                {
                    _alergiasSelecionadas.Remove("Não");
                }
                else
                {
                    _alergiasSelecionadas.Clear();
                    _alergiasSelecionadas.Add("Não");
                }
            }
            else
            {
                if (_alergiasSelecionadas.Contains("Não"))
                {
                    _alergiasSelecionadas.Remove("Não");
                }

                if (_alergiasSelecionadas.Contains(alergia))
                {
                    _alergiasSelecionadas.Remove(alergia);
                }
                else
                {
                    _alergiasSelecionadas.Add(alergia);
                }
            }
            AtualizarVisualBotoes();
        }

        private void AtualizarVisualBotoes()
        {
            var botoes = new List<Border>{ btn_nao, btn_lactose, btn_nozes, btn_soja, btn_frutos_do_mar, btn_amendoim, btn_peixe, btn_ovo};

            foreach (var btn in botoes)
            {
                string id = btn.ClassId;

                if (_alergiasSelecionadas.Contains(id))
                {
                    btn.BackgroundColor = _corSelecionada;
                }
                else
                {
                    btn.BackgroundColor = _corTransparente;
                }
            }
        }

        private void BtnNao(object sender, TappedEventArgs e) => GerenciarSelecao("Não");

        private void BtnLactose(object sender, TappedEventArgs e) => GerenciarSelecao("Lactose");

        private void BtnNozes(object sender, TappedEventArgs e) => GerenciarSelecao("Nozes");

        private void BtnSoja(object sender, TappedEventArgs e) => GerenciarSelecao("Soja");

        private void BtnFrutosDoMar(object sender, TappedEventArgs e) => GerenciarSelecao("Frutos do mar");

        private void BtnAmendoim(object sender, TappedEventArgs e) => GerenciarSelecao("Amendoim");

        private void BtnPeixe(object sender, TappedEventArgs e) => GerenciarSelecao("Peixe");

        private void BtnOvo(object sender, TappedEventArgs e) => GerenciarSelecao("Ovo");

        private async void BtnContinuar(object sender, EventArgs e)
        {
            if (_alergiasSelecionadas.Count == 0)
            {
                await DisplayAlert("Atenção", "Por favor, selecione uma opção ou 'Não' para continuar.", "OK");
                return;
            }

            var usuarioTemp = RepositorioUsuarios.ObterUsuarioTemp();

            string alergiaAliementarEscolhida = string.Join(", ", _alergiasSelecionadas);
      
            bool confirmacao = await DisplayAlert("Confirmação", $"Tem alguma alergia alimentar: {alergiaAliementarEscolhida}", "Sim", "Não");
            if (confirmacao)
            {
                usuarioTemp.AlergiasAlimentares = _alergiasSelecionadas;
                RepositorioUsuarios.AtualizarUsuarioTemp(usuarioTemp);
                await Navigation.PushAsync(new CadastroEstiloAlimentacao());
            }
            
        }

        private async void BtnVoltar(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}