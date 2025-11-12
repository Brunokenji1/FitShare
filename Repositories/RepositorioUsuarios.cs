using AppFitShare.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace AppFitShare.Repositories;

public class RepositorioUsuarios
{
    private static Usuario usuarioTemporario { get; set; }
    public static List<string> RestricoesFisicasEscolhidasTemp { get; set; } = new List<string>();
    private static Usuario usuario_logado { get; set; }

    private static List<Usuario> listaUsuarios = new List<Usuario>()
    {
        new Usuario(0, "Bruno", "bruno", "1", "12345678", DateTime.Now),

        new Usuario(1, "Pedro Chaves", "Chaves", "2", "12345678", DateTime.Now)

    };
    public static Usuario BuscarUsuario(int id)
    {
        try
        {
            var usuario = listaUsuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                return usuario;
            }
            else
            {
                throw new Exception("Usuario nao encontrado!");
            }
        }
        catch (Exception)
        {
            throw new Exception("Problema na busca de usuario!");
        }
    }
    public static void LogarUsuario(Usuario usuario)
    {
        usuario_logado = usuario;
    }
    public static void DeslogarUsuario()
    {
        usuario_logado = null;
    }
    public static Usuario ObterUsuarioLogado()
    {
        return usuario_logado;
    }
    public static void IniciarUsuarioTemp()
    {
        usuarioTemporario = new Usuario(
            usuario_logado.Id,
            usuario_logado.Nome,
            usuario_logado.Username,
            usuario_logado.Telefone,
            usuario_logado.Senha,
            usuario_logado.DataCadastro
        );
    }

    public static Usuario ObterUsuarioTemp()
    {
        return usuarioTemporario;
    }

    public static void AtualizarUsuarioTemp(Usuario usuario)
    {
        usuarioTemporario = usuario;
    }
    public static void AtualizarRestricoesFisicasTemp(List<string> restricoes)
    {
        usuarioTemporario.RestricoesFisicas = restricoes;
    }
    public static void SalvarUsuarioTemp()
    {
        try
        {
            var usuario = listaUsuarios.FirstOrDefault(u => u.Id == usuario_logado.Id);
            if (usuario != null)
            {
                var index = listaUsuarios.FindIndex(u => u.Id == usuario_logado.Id);
                listaUsuarios[index] = usuarioTemporario;
            }
            usuario_logado = usuarioTemporario;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao salvar informações do usuario!");
        }
    }

    public static void Cadastrar(Usuario usuario)
    {
        listaUsuarios.Add(usuario);
    }
    public static Usuario? ObterPorNome(string nome)
    {
        return listaUsuarios.FirstOrDefault(u => u.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }
    public static Usuario? ObterPorTelefone(string telefone)
    {
        return listaUsuarios.FirstOrDefault(u => u.Telefone.Equals(telefone, StringComparison.OrdinalIgnoreCase));
    }
    public static Usuario? ObterPorUsername(string username)
    {
        return listaUsuarios.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
    }

    public static List<Usuario> ListarTodos()
    {
        return listaUsuarios;
    }
    public static void Atualizar(Usuario usuarioAtualizar)
    {

        var index = listaUsuarios.FindIndex(u => u.Id == usuario_logado.Id);

        if (index >= 0)
        {
            listaUsuarios[index] = usuarioAtualizar;
        }
    }

    public static void RecuperarSenha(string telefone)
    {
        var index = listaUsuarios.FindIndex(u => u.Telefone == telefone);

    }
}
