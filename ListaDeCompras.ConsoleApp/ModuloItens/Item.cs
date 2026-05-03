using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloProdutos;

namespace ListaDeCompras.ConsoleApp.ModuloItens;

public class Item : EntidadeBase
{
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }

    public decimal ObterTotal()
    {
        if (Produto == null)
            return 0;

        return Produto.Preco * Quantidade;
    }
    
    public Item(Produto produto, int quantidade)
    {
        Produto = produto;
        Quantidade = quantidade;
    }

    public override void AtualizarRegistro(EntidadeBase entidadeAtualizada)
    {
        Item itemAtualizado = (Item)entidadeAtualizada;

        Produto = itemAtualizado.Produto;
        Quantidade = itemAtualizado.Quantidade;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (Produto == null)
            erros += "O campo \"Produto\" é obrigatório.;";
        if (Quantidade <= 0)
            erros += "A quantidade deve ser um número positivo.;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
}
