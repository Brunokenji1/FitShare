using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Views.TelasCadastroCompleto.TelasCadastroSaudeCondicionamento
{
    public static class AppState
    {
        // Membros inferiores
        public static bool DificuldadeParaCaminhar { get; set; } = false;
        public static bool ProblemasNoQuadril { get; set; } = false;
        public static bool DorNoJoelho { get; set; } = false;
        public static bool FraquezaNasPernas { get; set; } = false;

        // Membros superiores
        public static bool DificuldadeParaLevantarPeso { get; set; } = false;
        public static bool DorNoCotovelo { get; set; } = false;
        public static bool LimitacaoNoOmbro { get; set; } = false;
        public static bool TendiniteNoBraco { get; set; } = false;

        // Equilíbrio e Mobilidade
        public static bool DificuldadeParaFicarEmPe { get; set; } = false;
        public static bool InstabilidadeAoAndar { get; set; } = false;

        // Coluna e Postura
        public static bool DorLombar { get; set; } = false;
        public static bool Escoliose { get; set; } = false;
        public static bool HerniaDeDisco { get; set; } = false;
        public static bool PosturaCurvada { get; set; } = false;
        
    }
}
