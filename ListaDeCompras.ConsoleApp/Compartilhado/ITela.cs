namespace ListaDeCompras.ConsoleApp.Compartilhado;

public interface ITelaOpcoes // é um conceito totalmente abstrato
{
    string? ObterOpcaoMenu(); // toda classe que implementa essa interface precisa implementar esse método
}
