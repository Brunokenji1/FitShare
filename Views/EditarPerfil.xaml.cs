using AppFitShare.Repositories;

namespace AppFitShare.Views;

public partial class EditarPerfil : ContentPage
{
	public EditarPerfil()
	{
		InitializeComponent();
        RepositorioUsuarios.IniciarUsuarioTemp();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var usuario = RepositorioUsuarios.ObterUsuarioTemp();

        if (usuario.Username != null)
        {
            txt_username.Text = $"{usuario.Username}";
        }
        if (usuario.Idade != null && usuario.Idade != 0)
        {
            txt_idade.Text = $"{usuario.Idade}";
        }
        if (usuario.Altura != null && usuario.Altura != 0)
        {
            txt_altura.Text = $"{usuario.Altura}";
        }
        if (usuario.Peso != null && usuario.Peso != 0)
        {
            txt_peso.Text = $"{usuario.Peso}";
        }

        //imgPerfil.Source = usuario.FotoPerfil;
    }
    private async void BtnEditarDados(object sender, EventArgs e)
    {
        try
        {
            var usuarioTemp = RepositorioUsuarios.ObterUsuarioTemp();
            if (lblAviso.Text != "Nome de usuário válido")
            {
                throw new Exception("Digite um username válido!");
            }
            if(txt_username.Text != null)
            {
                usuarioTemp.Username = txt_username.Text;
            }
            if (txt_altura.Text != null)
            {
                usuarioTemp.Altura = double.Parse(txt_altura.Text);
            }
            if(txt_idade.Text != null)
            {
                usuarioTemp.Idade = int.Parse(txt_idade.Text);

            }
            if(txt_peso.Text != null)
            {
                if (txt_peso.Text.Contains(",") || txt_peso.Text.Contains("."))
                {
                    usuarioTemp.Peso = double.Parse(txt_peso.Text);

                }
                else
                {
                    throw new Exception("Preencha o seu peso usando Quilogramas nesse formato 000,00");
                }
            

            }
            RepositorioUsuarios.AtualizarUsuarioTemp(usuarioTemp);
            bool confirmacao = await DisplayAlert("Confirma a edição dos seguintes dados?", $"  Altura : {usuarioTemp.Altura}\n  Idade : {usuarioTemp.Idade} \n" +
    $"Peso : {usuarioTemp.Peso}   ", "Sim", "Não");
            if (confirmacao)
            {
                usuarioTemp.Status = "Ativo";
                RepositorioUsuarios.AtualizarUsuarioTemp(usuarioTemp);
                RepositorioUsuarios.SalvarUsuarioTemp();

                await DisplayAlert("Sucesso", "Cadastro das informações realizado com sucesso!", "Fechar");
                App.Current.MainPage = new NavigationPage(new TabbedPageMenu());
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops...", ex.Message, "Fechar");
        }

    }

    //private async void BtnSelecionarFoto(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        var foto = await MediaPicker.PickPhotoAsync();

    //        if (foto == null) return;

    //        var stream = await foto.OpenReadAsync();

    //        var imgSource = ImageSource.FromStream(() => stream);

    //        imgPerfil.Source = imgSource;
    //        imgPerfil.IsVisible = true;
    //        var usuario = RepositorioUsuarios.ObterUsuarioTemp();
    //        usuario.FotoPerfil = imgSource;
    //        RepositorioUsuarios.AtualizarUsuarioTemp(usuario);
    //    }
    //    catch (Exception ex)
    //    {
    //        await DisplayAlert("Erro", ex.Message, "OK");
    //    }
    //}
    private async void BtnVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private void txtUsername_TxtChanged(object sender, TextChangedEventArgs e)
    {

        string username = txt_username.Text?.Trim() ?? "";
        if (string.IsNullOrWhiteSpace(username))
        {
            lblAviso.Text = "";
            return;
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(username, "^[a-z0-9]+$"))
        {
            lblAviso.IsVisible = true;
            lblAviso.TextColor = Colors.Red;
            if (username.Any(char.IsUpper)) lblAviso.Text = "Use apenas letras minúsculas. ";
            else lblAviso.Text = "Use só letras e números, sem acento ou símbolos.";
        }
        else
        {
            var usuariologado = RepositorioUsuarios.ObterUsuarioLogado();
   
            var usernameExistente = RepositorioUsuarios.ObterPorUsername(txt_username.Text);

            if(txt_username.Text == usuariologado.Username)
            {
                lblAviso.Text = "Nome de usuário válido";
                lblAviso.IsVisible = false;
            }
            else if (usernameExistente != null)
            {
                lblAviso.IsVisible = true;
                lblAviso.TextColor = Colors.Red;
                lblAviso.Text = "Nome de usuario existente";
            }
            else
            {
                lblAviso.TextColor = Colors.Green;
                lblAviso.Text = "Nome de usuário válido";
                lblAviso.IsVisible = false;
            }
        }
    }
}