using System;
using System.Runtime.CompilerServices;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.ModuloProdutos;

public class Produto : EntidadeBase
{
    public Categoria categoria { get; set; }
    public string Nome { get; private set; }
    public int Preco { get; private set; }
    public string UnidadeMedida { get; private set; }

    public Produto(string nome, int preco, Categoria categoria, string unidadeMedida)
    {
        Nome = nome;
        Preco = preco;
        this.categoria = categoria;
        UnidadeMedida = unidadeMedida;
    }

    public override void AtualizarRegistro(EntidadeBase entidadeAtualizada)
    {
        Produto produtoAtualizado = (Produto)entidadeAtualizada;

        Nome = produtoAtualizado.Nome;
        Preco = produtoAtualizado.Preco;
        categoria = produtoAtualizado.categoria;
        UnidadeMedida = produtoAtualizado.UnidadeMedida;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (Nome.Length == 0 || Nome.Length > 100)
            erros += "O Campo \"Nome\" deve conter no entre 0 e 100 caracteres.;";

        if (string.IsNullOrWhiteSpace(categoria.Id))
            erros += "O Campo \"Categoria\" é obrigatório.;";

        if (categoria.Nome == Nome)
            erros += "O Nome da Categoria não pode ser o mesmo do produto.;";
        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
}