using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabComponentes.Enums;
using TabComponentes;

namespace SistemaJogoXadrez.TabComponentes.Xadrez
{
    internal class Rainha : Peca
    {
        public Rainha(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Acima
            pos.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna);
            while (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.RetornaPeca(pos) != null && tab.RetornaPeca(pos).Cor != Cor)
                    break;
                pos.Linha--;
            }

            //Abaixo
            pos.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna);
            while (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.RetornaPeca(pos) != null && tab.RetornaPeca(pos).Cor != Cor)
                    break;
                pos.Linha++;
            }

            //Direita
            pos.MudarPosicao(Posicao.Linha, Posicao.Coluna + 1);
            while (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.RetornaPeca(pos) != null && tab.RetornaPeca(pos).Cor != Cor)
                    break;
                pos.Coluna++;
            }

            //Esquerda
            pos.MudarPosicao(Posicao.Linha, Posicao.Coluna - 1);
            while (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.RetornaPeca(pos) != null && tab.RetornaPeca(pos).Cor != Cor)
                    break;
                pos.Coluna--;
            }

            //Noroeste
            pos.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.RetornaPeca(pos) != null && tab.RetornaPeca(pos).Cor != Cor)
                    break;
                pos.Linha--;
                pos.Coluna--;
            }

            //Sudoeste
            pos.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.RetornaPeca(pos) != null && tab.RetornaPeca(pos).Cor != Cor)
                    break;
                pos.Linha++;
                pos.Coluna--;
            }

            //Sudeste
            pos.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.RetornaPeca(pos) != null && tab.RetornaPeca(pos).Cor != Cor)
                    break;
                pos.Coluna++;
                pos.Linha++;
            }

            //Nordeste
            pos.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.RetornaPeca(pos) != null && tab.RetornaPeca(pos).Cor != Cor)
                    break;
                pos.Coluna++;
                pos.Linha--;
            }

            return mat;
        }

        public override string ToString()
        {
            return "D";
        }
    }
}
