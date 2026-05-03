using System;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloListaDeCompras;
using ListaDeCompras.ConsoleApp.ModuloProdutos;

namespace ListaDeCompras.ConsoleApp.ModuloItens;

public class TelaItens : TelaBase<Item>
{
    private RepositorioLista repositorioLista;
    private RepositorioProduto repositorioProduto;

    public TelaItens(string nomeEntidade, RepositorioBase<Item> repositorio) : base(nomeEntidade, repositorio)
    {
    }

    public string Menu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Gestão de Listas");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Adicionar Item");
        Console.WriteLine("2 - Remover Item");
        Console.WriteLine("3 - Visualizar Itens");

        Console.Write("Digite uma opção: ");
        string? opcaoMenu = Console.ReadLine() ?? string.Empty;

        return opcaoMenu;
    }

    //public void AddItem()
    //{
    //    ExibirCabecalho("Adicionar item");

    //        ListaDeCompras lista = Selecionar

    //}

    protected void ExibirCabecalho(string titulo)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Gestão de Listas");
        Console.WriteLine("---------------------------------");
        Console.WriteLine(titulo);
        Console.WriteLine("---------------------------------");
    }

    protected void ExibirMensagem(string mensagem)
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine(mensagem);
        Console.WriteLine("---------------------------------");
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        throw new NotImplementedException();
    }

    protected override Item ObterDadosCadastrais()
    {
        throw new NotImplementedException();
    }
}
