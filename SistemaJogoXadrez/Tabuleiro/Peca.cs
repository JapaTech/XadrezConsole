using TabuleiroItens.Enuns;

namespace TabuleiroItens
{
    internal class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }


        public Peca(Posicao posicao, Cor cor, Tabuleiro tab)
        {
            Posicao = posicao;
            Cor = cor;
            QtdMovimentos = 0;
            this.tab = tab;
        }
    }
}
