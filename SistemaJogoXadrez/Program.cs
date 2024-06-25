using SistemaJogoXadrez;
using TabComponentes;
using TabComponentes.Xadrez;
using TabComponentes.Enums;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.ColocarPeca(new Rei(tab, Cor.Preto), new Posicao(0, 0));
            tab.ColocarPeca(new Torre(tab, Cor.Amarelo), new Posicao(1, 0));
            tab.ColocarPeca(new Rei(tab, Cor.Preto), new Posicao(0, 7));

            Tela.ImprimirTabuleiro(tab);
            
            Console.WriteLine();
        }
        catch (TabuleiroException e)
        {

            Console.Write(e.Message);
        }
        Console.ReadLine();

    }
}