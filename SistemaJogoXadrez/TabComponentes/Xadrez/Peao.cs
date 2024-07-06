using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabComponentes;
using TabComponentes.Enums;

namespace SistemaJogoXadrez.TabComponentes.Xadrez
{
    internal class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
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
                }
                
                pos.MudarPosicao(Posicao.Linha - 2, Posicao.Coluna);
                if(tab.ValidaPosicao(pos) && EspacoLivre(pos) && QtdMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
                
                if (ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            else
            {
                pos.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna);
                if (tab.ValidaPosicao(pos) && EspacoLivre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.MudarPosicao(Posicao.Linha + 2, Posicao.Coluna);
                if (tab.ValidaPosicao(pos) && EspacoLivre(pos) && QtdMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);

                if (ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            return mat;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
