
namespace TabComponentes
{
    //Classe que representa uma posição seguindo a lógica matemática (x,y).
    //É usada principalmente na matriz do tabuleiro
    internal class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public override string ToString()
        {
            return $"{Linha}, {Coluna}";
        }

        //Muda o valor dessa posição
        public void MudarPosicao(int linha, int coluna)
        {
            Linha = linha ;
            Coluna = coluna ;
        }
    }
}
