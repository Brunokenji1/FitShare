using AppFitShare.Models;
using AppFitShare.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AppFitShare.ViewModels
{
    public partial class PlanoAlimentarAViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<PlanoAlimentarCafeManha> cafeManha = new ObservableCollection<PlanoAlimentarCafeManha>();

        [ObservableProperty]
        private ObservableCollection<PlanoAlimentarAlmoco> almoco = new ObservableCollection<PlanoAlimentarAlmoco>();

        [ObservableProperty]
        private ObservableCollection<PlanoAlimentarCafeTarde> cafeTarde = new ObservableCollection<PlanoAlimentarCafeTarde>();

        [ObservableProperty]
        private ObservableCollection<PlanoAlimentarJantar> jantar = new ObservableCollection<PlanoAlimentarJantar>();

        public PlanoAlimentarAViewModel()
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
                new PlanoAlimentarCafeManha { Nome = "Omelete", Imagem="Omelete.png",Quantidade=1 , Calorias = 180, Descricao="2 Ovos médios, temperos (sal,pimenta,cheiro-verde) e 1 colher de azeite para untar"},
                new PlanoAlimentarCafeManha { Nome = "Pão Integral", Imagem="paointegral.png",Quantidade=2 , Calorias = 130, Descricao="2 fatias"},
                new PlanoAlimentarCafeManha { Nome = "Banana", Imagem="banana.png", Quantidade= 1, Calorias = 100, Descricao="(média 100g)"},
            };

            if (dadosCafeDaManha.Any())
            {
                CafeManha.Clear();

                foreach (var alimento in dadosCafeDaManha)
                {
                    CafeManha.Add(alimento);
                }
            }
        }
        private void CarregarPlanoAlmocoEmMemoria()
        {
            List<PlanoAlimentarAlmoco> dadosAlmoco = new List<PlanoAlimentarAlmoco>
            {
                new PlanoAlimentarAlmoco { Nome = "Arroz Integral",Imagem="arrozintegral.png", Quantidade=150 , Calorias = 120, Descricao="150g de arroz integral cozido"},
                new PlanoAlimentarAlmoco { Nome = "Feijão",Imagem="feijao.png", Quantidade=100 , Calorias = 80, Descricao="100g de feijão cozido"},
                new PlanoAlimentarAlmoco { Nome = "Peito de Frango",Imagem="peitodefrango.png", Quantidade=100 , Calorias = 165, Descricao="100g de frango cozido ou grelhado"},
                new PlanoAlimentarAlmoco { Nome = "Legumes Cozidos",Imagem="legumescozidos.png", Quantidade=50 , Calorias = 40, Descricao="50g cenoura ou abobrinha refogada"},
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
                new PlanoAlimentarCafeTarde { Nome = "Iogurte Natural",Imagem="iogurtenatural.png", Quantidade=1 , Calorias = 100, Descricao="1 copo (170g)"},
                new PlanoAlimentarCafeTarde { Nome = "Aveia em Flocos",Imagem="aveiaemflocos.png", Quantidade=1 , Calorias = 110, Descricao="3 colheres de sopa (30g)"},
                new PlanoAlimentarCafeTarde { Nome = "Fruta",Imagem="frutas.png", Quantidade=1 , Calorias = 80, Descricao="Maça, banana, laranja, etc"},

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
                new PlanoAlimentarJantar { Nome = "Arroz Integral", Imagem="arrozintegral.png",Quantidade=150 , Calorias = 80, Descricao="80g de arroz integral cozido"},
                new PlanoAlimentarJantar { Nome = "Feijão", Imagem="feijao.png",Quantidade=100 , Calorias = 80, Descricao="80g de feijão cozido"},
                new PlanoAlimentarJantar { Nome = "Ovo Cozido", Imagem="ovocozido.png",Quantidade=2 , Calorias = 150, Descricao="2 ovos cozidos"},
                new PlanoAlimentarJantar { Nome = "Legumes", Imagem="legumescozidos.png",Quantidade=2 , Calorias = 90, Descricao="Grande porção de legumes e verduras a gosto"},
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