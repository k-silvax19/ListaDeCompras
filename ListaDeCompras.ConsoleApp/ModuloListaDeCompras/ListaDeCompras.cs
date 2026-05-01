using System;
using System.Diagnostics.Contracts;
using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.ModuloListaDeCompras;

public class ListaDeCompras : EntidadeBase
{
    public string Nome { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public StatusListaDeCompras Status { get; private set; }

    public ListaDeCompras(string nome)
    {
        Nome = nome;
        DataCriacao = DateTime.Now;
        Status = StatusListaDeCompras.Aberta;
    }

    public override void AtualizarRegistro(EntidadeBase entidadeAtualizada)
    {
        ListaDeCompras listaDeComprasAtualizada = (ListaDeCompras)entidadeAtualizada;

        Nome = listaDeComprasAtualizada.Nome;
        Status = listaDeComprasAtualizada.Status;

    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 3 || Nome.Length > 100)
            erros += "O campo \"Nome\" deve ter entre 3 e 100 caracteres.;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
}