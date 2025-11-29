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
                new PlanoAlimentarCafeManha { Nome = "Omelete", Quantidade=1 , Calorias = 180, Descricao="2 Ovos médios, temperos (sal,pimenta,cheiro-verde) e 1 colher de azeite para untar"},
                new PlanoAlimentarCafeManha { Nome = "Pão Integral", Quantidade=2 , Calorias = 130, Descricao="2 fatias"},
                new PlanoAlimentarCafeManha { Nome = "Banana", Quantidade= 1, Calorias = 100, Descricao="(média 100g)"},
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
                new PlanoAlimentarAlmoco { Nome = "Peito de Frango Grelhado", Quantidade=150 , Calorias = 250, Descricao="150g de peito de frango grelhado"},
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
                new PlanoAlimentarCafeTarde { Nome = "Iogurte Natural", Quantidade=1 , Calorias = 100, Descricao="1 copo (170g)"},
                new PlanoAlimentarCafeTarde { Nome = "Fruta", Quantidade=1 , Calorias = 80, Descricao="1 Maçã"},
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
                new PlanoAlimentarJantar { Nome = "Salmão Assado", Quantidade=120 , Calorias = 350, Descricao="120g de salmão com vegetais"},
                new PlanoAlimentarJantar { Nome = "Arroz Integral", Quantidade=100 , Calorias = 120, Descricao="4 colheres de sopa"},
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