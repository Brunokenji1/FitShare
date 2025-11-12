using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento
{
    public static class AppState
    {
        // Cardiorrespiratórias
        public static bool ProblemaFaltaDeAr { get; set; } = false;
        public static bool PressaoAlta { get; set; } = false;
        public static bool ProblemaCardiaco { get; set; } = false;

        // Musculares e Articulares
        public static bool LesaoManguitoRotador { get; set; } = false;
        public static bool FraquezaMuscularLocalizada { get; set; } = false;
        public static bool DoresCronicasNasCostas { get; set; } = false;

        // Neurológicas
        public static bool DificuldadeDeCoordenacaoMotora { get; set; } = false;
        public static bool TonturasFrequentes { get; set; } = false;
        public static bool FaltaDeEquilibrio { get; set; } = false;

        // Ortopédicas
        public static bool ArtroseNoQuadrilOuOmbro { get; set; } = false;
        public static bool CirurgiaRecente { get; set; } = false;
        public static bool DorLombar { get; set; } = false;
    }
}
