
namespace TabuleiroItens
{
    internal class Posicao
    {
        public int Linha { get; set; }
        public int Colula { get; set; }

        public Posicao(int linha, int colula)
        {
            Linha = linha;
            Colula = colula;
        }

        public override string ToString()
        {
            return $"{Linha}, {Colula}";
        }
    }
}
