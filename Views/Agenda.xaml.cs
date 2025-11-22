using AppFitShare.ViewModels;

namespace AppFitShare.Views;

public partial class Agenda : ContentPage
{
	public Agenda()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Atualiza a lista sempre que a página aparecer (ex: ao voltar do cadastro)
        if (BindingContext is LembretesViewModel vm)
        {
            vm.AtualizarListaVisivel();
        }
    }
}

