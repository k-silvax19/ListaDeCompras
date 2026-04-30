using System;
using System.Collections;
using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.ModuloCategoria;

public class TelaCategoria : TelaBase<Categoria>, ITelaOpcoes, ITelaCrud
{
    public TelaCategoria(RepositorioCategoria repositorio) : base("Categoria", repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Categorias");

        Console.WriteLine(
                   "{0, -7} | {1, -20} | {2, -10}",
                   "Id", "Nome", "Cor"
               );

        List<Categoria> categorias = repositorio.SelecionarTodos();

        foreach (Categoria c in categorias)
        {
            string corSelecionada = c.Cor;

            if (corSelecionada == "Vermelho")
                Console.ForegroundColor = ConsoleColor.Red;
            if (corSelecionada == "Verde")
                Console.ForegroundColor = ConsoleColor.Green;
            if (corSelecionada == "Azul")
                Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
              "{0, -7} | {1, -20} | {2, -10}",
              c.Id, c.Nome, c.Cor
          );
        }

        Console.ResetColor();

        if (deveExibirCabecalho)
        {
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Categoria ObterDadosCadastrais()
    {
        Console.Write("Digite o nome da categoria: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Digite uma cor valida para a categoria: ");
        Console.WriteLine("================================");
        Console.WriteLine("1 - Vermelho");
        Console.WriteLine("2 - Azul");
        Console.WriteLine("3 - Verde");
        Console.WriteLine("4 - Branco (Padrao)");
        Console.WriteLine("================================");
        Console.Write("Digite a cor da categoria: ");
        string cor = Console.ReadLine() ?? string.Empty;

        string corPorExtenso = string.Empty;

        if (cor == "1")
            corPorExtenso = "Vermelho";
        else if (cor == "2")
            corPorExtenso = "Azul";
        else if (cor == "3")
            corPorExtenso = "Verde";
        else
            corPorExtenso = "Branco";

        return new Categoria(nome, corPorExtenso);
    }
}
