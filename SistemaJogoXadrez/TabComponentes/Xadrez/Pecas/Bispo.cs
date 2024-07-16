using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabComponentes;
using TabComponentes.Enums;

namespace SistemaJogoXadrez.TabComponentes.Xadrez
{
    internal class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        //Com um for ele pega a posição da torre e verifica para quais direções ela pode se mover
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

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
            return "B";
        }
    }
}
