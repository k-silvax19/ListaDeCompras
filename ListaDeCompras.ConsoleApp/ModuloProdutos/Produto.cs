using System;
using System.Runtime.CompilerServices;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.ModuloProdutos;

public class Produto : EntidadeBase
{
    public Categoria Categoria { get; set; }
    public string Nome { get; private set; }
    public int Preco { get; private set; }
    public string UnidadeMedida { get; private set; }

    public Produto(string nome, int preco, Categoria categoria, string unidadeMedida)
    {
        Nome = nome;
        Preco = preco;
        this.Categoria = categoria;
        UnidadeMedida = unidadeMedida;
    }

    public override void AtualizarRegistro(EntidadeBase entidadeAtualizada)
    {
        Produto produtoAtualizado = (Produto)entidadeAtualizada;

        Nome = produtoAtualizado.Nome;
        Preco = produtoAtualizado.Preco;
        Categoria = produtoAtualizado.Categoria;
        UnidadeMedida = produtoAtualizado.UnidadeMedida;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (Nome.Length == 1 || Nome.Length > 100)
            erros += "O Campo \"Nome\" deve conter no entre 1 e 100 caracteres.;";

        if (string.IsNullOrWhiteSpace(Categoria.Id))
            erros += "O Campo \"Categoria\" é obrigatório.;";

        else if (UnidadeMedida != "kg" && UnidadeMedida != "unidade" && UnidadeMedida != "litro" && UnidadeMedida != "caixa")

            erros += "O Campo \"Unidade de Medida\" deve conter uma seleção permitida (kg, unidade, litro, caixa);";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);

    }
}