using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabComponentes;
using TabComponentes.Enums;

namespace SistemaJogoXadrez.TabComponentes.Xadrez
{
    internal class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        //Verifica as posições possível que o rei pode mover.
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //acima e esquerda
            pos.MudarPosicao(Posicao.Linha - 2, Posicao.Coluna -1);
            if (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //acima e direita
            pos.MudarPosicao(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //direita e sobre
            pos.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //direita e desce
            pos.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //abaixo e direita
            pos.MudarPosicao(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //abaixo e esquerda
            pos.MudarPosicao(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //esquerda e abaixo
            pos.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //esquerda e acima
            pos.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
        public override string ToString()
        {
            return "C";
        }
    }
}
