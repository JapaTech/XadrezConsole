using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using TabComponentes;
using TabComponentes.Enums;
using TabComponentes.Xadrez;

namespace SistemaJogoXadrez
{
    internal class Tela
    {
        public static void ImprimirDadosPartida(Partida partida)
        {
            Tela.ImprimirTabuleiro(partida.Tab);
            Console.WriteLine("\n");
            Console.WriteLine("Turno: " + partida.Turno);
            ImprimirPecasCapturadas(partida);

            if (!partida.Terminada)
            {
                Console.WriteLine("Aguardando jogada do " + partida.JogadorAtual.ToString());
                if (partida.Xeque)
                {
                    Console.WriteLine("\n" + partida.JogadorAtual + " EM XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("\n XEQUEMATE do jogador" + partida.JogadorAtual);
            }
            
        }

        public static void ImprimirPecasCapturadas(Partida partida)
        {
            Console.WriteLine("\nPEÇAS CAPTURADAS");
            Console.Write("Brancas: ");
            Console.WriteLine("[" + ImprimirConjuntoDePecas(partida.PecasCapturadasPorCor(Cor.Branco)) + "]" );
            Console.Write("Pretas: ");
            Console.WriteLine("[" + ImprimirConjuntoDePecas(partida.PecasCapturadasPorCor(Cor.Preto)) + "]" );
            
        }

        public static string ImprimirConjuntoDePecas(HashSet<Peca> pecas)
        {
            string aux = "";
            foreach (Peca peca in pecas)
            {
                aux += peca + " ";
            }
            return aux;
        }

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

        public static void ImprimirPeca(Peca peca)
        {
            if(peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branco)
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

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
    }
}
