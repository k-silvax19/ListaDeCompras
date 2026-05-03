using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

TelaPrincipal telaPrincipal = new TelaPrincipal();

while (true)
{
    ITelaOpcoes? telaSelecionada = telaPrincipal.ApresentarMenuOpcoesPrincipal();

    if (telaSelecionada == null) 
    {
        Console.Clear();
        
        if (telaPrincipal.SairDoPrograma == true)
            break;
        continue;
    }

    while (true)
    {
        string? opcaoSubMenu = telaSelecionada.ObterOpcaoMenu();
        if (opcaoSubMenu == "S")
        {
            Console.Clear();
            break;
        }
        if (telaSelecionada is ITelaCrud telaCrud)
        {
            if (opcaoSubMenu == "1")
                telaCrud.Cadastrar();

            else if (opcaoSubMenu == "2")
                telaCrud.Editar();

            else if (opcaoSubMenu == "3")
                telaCrud.Excluir();

            else if (opcaoSubMenu == "4")
                telaCrud.VisualizarTodos(deveExibirCabecalho: true);
        }
    }
}