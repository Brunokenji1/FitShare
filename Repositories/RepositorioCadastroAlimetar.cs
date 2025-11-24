using AppFitShare.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Repositories;

public class RepositorioCadastroAlimetar
{
    private static List<string> AlergiaAlimentarTemp = new List<string>();
    private static List<string> EstiloAlimentarTemp = new List<string>();

    public static List<string> ObterAlergiaAlimentarTemp()
    {
        return AlergiaAlimentarTemp;
    }
    
    public static void AdicionarAlergiaAlimentarTemp(string alergia)
    {
        AlergiaAlimentarTemp.Add(alergia);
    }
    public static void RemoverAlergiaAlimentarTemp(string alergia)
    {
        AlergiaAlimentarTemp.Remove(alergia);
    }
    public static bool BuscarAlergiaAlimentarTemp(string buscarAlergia)
    {
        return AlergiaAlimentarTemp.Contains(buscarAlergia);

    }
    
    
    public static List<string> ObterEstiloAlimentarTemp()
    {
        return EstiloAlimentarTemp;
    }
    public static void AdicionarEstiloAlimentarTemp(string estiloAlimentar)
    {
        EstiloAlimentarTemp.Add(estiloAlimentar);
    }
    public static void RemoverEstiloAlimentarTemp(string estiloAlimentar)
    {
        EstiloAlimentarTemp.Remove(estiloAlimentar);
    }
    public static bool BuscarEstiloAlimentarTemp(string buscarEstiloAlimentar)
    {
        return EstiloAlimentarTemp.Contains(buscarEstiloAlimentar);
    }

}
