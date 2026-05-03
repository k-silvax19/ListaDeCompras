
using System.Collections;
using System.Net;
using System.Runtime.CompilerServices;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;
using ListaDeCompras.ConsoleApp.ModuloItens;
using ListaDeCompras.ConsoleApp.ModuloListaDeCompras;
using ListaDeCompras.ConsoleApp.ModuloProdutos;
class TelaPrincipal
{
    private RepositorioCategoria repositorioCategoria = new RepositorioCategoria();
    private RepositorioProduto repositorioProduto = new RepositorioProduto();
    private RepositorioLista repositorioLista = new RepositorioLista();
    public bool SairDoPrograma = false; // bool para corrigir bug de não deixar sair do programa.
    public ITelaOpcoes? ApresentarMenuOpcoesPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Lista de Compras");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar categorias");
        Console.WriteLine("2 - Gerenciar produtos");
        Console.WriteLine("3 - Gerenciar listas de compras");
        Console.WriteLine("4 - Gerenciar itens de listas de compras");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();
        
        if (opcaoMenuPrincipal == "S")
        {
            SairDoPrograma = true;
            return null;
        }
        if (opcaoMenuPrincipal == "1")
            return new TelaCategoria(repositorioCategoria);
        if (opcaoMenuPrincipal == "2")
            return new TelaProduto(repositorioProduto, repositorioCategoria);
        if (opcaoMenuPrincipal == "3")
            return new TelaListadeCompras("Listas de Compras", repositorioLista);
        if (opcaoMenuPrincipal == "4")
        {
            TelaItens telaItens = new TelaItens(repositorioLista, repositorioProduto, repositorioCategoria);

            while (true)
            {
                string opcaoMenu = telaItens.Menu();

                if (opcaoMenu == "S")
                    break;

                if (opcaoMenu == "1")
                    telaItens.AddItem();

                else if (opcaoMenu == "2")
                    telaItens.RemoverItem();

                else if (opcaoMenu == "3")
                    telaItens.VisualizarTodos(true);

                else
                    Console.WriteLine("Opção inválida");
            }
        }
        return null;
    }
}
