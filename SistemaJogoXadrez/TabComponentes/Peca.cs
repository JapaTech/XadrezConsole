using TabComponentes.Enums;

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

        public abstract bool[,] MovimentosPossiveis();

        protected bool PodeMover(Posicao pos)
        {
            Peca p = tab.RetornaPeca(pos);

            return p == null || p.Cor != Cor;
        }
    }
}
