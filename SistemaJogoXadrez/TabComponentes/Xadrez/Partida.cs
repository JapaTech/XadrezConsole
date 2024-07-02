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
        public bool Xeque { get; private set; }

        public Partida()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
            Terminada = false;
            Xeque = false;
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

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQtdMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            Tab.ColocarPeca(p, destino);
            return pecaCapturada;
        }

        private void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tab.RetirarPeca(destino);
            p.DecrementarQtdMovimentos(); 

            if(pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }

            Tab.ColocarPeca(p, origem);
        }

        public void RealizaMovimento(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
           
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Esta jogada te coloca em xeque");
            }

            if (EstaEmXeque(Adversario(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            
            TrocaJogador();
            Turno++;
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

        private Cor Adversario(Cor cor)
        {
            return cor == Cor.Branco ? Cor.Preto : Cor.Branco;
        }

        private Peca RetornaRei(Cor cor)
        {
            foreach (Peca peca in PecasEmJogo(cor))
            {
                if(peca is Rei)
                {
                    return peca;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca rei = RetornaRei(cor);

            if(rei == null)
            {
                throw new TabuleiroException("Rei não existe. Erro Fatal");
            }

            foreach (Peca peca in PecasEmJogo(Adversario(cor)))
            {
                bool[,] mat = peca.MovimentosPossiveis();
                if (mat[rei.Posicao.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
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

            foreach (Peca item in pecas)
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
