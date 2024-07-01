using System.Collections.Generic;
using TabComponentes.Enums;

namespace TabComponentes.Xadrez
{
    internal class Partida
    {
        public Tabuleiro Tab { get; private set; } 
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public Partida()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
            Terminada = false;
        }

        private void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPoiscao());
            pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branco));
            ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branco));
            ColocarNovaPeca('d', 2, new Torre(Tab, Cor.Branco));
            ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branco));
            ColocarNovaPeca('e', 1, new Torre(Tab, Cor.Branco));
            ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branco));

            ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preto));
            ColocarNovaPeca('c', 8, new Torre(Tab, Cor.Preto));
            ColocarNovaPeca('d', 7, new Torre(Tab, Cor.Preto));
            ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preto));
            ColocarNovaPeca('e', 8, new Torre(Tab, Cor.Preto));
            ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preto));
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
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
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

        public HashSet<Peca> PecasCapturadasPorCor(Cor cor)
        {
            HashSet<Peca> aux  = new HashSet<Peca>();

            foreach (Peca item in capturadas)
            {
                if(item.Cor == cor)
                {
                    aux.Add(item);
                }
            }

            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca item in aux)
            {
                if (item.Cor == cor)
                {
                    aux.Add(item);
                }
            }
            aux.ExceptWith(PecasCapturadasPorCor(cor));
            return aux;
        }
    }
}
