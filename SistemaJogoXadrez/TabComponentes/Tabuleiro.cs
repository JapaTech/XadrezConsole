namespace TabComponentes
{
    internal class Tabuleiro
    {
        public int Linhas {  get; set; }
        public int Colunas { get; set; }
        private Peca[,] pecas;

        //Construtor
        public Tabuleiro (int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        //Recebe uma posição na matriz no tabuleiro (x,y) e retorna a peça que está nessa posição
        public Peca RetornaPeca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        //Sobrecarga que faz a função funiconar usando a classe "Posição"
        public Peca RetornaPeca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }

        //Coloca uma peça
        public void ColocarPeca(Peca peca, Posicao pos)
        {
            //Verifica se tem peça na posição desejada
            if(TemPecaNaPosicao(pos))
            {
                throw new TabuleiroException("Já existe peça nessa posição");
            }
            pecas[pos.Linha, pos.Coluna] = peca;
            peca.Posicao = pos;
        }
        
        //Tira uma peca de uma posição no tabuleiro, se houver, e retorna essa peça
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

        //Verifica se tem peça na posição
        public bool TemPecaNaPosicao(Posicao pos)
        {
            ValidaPosicao_Ex(pos);
            return RetornaPeca(pos) != null;
        }

        //Verifica se o usuário digitou uma posição válida dentro do tabuleiro
        public bool ValidaPosicao(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas) 
                return false;

            return true;
        }

        //Se não exister a posição, retonra uma exceção
        public void ValidaPosicao_Ex(Posicao pos)
        {
            if (!ValidaPosicao(pos))
            {
                throw new TabuleiroException("Posição Inválida");
            }
        }
    }
}
