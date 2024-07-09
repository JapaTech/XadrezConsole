using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabComponentes;
using TabComponentes.Enums;
using TabComponentes.Xadrez;

namespace SistemaJogoXadrez.TabComponentes.Xadrez
{
    internal class Peao : Peca
    {
        Partida partida;

        public Peao(Tabuleiro tab, Cor cor, Partida partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        private bool EspacoLivre(Posicao pos)
        {
            return tab.RetornaPeca(pos) == null;
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca peca = tab.RetornaPeca(pos);
            return peca != null && peca.Cor != Cor;
        }

        //Verifica as posições possível que o rei pode mover.
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            if(Cor == Cor.Branca)
            {
                pos.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna);
                if(tab.ValidaPosicao(pos) && EspacoLivre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                    
                    pos.MudarPosicao(Posicao.Linha - 2, Posicao.Coluna);
                    if (tab.ValidaPosicao(pos) && EspacoLivre(pos) && QtdMovimentos == 0)
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                }
 
                pos.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
                
                if (tab.ValidaPosicao(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (tab.ValidaPosicao(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                #region Jogada Especial
                if(Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (tab.ValidaPosicao(esquerda) && ExisteInimigo(esquerda) && tab.RetornaPeca(esquerda) == partida.VulneravelEnPassant)
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (tab.ValidaPosicao(direita) && ExisteInimigo(direita) && tab.RetornaPeca(direita) == partida.VulneravelEnPassant)
                    {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }

                }
                #endregion
            }
            else
            {
                pos.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna);
                if (tab.ValidaPosicao(pos) && EspacoLivre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                    pos.MudarPosicao(Posicao.Linha + 2, Posicao.Coluna);
                    if (tab.ValidaPosicao(pos) && EspacoLivre(pos) && QtdMovimentos == 0)
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                }

                pos.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);

                if (tab.ValidaPosicao(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (tab.ValidaPosicao(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                #region Jogada Especial
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (tab.ValidaPosicao(esquerda) && ExisteInimigo(esquerda) && partida.VulneravelEnPassant == tab.RetornaPeca(esquerda))
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (tab.ValidaPosicao(direita) && ExisteInimigo(direita) && partida.VulneravelEnPassant == tab.RetornaPeca(direita))
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }

                }
                #endregion
            }
            return mat;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
