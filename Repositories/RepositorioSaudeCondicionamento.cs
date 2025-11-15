using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Repositories
{
    public class RepositorioSaudeCondicionamento
    {
        
        private static List<string> RestricoesFisicasEscolhidasTemp = new List<string>();
        private static List<string> CondicaoMedicaTemp = new List<string>();
        public static List<string> ObterTodasCondicoes()
        {
            var listaCompleta  = RestricoesFisicasEscolhidasTemp.Concat(CondicaoMedicaTemp).ToList();
            return listaCompleta;
        }


        // Condições medicas
        public static List<string> ObterCondicoesMedicasTemp()
        {
            return CondicaoMedicaTemp;
        }

        public static void AdicionarCondicaoMedicaTemp(string condicao)
        {
            CondicaoMedicaTemp.Add(condicao);
        }
        public static void RemoverCondicaoMedicaTemp(string condicao)
        {
            CondicaoMedicaTemp.Remove(condicao);
        }
        public static bool BuscarCondicaoMedicaTemp(string condicao)
        {
            return CondicaoMedicaTemp.Contains(condicao);
        }



        // Restrições físicas
        public static List<string> ObterRestricoesFisicasTemp()
        {
            return RestricoesFisicasEscolhidasTemp;
        }

        public static void AdicionarRestricaoFisicaTemp(string restricao)
        {
            RestricoesFisicasEscolhidasTemp.Add(restricao);
        }

        public static void RemoverRestricaoFisicaTemp(string restricao)
        {
            RestricoesFisicasEscolhidasTemp.Remove(restricao);
        }
        public static bool BuscarRestricaoFisicaTemp(string restricao)
        {
            return RestricoesFisicasEscolhidasTemp.Contains(restricao);
        }
    }
}
