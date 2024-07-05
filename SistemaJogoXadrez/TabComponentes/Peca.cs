using TabComponentes.Enums;

namespace TabComponentes
{
    //Classe base das peças do tabuleiro
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

        //Função abstrata que serve para retornar uma matriz que representa onde a peça pode se mover dentro do tabuleiro
        public abstract bool[,] MovimentosPossiveis();

        //Retorna se existe pelo menos um movimento possível para a peça
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

        //Verifica se é possível se mover para determinada posição
        public bool ExisteMovimentoPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        //Verifica se para a onde a peça vai mover é um lugar vazio ou é com uma peça da cor adversária
        protected bool PodeMoverPara(Posicao pos)
        {
            Peca p = tab.RetornaPeca(pos);

            return p == null || p.Cor != Cor;
        }
        
    }
}
