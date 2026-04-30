using System;
using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.ModuloCategoria;

public class Categoria : EntidadeBase
{
    public string Nome { get; private set; }
    public string Cor { get; private set; }

    public Categoria(string nome, string cor)
    {
        Nome = nome;
        Cor = cor;
    }

    public override void AtualizarRegistro(EntidadeBase entidadeAtualizada)
    {
       Categoria categoriaAtualizada = (Categoria)entidadeAtualizada;

       Nome = categoriaAtualizada.Nome;
       Cor = categoriaAtualizada.Cor;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if(Nome.Length == 0 || Nome.Length > 50)
            erros += "O Campo \"Nome\" deve conter no entre 0 e 50 caracteres.;";

        if(string.IsNullOrWhiteSpace(Cor))
            erros += "O Campo \"Cor\" deve conter no entre 0 e 50 caracteres.;";
            
        else if (Cor != "Vermelho" && Cor != "Azul" && Cor != "Verde" && Cor != "Branco")
            erros += "O Campo \"Cor\" deve conter uma selecao permitida (Vermelho, Azul, Verde, Branco);";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
}