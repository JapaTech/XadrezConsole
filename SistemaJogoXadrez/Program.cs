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
            Partida partida = new Partida();
            
            while(!partida.Terminada)
            {
                Console.Clear();
                Tela.ImprimirTabuleiro(partida.Tab);

                Console.WriteLine("\n");
                Console.Write("Origem: ");
                Posicao origem = Tela.LerPosicaoXadrez().ToPoiscao();

                bool[,] posicoesPossiveis = partida.Tab.RetornaPeca(origem).MovimentosPossiveis();
                Console.Clear();
                Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                Console.Write("\nDestino: ");
                Posicao destino = Tela.LerPosicaoXadrez().ToPoiscao();

                partida.ExecutaMovimento(origem, destino);
            }
            
            Console.WriteLine();
        }
        catch (TabuleiroException e)
        {

            Console.Write(e.Message);
        }
        Console.ReadLine();

    }
}