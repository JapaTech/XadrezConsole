using TabComponentes;

namespace TabComponentes.Xadrez
{
    //Classe que lê a posição comumente usada no xadrez (exemplo: (a1))
    internal class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        //Converte a posição do xadrez para uma posição de matriz comum
        public Posicao ToPoiscao()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return $"{Coluna}{Linha}";
        }
    }
}
