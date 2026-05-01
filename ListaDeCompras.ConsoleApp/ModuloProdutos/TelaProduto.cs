using System;
using System.Diagnostics.Tracing;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.ModuloProdutos;

public class TelaProduto : TelaBase<Produto>, ITelaOpcoes, ITelaCrud
{
    RepositorioCategoria repositorioCategoria = new RepositorioCategoria();
    TelaCategoria telaCategoria; public TelaProduto(RepositorioProduto repositorio, RepositorioCategoria repositorioCategoria) : base("Produto", repositorio)
    {
        this.repositorioCategoria = repositorioCategoria;
        telaCategoria = new TelaCategoria(repositorioCategoria);
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Produtos");

        Console.WriteLine(
         "{0, -7} | {1, -20} | {2, -20} | {3, -27} | {4, -10}",
            "Id", "Nome", "Categoria", "Unidade De Medida", "Preco"
        );

        List<Produto> produtos = repositorio.SelecionarTodos();

        foreach (Produto p in produtos)
        {
            Console.WriteLine(
              "{0, -7} | {1, -20} | {2, -20} | {3, -27} | {4, -10}",
              p.Id, p.Nome, p.Categoria.Nome, p.UnidadeMedida, p.Preco
            );
        }

        Console.ResetColor();

        if (deveExibirCabecalho)
        {
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Produto ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do Produto: ");
        string nome = Console.ReadLine() ?? string.Empty;

        telaCategoria.VisualizarTodos(deveExibirCabecalho: false);

        Console.Write("Digite o Id da Categoria: ");
        string idSelecionado = Console.ReadLine() ?? string.Empty;
        Categoria? categoria = repositorioCategoria.SelecionarPorId(idSelecionado);

        Console.WriteLine("Digite uma unidade de medida válida:");
        Console.WriteLine("================================");
        Console.WriteLine("1 - kg");
        Console.WriteLine("2 - unidade");
        Console.WriteLine("3 - litro");
        Console.WriteLine("4 - caixa");
        Console.WriteLine("================================");
        Console.Write("Digite a unidade: ");
        string opcao = Console.ReadLine() ?? string.Empty;

        string unidadeMedida = string.Empty;

        if (opcao == "1")
            unidadeMedida = "kg";
        else if (opcao == "2")
            unidadeMedida = "unidade";
        else if (opcao == "3")
            unidadeMedida = "litro";
        else if (opcao == "4")
            unidadeMedida = "caixa";

        Console.Write("Digite o preco aproximado: ");
        int preco = Convert.ToInt32(Console.ReadLine());

        return new Produto(nome, preco, categoria, unidadeMedida);
    }
}