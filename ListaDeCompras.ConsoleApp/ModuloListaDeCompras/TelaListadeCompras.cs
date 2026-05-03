using System;
using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.ModuloListaDeCompras;

public class TelaListadeCompras : TelaBase<ListaDeCompras>, ITelaOpcoes, ITelaCrud
{
    public TelaListadeCompras(string nomeEntidade, RepositorioLista repositorio) : base(nomeEntidade, repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Listas");

        Console.WriteLine(
                   "{0, -7} | {1, -20} | {2, -10} | {3, -10} | {4, -10} | {5, -10}",
                   "Id", "Nome", "Data da Criação", "Status", "Itens", "Total"
               );

        List<ListaDeCompras> lista = repositorio.SelecionarTodos();

        foreach (ListaDeCompras l in lista)
        {
            if (l.Status == StatusListaDeCompras.Aberta)
                Console.ForegroundColor = ConsoleColor.Red;
            if (l.Status == StatusListaDeCompras.Concluida)
                Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(
               "{0, -7} | {1, -20} | {2, -10} | {3, -10} | {4, -10} | {5, -10}",
              l.Id, l.Nome, l.DataCriacao.ToShortDateString(), l.Status, l.ObterTotalItens(), l.ObterValorTotal()
          );
        }

        Console.ResetColor();

        if (deveExibirCabecalho)
        {
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override ListaDeCompras ObterDadosCadastrais()
    {
        Console.Write("Digite o nome da lista de compras: ");
        string nome = Console.ReadLine() ?? string.Empty;

        return new ListaDeCompras(nome);
    }

    public override List<string> ValidarExclusaoRegistro(ListaDeCompras lista)
    {
        List<string> erros = new List<string>();

        if (lista.Itens.Count > 0)
            erros.Add("Não é possível excluir uma lista que possui itens vinculados.");

        return erros;
    }
}

