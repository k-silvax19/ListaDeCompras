using System;
using ListaDeCompras.ConsoleApp.ModuloCategoria;
using ListaDeCompras.ConsoleApp.ModuloListaDeCompras;
using ListaDeCompras.ConsoleApp.ModuloProdutos;

namespace ListaDeCompras.ConsoleApp.ModuloItens;

public class TelaItens
{
    private RepositorioLista repositorioLista;
    private RepositorioProduto repositorioProduto;
    public TelaListadeCompras telaListadeCompras;
    public TelaProduto telaProduto;

    public TelaItens(RepositorioLista repositorioLista, RepositorioProduto repositorioProduto, RepositorioCategoria repositorioCategoria)
    {
        this.repositorioLista = repositorioLista;
        this.repositorioProduto = repositorioProduto;
        this.telaListadeCompras = new TelaListadeCompras("Lista de Compras", repositorioLista);
        this.telaProduto = new TelaProduto(repositorioProduto, repositorioCategoria);
    }

    public string Menu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Gestão de Itens");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Adicionar Item");
        Console.WriteLine("2 - Remover Item");
        Console.WriteLine("3 - Visualizar Itens");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");

        Console.Write("Digite uma opção: ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper() ?? string.Empty;

        return opcaoMenu;
    }

    public void AddItem()
    {
        ExibirCabecalho("Adicionar itens");
        telaListadeCompras.VisualizarTodos(deveExibirCabecalho: false);

        Console.Write("Digite o ID da lista: ");
        string idLista = Console.ReadLine() ?? string.Empty;

        ModuloListaDeCompras.ListaDeCompras? lista = repositorioLista.SelecionarPorId(idLista);

        if (lista == null)
        {
            ExibirMensagem("Lista não foi encontada");
            return;
        }

        telaProduto.VisualizarTodos(deveExibirCabecalho: false);

        Console.Write("Digite o ID do produto: ");
        string idProduto = Console.ReadLine() ?? string.Empty;

        Produto? produto = repositorioProduto.SelecionarPorId(idProduto);

        if (produto == null)
        {
            ExibirMensagem("Produto não foi encontado");
            return;
        }

        foreach (Item item in lista.Itens)
        {
            if (item.Produto.Id == produto.Id)
            {
                ExibirMensagem("Esse poduto já foi adicionado nessa lista");
                return;
            }
        }

        Console.Write("Digite a quantidade: ");
        int quantidade = Convert.ToInt32(Console.ReadLine());

        Item novoItem = new Item(produto, quantidade);

        string[] erros = novoItem.Validar();

        if (erros.Length > 0)
        {
            ExibirMensagem(erros[0]);
            return;
        }

        lista.Itens.Add(novoItem);

        ExibirMensagem("Item adicionado com sucesso");
    }

    public void RemoverItem()
    {
        ExibirCabecalho("Remover item");

        telaListadeCompras.VisualizarTodos(deveExibirCabecalho: false);

        Console.Write("Digite o ID da lista: ");
        string idLista = Console.ReadLine() ?? string.Empty;

        ModuloListaDeCompras.ListaDeCompras? lista = repositorioLista.SelecionarPorId(idLista);

        if (lista == null)
        {
            ExibirMensagem("Lista não encontrada");
            return;
        }

        VisualizarTodos(deveExibirCabecalho: false);

        Console.Write("Digite o ID do produto que deseja remover: ");
        string idProduto = Console.ReadLine() ?? string.Empty;

        Item? itemSelecionado = null;

        foreach (Item item in lista.Itens)
        {
            if (item.Produto.Id == idProduto)
            {
                itemSelecionado = item;
                break;
            }
        }

        if (itemSelecionado == null)
        {
            ExibirMensagem("Item não encontrado");
            return;
        }

        lista.Itens.Remove(itemSelecionado);

        ExibirMensagem("Item removido com sucesso");
    }

    public void VisualizarTodos(bool deveExibirCabecalho)
    {
        telaListadeCompras.VisualizarTodos(deveExibirCabecalho: false);

        Console.Write("Digite o ID da lista: ");
        string idLista = Console.ReadLine() ?? string.Empty;

        ModuloListaDeCompras.ListaDeCompras? lista = repositorioLista.SelecionarPorId(idLista);

        if (lista == null)
        {
            ExibirMensagem("Lista não encontrada");
            return;
        }

        if (deveExibirCabecalho)
            ExibirCabecalho("Visualição de itens");

        Console.WriteLine(
         "{0, -20} | {1, -15} | {2, -10} | {3, -10} | {4, -10}",
         "Produto", "Categoria", "Qtd", "Preço", "Total"
        );

        foreach (Item i in lista.Itens)
        {
            Console.WriteLine(
          "{0, -20} | {1, -15} | {2, -10} | {3, -10} | {4, -10}",
          i.Produto.Nome, i.Produto.Categoria.Nome, i.Quantidade, i.Produto.Preco, i.ObterTotal()
            );
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Total da lista: R$ " + lista.ObterValorTotal());
        Console.WriteLine("---------------------------------");

        if (deveExibirCabecalho)
        {
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected void ExibirCabecalho(string titulo)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Gestão de Itens");
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
}