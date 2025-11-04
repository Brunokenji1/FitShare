using AppFitShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Repositories
{
    public class CadastroTemp
    {
        public static UsuarioCompleto UsuarioTemporario { get; set; } = new UsuarioCompleto();
        public static void AtualizarDados(UsuarioCompleto dados)
        {
            UsuarioTemporario = dados;
        }
        public static void Limpar()
        {
            UsuarioTemporario = new UsuarioCompleto();
        }
    }
}
