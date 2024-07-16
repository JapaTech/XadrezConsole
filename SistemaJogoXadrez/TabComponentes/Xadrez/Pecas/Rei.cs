using TabComponentes.Enums;

namespace TabComponentes.Xadrez
{
    internal class Rei : Peca
    {
        private Partida partida;

        public Rei(Tabuleiro tab, Cor cor, Partida partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        private bool ExiteTorreRoque(Posicao pos)
        {
            Peca p = tab.RetornaPeca(pos);

            return p != null && p is Torre && p.Cor == Cor && p.QtdMovimentos == 0;
        }

        //Verifica as posições possível que o rei pode mover.
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna);
            if (tab.ValidaPosicao(pos) && PodeMoverPara(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //nordeste
            pos.MudarPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
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

            #region Jogadas Especias
            if(QtdMovimentos == 0 && !partida.Xeque)
            {
                //Roque pequeno
                Posicao RoquePequeno = new Posicao(Posicao.Linha, Posicao.Coluna + 3);

                if (ExiteTorreRoque(RoquePequeno))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);

                    if(tab.RetornaPeca(p1) == null && tab.RetornaPeca(p2)== null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                //Roque Grande
                Posicao RoqueGrande = new Posicao(Posicao.Linha, Posicao.Coluna - 4);

                if (ExiteTorreRoque(RoqueGrande))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                    if (tab.RetornaPeca(p1) == null && tab.RetornaPeca(p2) == null && tab.RetornaPeca(p3) == null)  
                    {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }


            #endregion
            return mat;
        }
        public override string ToString()
        {
            return "R";
        }

    }
}
