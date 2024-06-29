using TabComponentes.Enums;

namespace TabComponentes.Xadrez
{
    internal class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Acima
            pos.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna);
            while (tab.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.RetornaPeca(pos) != null && tab.RetornaPeca(pos).Cor != Cor)
                    break;
                pos.Linha--;
            }

            //Abaixo
            pos.MudarPosicao(Posicao.Linha + 1, Posicao.Coluna);
            while (tab.ValidaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.RetornaPeca(pos) != null && tab.RetornaPeca(pos).Cor != Cor)
                    break;
                pos.Linha++;
            }

            //Direita
            pos.MudarPosicao(Posicao.Linha, Posicao.Coluna +1);
            while (tab.ValidaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.RetornaPeca(pos) != null && tab.RetornaPeca(pos).Cor != Cor)
                    break;
                pos.Coluna++;
            }

            //Esquerda
            pos.MudarPosicao(Posicao.Linha, Posicao.Coluna - 1);
            while (tab.ValidaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.RetornaPeca(pos) != null && tab.RetornaPeca(pos).Cor != Cor)
                    break;
                pos.Coluna--;
            }

            return mat;
        }

        /*
        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.RetornaPeca(pos);

            return p == null || p.Cor != Cor;
        }*/

        public override string ToString()
        {
            return "T";
        }
    }
}
