﻿using TabComponentes.Enums;

namespace TabComponentes
{
    internal abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }


        public Peca(Tabuleiro tab, Cor cor)
        {
            Posicao = null;
            Cor = cor;
            QtdMovimentos = 0;
            this.tab = tab;
        }

        public void IncrementarQtdMovimentos()
        {
            QtdMovimentos++;
        }

        public void DecrementarQtdMovimentos()
        {
            QtdMovimentos--;
        }

        public abstract bool[,] MovimentosPossiveis();

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();

            for (int i = 0; i < tab.Linhas; i++)
            {
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }   
            return false;
        }

        public bool PodeMoverParaPosicao(Posicao pos)
        {
            
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        protected bool PodeMover(Posicao pos)
        {
            Peca p = tab.RetornaPeca(pos);

            return p == null || p.Cor != Cor;
        }
        
    }
}
