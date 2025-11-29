using AppFitShare.Models;
using AppFitShare.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AppFitShare.ViewModels
{
    public partial class PlanoAlimentarBViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<PlanoAlimentarCafeManha> cafeManha = new ObservableCollection<PlanoAlimentarCafeManha>();

        [ObservableProperty]
        private ObservableCollection<PlanoAlimentarAlmoco> almoco = new ObservableCollection<PlanoAlimentarAlmoco>();

        [ObservableProperty]
        private ObservableCollection<PlanoAlimentarCafeTarde> cafeTarde = new ObservableCollection<PlanoAlimentarCafeTarde>();

        [ObservableProperty]
        private ObservableCollection<PlanoAlimentarJantar> jantar = new ObservableCollection<PlanoAlimentarJantar>();

        public PlanoAlimentarBViewModel()
        {
            CarregarPlanoCafeManhaEmMemoria();
            CarregarPlanoAlmocoEmMemoria();
            CarregarPlanoCafeTardeEmMemoria();
            CarregarPlanoJantarEmMemoria();
        }
        private void CarregarPlanoCafeManhaEmMemoria()
        {
            List<PlanoAlimentarCafeManha> dadosCafeDaManha = new List<PlanoAlimentarCafeManha>
            {
                new PlanoAlimentarCafeManha { Nome = "Mingau de Aveia", Imagem="mingaudeaveia.png",Quantidade=50 , Calorias = 250, Descricao="50g aveia em flocos, 150ml leite integral/semidesnatado"},
                new PlanoAlimentarCafeManha { Nome = "Topping", Imagem="topping.png",Quantidade=1 , Calorias = 80, Descricao="1 colher de chá de açúcar e 1 fruta da estação picada"},
            };

            if (dadosCafeDaManha.Any())
            {
                cafeManha.Clear();

                foreach (var alimento in dadosCafeDaManha)
                {
                    cafeManha.Add(alimento);
                }
            }
        }
        private void CarregarPlanoAlmocoEmMemoria()
        {
            List<PlanoAlimentarAlmoco> dadosAlmoco = new List<PlanoAlimentarAlmoco>
            {
                new PlanoAlimentarAlmoco { Nome = "Batata Doce Cozida",Imagem="batatadocecozida.png", Quantidade=200 , Calorias = 175, Descricao="200g cozida"},
                new PlanoAlimentarAlmoco { Nome = "Lentilha Cozida",Imagem="lentilhacozida.png", Quantidade=170 , Calorias = 170, Descricao="150g cozida"},
                new PlanoAlimentarAlmoco { Nome = "Carne Bovina",Imagem="carnebovina.png", Quantidade=100 , Calorias = 180, Descricao="180g patinho/acém cozido ou moído"},
                new PlanoAlimentarAlmoco { Nome = "Salada",Imagem="salada.png", Quantidade=70 , Calorias = 70, Descricao="Salada de beterraba e cenoura ralada"},
            };

            if (dadosAlmoco.Any())
            {
                almoco.Clear();

                foreach (var alimento in dadosAlmoco)
                {
                    almoco.Add(alimento);
                }
            }
        }
        private void CarregarPlanoCafeTardeEmMemoria()
        {
            List<PlanoAlimentarCafeTarde> dadosCafeTarde = new List<PlanoAlimentarCafeTarde>
            {
                new PlanoAlimentarCafeTarde { Nome = "Crepioca Salgada",Imagem="crepiocasalgada.png", Quantidade=1 , Calorias = 130, Descricao="1 ovo + 2 colheres de sopa de goma de tapioca"},
                new PlanoAlimentarCafeTarde { Nome = "Recheio",Imagem="pastadeamendoim.png", Quantidade=1 , Calorias = 100, Descricao="1 colher de sopa de pasta de amendoim ou 1 fatia de queijo mussarela"},

            };

            if (dadosCafeTarde.Any())
            {
                cafeTarde.Clear();

                foreach (var alimento in dadosCafeTarde)
                {
                    cafeTarde.Add(alimento);
                }
            }
        }

        private void CarregarPlanoJantarEmMemoria()
        {
            List<PlanoAlimentarJantar> dadosJantar = new List<PlanoAlimentarJantar>
            {
                new PlanoAlimentarJantar { Nome = "Salada de Grão-de-Bico e Atum", Imagem="saladagraodebicoatum.png",Quantidade=150 , Calorias = 320, Descricao="1 lata de atum, 100g grão-de-bico cozido"},
            };

            if (dadosJantar.Any())
            {
                jantar.Clear();

                foreach (var alimento in dadosJantar)
                {
                    jantar.Add(alimento);
                }
            }
        }
    }
}