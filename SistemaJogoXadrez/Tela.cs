using TabComponentes;
using TabComponentes.Enums;
using TabComponentes.Xadrez;

namespace SistemaJogoXadrez
{
    //Classe responsável por mostrar os elementos da tela
    internal class Tela
    {
        //Método responsável por mostrar de quem é o turno, peças capturas, qual jogador está xeque ou quem fez xequemate
        public static void ImprimirDadosPartida(Partida partida)
        {
            ImprimirTabuleiro(partida.Tab);
            Console.WriteLine("\n");
            Console.WriteLine("Turno: " + partida.Turno);
            ImprimirPecasCapturadas(partida);

            if (!partida.Terminada)
            {
                Console.WriteLine("Aguardando jogada do " + partida.JogadorAtual.ToString());
                if (partida.Xeque)
                {
                    Console.WriteLine("\nJogador da cor " + partida.JogadorAtual + " EM XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("\n!!!XEQUE-MATE do jogador da cor " + partida.JogadorAtual + "!!!");
            }
            
        }

        //Mostra as peças capturadas por cada jogador
        public static void ImprimirPecasCapturadas(Partida partida)
        {
            Console.WriteLine("\nPEÇAS CAPTURADAS");
            Console.Write("Brancas: ");
            Console.WriteLine("[" + ImprimirConjuntoDePecas(partida.PecasCapturadasPorCor(Cor.Branca)) + "]" );
            Console.Write("Pretas: ");
            Console.WriteLine("[" + ImprimirConjuntoDePecas(partida.PecasCapturadasPorCor(Cor.Preta)) + "]" );
            
        }

        //Imprimi as peças da partida separadas por cor
        public static string ImprimirConjuntoDePecas(HashSet<Peca> pecas)
        {
            string aux = "";
            foreach (Peca peca in pecas)
            {
                aux += peca + " ";
            }
            return aux;
        }

        //Função que imprimi o tabuleiro de xadrez, ela percorre as linhas e colocas os números de 1 a 8 na vertial
        //Coloca as letras de "a" a "h" na parte inferior
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for(int j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.RetornaPeca(i, j));   
                    
                }
                Console.Write('\n');
            }
            Console.Write("  a b c d e f g h");
        }

        //Esta sobrecarga também percorre todo o tabuleiro e recebe outro parâmetro, uma matriz dentro do tabuleiro
        //Ela destaca os locais onde essa matriz marca verdadeiro.
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posPossiveis) 
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;


            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posPossiveis[i, j]  == true)
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.RetornaPeca(i, j));
                    Console.BackgroundColor = fundoOriginal;

                }
                Console.Write('\n');
            }
            Console.Write("  a b c d e f g h");
        }

        //Imprimi uma peça de acordo com a sua cor
        public static void ImprimirPeca(Peca peca)
        {
            if(peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }

            
        }

        //Recebe uma posição digitada pelo usuário no formato de xadrez (exeplo: "a1")
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
    }
}
