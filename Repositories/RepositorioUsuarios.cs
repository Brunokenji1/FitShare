﻿using AppFitShare.Models;
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
    public static Usuario usuario_logado { get; set; }
    private static List<Usuario> listaUsuarios = new List<Usuario>()
    {
        new Usuario(0, "Bruno", "bruno", "bruno@gmail.com", "12345678", DateTime.Now),
        
        new Usuario(1, "Pedro Chaves", "Chaves", "pdr@gmail.com", "12345678", DateTime.Now)

    };


    public static void Cadastrar(Usuario usuario)
    {
        listaUsuarios.Add(usuario);
    }
    public static Usuario? ObterPorNome(string nome)
    {
        return listaUsuarios.FirstOrDefault(u => u.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }
    public static Usuario? ObterPorEmail(string email)
    {
        return listaUsuarios.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }
    public static Usuario? ObterPorUsername(string username)
    {
        return listaUsuarios.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
    }

    public static List<Usuario> ListarTodos()
    {
        return listaUsuarios;
    }
    public static void Atualizar(Usuario usuario)
    {
        var index = listaUsuarios.FindIndex(u => u.Email == usuario.Email);

        if (index >= 0)
        {
            listaUsuarios[index] = usuario;
        }
    }
}
