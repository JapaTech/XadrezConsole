﻿using SistemaJogoXadrez;
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
                try
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);

                    Console.WriteLine("\n");
                    Console.WriteLine("Turno: " + partida.Turno);
                    Console.WriteLine("Aguardando jogada do " + partida.JogadorAtual.ToString());
                    Console.Write("\nOrigem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPoiscao();
                    partida.ChecaPosicaoOrigem(origem);

                    bool[,] posicoesPossiveis = partida.Tab.RetornaPeca(origem).MovimentosPossiveis();
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                    Console.Write("\nDestino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPoiscao();

                    partida.RealizaMovimento(origem, destino);
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
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