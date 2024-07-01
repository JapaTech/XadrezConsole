using System.Runtime.CompilerServices;
using TabComponentes.Enums;

namespace TabComponentes.Xadrez
{
    internal class Partida
    {
        public Tabuleiro Tab { get; private set; } 
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        public Partida()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            ColocarPecas();
            Terminada = false;
        }

        private void ColocarPecas()
        {
            Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('c', 1).ToPoiscao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('c', 2).ToPoiscao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('d', 2).ToPoiscao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('e', 2).ToPoiscao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('e', 1).ToPoiscao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Branco), new PosicaoXadrez('d', 1).ToPoiscao());

            Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez('c', 7).ToPoiscao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez('c', 8).ToPoiscao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez('d', 7).ToPoiscao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez('e', 7).ToPoiscao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez('e', 8).ToPoiscao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Preto), new PosicaoXadrez('d', 8).ToPoiscao());
        }

        public void RealizaMovimento(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            TrocaJogador();
            Turno++;
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQtdMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
        }

        public void ValidaPosicaoOrigem(Posicao pos)
        {
            if(Tab.RetornaPeca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça nessa posição");
            }
            
            if (Tab.RetornaPeca(pos).Cor != JogadorAtual)
            {
                throw new TabuleiroException("Essa peça é do outro jogador");
            }

            if (!Tab.RetornaPeca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Essa peça não pode se mover");
            }
        }

        public void ValidaPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.RetornaPeca(origem).PodeMoverParaPosicao(destino))
            {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }

        private void TrocaJogador()
        {
            JogadorAtual = JogadorAtual == Cor.Branco ? Cor.Preto : Cor.Branco;
        }
    }
}
