namespace TabComponentes
{
    internal class Tabuleiro
    {
        public int Linhas {  get; set; }
        public int Colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro (int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca RetornaPeca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca RetornaPeca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }

        public void ColocarPeca(Peca peca, Posicao pos)
        {
            if(TemPecaNaPosicao(pos))
            {
                throw new TabuleiroException("Já existe peça nessa posição");
            }
            pecas[pos.Linha, pos.Coluna] = peca;
            peca.Posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if(RetornaPeca(pos) == null)
            {
                return null;
            }
            Peca aux = RetornaPeca(pos);
            aux.Posicao = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        public bool TemPecaNaPosicao(Posicao pos)
        {
            ValidaPosicao_Ex(pos);
            return RetornaPeca(pos) != null;
        }

        public bool ValidaPosicao(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas) 
                return false;

            return true;
        }

        public void ValidaPosicao_Ex(Posicao pos)
        {
            if (!ValidaPosicao(pos))
            {
                throw new TabuleiroException("Posição Inválida");
            }
        }
    }
}
