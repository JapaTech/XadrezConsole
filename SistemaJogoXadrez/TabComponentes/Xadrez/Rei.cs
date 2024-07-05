using TabComponentes.Enums;

namespace TabComponentes.Xadrez
{
    internal class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        public override string ToString()
        {
            return "R";
        }

        //Verifica as posições possível que o rei pode mover.
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];
            
            Posicao pos = new Posicao(0, 0);

            //acima
            pos.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna);
            if(tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //nordeste
            pos.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna + 1 );
            if (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //direita
            pos.MudarPosicao(Posicao.Linha, Posicao.Coluna + 1);
            if (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //sudeste
            pos.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //abaixo
            pos.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna);
            if (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //sudoeste
            pos.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //esquerda
            pos.MudarPosicao(Posicao.Linha, Posicao.Coluna - 1);
            if (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //noroeste
            pos.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
    }
}
