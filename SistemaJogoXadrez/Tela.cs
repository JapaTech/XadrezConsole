using TabComponentes;

namespace SistemaJogoXadrez
{
    internal class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                for(int j = 0; j < tab.Colunas; j++)
                {
                    if(tab.RetornaPeca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    Console.Write(tab.RetornaPeca(i, j));
                }
                Console.Write('\n');
            }
        }
    }
}
