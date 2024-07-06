﻿using SistemaJogoXadrez.TabComponentes.Xadrez;
using System.Collections.Generic;
using TabComponentes.Enums;

namespace TabComponentes.Xadrez
{
    internal class Partida
    {
        public Tabuleiro Tab { get; private set; } 
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool Xeque { get; private set; }

        //Construtor
        public Partida()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
            Terminada = false;
            Xeque = false;
        }

        //Coloca uma nova peça no tabuleiro na posição, usando a posição do tabuleiro (ex: "a1")
        private void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPoiscao());
            pecas.Add(peca);
        }

        //Coloca as peças de xadrez no tabuleiro
        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(Tab, Cor.Branca));
            ColocarNovaPeca('c', 1, new Bispo(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rainha(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(Tab, Cor.Branca));
            ColocarNovaPeca('f', 1, new Bispo(Tab, Cor.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(Tab, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('a', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('b', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('c', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('d', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('e', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('f', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('g', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('h', 2, new Peao(Tab, Cor.Branca));
            
            ColocarNovaPeca('a', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('b', 8, new Cavalo(Tab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Bispo(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rainha(Tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(Tab, Cor.Preta));
            ColocarNovaPeca('f', 8, new Bispo(Tab, Cor.Preta));
            ColocarNovaPeca('g', 8, new Cavalo(Tab, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('a', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('b', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('c', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('d', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('e', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('f', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('g', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('h', 7, new Peao(Tab, Cor.Preta));

        }

        //Executa o movimento da peça, recebendo a origem e o destino
        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            //Pega a peça da origem do movimento e a move
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQtdMovimentos();
            //Se tiver uma peça no destino, a captura e retorna essa peça
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        //Desfaz o movimento do xadrez, é o inverso do executa movimento
        private void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tab.RetirarPeca(destino);
            p.DecrementarQtdMovimentos(); 

            if(pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }

            Tab.ColocarPeca(p, origem);
        }

        //Função que realiza o movimento e verifica o estado do tabuleiro após o movimento, como, por exemplo se há xeque
        public void RealizaMovimento(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
           
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Esta jogada te coloca em xeque");
            }

            if (EstaEmXeque(Adversario(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            if (EstaEmXequeMate(Adversario(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                TrocaJogador();
                Turno++;
            }
        }

        //Verifica se a posição forncida é valida
        public void ValidaPosicaoOrigem(Posicao pos)
        {
            if(Tab.RetornaPeca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça nessa posição");
            }
            
            if (Tab.RetornaPeca(pos).Cor != JogadorAtual)
            {
                throw new TabuleiroException("Essa peça é do outro jogador");
            }

            if (!Tab.RetornaPeca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Essa peça não pode se mover");
            }
        }

        //Verifica se a posição para qual uma peça pode se mover é valida
        public void ValidaPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.RetornaPeca(origem).ExisteMovimentoPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }

        //Muda a cor do jogador do turno
        private void TrocaJogador()
        {
            JogadorAtual = JogadorAtual == Cor.Branca ? Cor.Preta : Cor.Branca;
        }

        //Retorna a cor do adversário
        private Cor Adversario(Cor cor)
        {
            return cor == Cor.Branca ? Cor.Preta : Cor.Branca;
        }

        //Retorna a peça que é o rei
        private Peca RetornaRei(Cor cor)
        {
            foreach (Peca peca in PecasEmJogo(cor))
            {
                if(peca is Rei)
                {
                    return peca;
                }
            }
            return null;
        }

        //Verifica se o rei está em xeque
        public bool EstaEmXeque(Cor cor)
        {
            Peca rei = RetornaRei(cor);

            if(rei == null)
            {
                throw new TabuleiroException("Rei não existe. Erro Fatal");
            }

            //Verifica se existe a possibilidade de uma peça adversária de se mover para a casa do rei do jogador atual
            foreach (Peca peca in PecasEmJogo(Adversario(cor)))
            {
                bool[,] mat = peca.MovimentosPossiveis();
                if (mat[rei.Posicao.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        //Verifica se ocorreu xeque-mate
        public bool EstaEmXequeMate(Cor cor)
        {
            //Se não está em xeque, logicamente não precisa verificar o xeque-mate
            if (!EstaEmXeque(cor))
            {
                return false;
            }

            //Verifica para onde cada peça aliada em jogo pode se mover
            foreach (Peca peca in PecasEmJogo(cor))
            {
                bool[,] mat = peca.MovimentosPossiveis();

                for (int i = 0; i < Tab.Linhas; i++)
                {
                    for (int j = 0; j < Tab.Colunas; j++)
                    {
                        //Se exister um movimento que não existe xeque, não é possível xeque-mate
                        if (mat[i, j])
                        {
                            Posicao origem = peca.Posicao; 
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            //Caso não existe um movimento em que o xeque não deixe de existir, será xeque-mate
            return true;
        }

        //Função que filtra o HashSet de peças capturas separadas pela cor
        public HashSet<Peca> PecasCapturadasPorCor(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca item in capturadas)
            {
                if(item.Cor == cor)
                {
                    aux.Add(item);
                }
            }

            return aux;
        }

        //Função que fitra quais as peças estão em jogo por cor
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca item in pecas)
            {
                if (item.Cor == cor)
                {
                    aux.Add(item);
                }
            }
            aux.ExceptWith(PecasCapturadasPorCor(cor));
            return aux;
        }
    }
}
