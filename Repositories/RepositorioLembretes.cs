using AppFitShare.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Repositories
{
    public static class RepositorioLembretes
    {
        public static ObservableCollection<Lembrete> ListaLembretes { get; set; } = new ObservableCollection<Lembrete>();

        public static void Adicionar(Lembrete lembrete) => ListaLembretes.Add(lembrete);
        public static void Remover(Lembrete lembrete) => ListaLembretes.Remove(lembrete);
    }
}
