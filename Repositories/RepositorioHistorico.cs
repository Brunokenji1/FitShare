using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Repositories
{
    public class RepositorioHistorico
    {
        private static Dictionary<int, HashSet<DateTime>> HistoricoPorUsuario = new();


        public static void MarcarTreinoHoje()
        {
            var usuarioLogado = RepositorioUsuarios.ObterUsuarioLogado();
            if (usuarioLogado == null) return;

            if (!HistoricoPorUsuario.ContainsKey(usuarioLogado.Id))
            {
                HistoricoPorUsuario[usuarioLogado.Id] = new HashSet<DateTime>();
            }
            HistoricoPorUsuario[usuarioLogado.Id].Add(DateTime.Today);
        }

        public static bool VerificarTreinouNoDia(DateTime data)
        {
            var usuarioLogado = RepositorioUsuarios.ObterUsuarioLogado();
            if(usuarioLogado == null) return false;
            if (HistoricoPorUsuario.ContainsKey(usuarioLogado.Id))
            {
                return HistoricoPorUsuario[usuarioLogado.Id].Contains(data.Date);
            }
            return false;
        }

        public static int CalcularSequencuiaAtual()
        {
            var usuarioLogado = RepositorioUsuarios.ObterUsuarioLogado();
            if (usuarioLogado == null || !HistoricoPorUsuario.ContainsKey(usuarioLogado.Id)) return 0;
            var datas = HistoricoPorUsuario[usuarioLogado.Id];
            int sequencia = 0;
            DateTime dataCheck = DateTime.Today;

            if (!datas.Contains(dataCheck)) dataCheck = dataCheck.AddDays(-1);
            while (datas.Contains(dataCheck))
            {
                sequencia++;
                dataCheck = dataCheck.AddDays(-1);
            }
            return sequencia;
        }


    }
}
