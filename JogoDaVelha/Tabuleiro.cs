using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    enum ItemTabuleiro
    {
        X,
        O,
        EMPTY
    }

    class Tabuleiro
    {
        private ItemTabuleiro[,] matriz = new ItemTabuleiro[3, 3];

        public Tabuleiro()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matriz[i, j] = ItemTabuleiro.EMPTY;
                }
            }
        }

        #region EventosDoTabuleiro
        public void Jogar(int linha, int coluna, ItemTabuleiro itemTabuleiro)
        {
            if (matriz[linha, coluna] != ItemTabuleiro.EMPTY)
            {
                throw new TrataErros("Você não pode marcar esse campo do tabuleiro, ele já está marcado.");
            }

            matriz[linha, coluna] = itemTabuleiro;
        }

        public string FormatarTabuleiro()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" -JOGO DA VELHA- ").AppendLine();
            sb.AppendLine();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matriz[i, j] == ItemTabuleiro.EMPTY)
                    {
                        sb.Append(" ").Append(ConverterItemTabuleiro(matriz[i, j]));
                    }
                    else
                    {
                        sb.Append("  ").Append(ConverterItemTabuleiro(matriz[i, j])).Append("  ");
                    }


                    if (j < 3)
                    {
                        if (matriz[i, j] == ItemTabuleiro.EMPTY)
                        {
                            sb.Append(string.Format("{0}{1} ", i.ToString(), j.ToString()));
                            if (j < 2)
                            {
                                sb.Append("|");
                            }
                        }
                        else if (j < 2)
                        {
                            sb.Append("|");
                        }

                    }
                }
                sb.AppendLine();

                if (i < 2)
                {
                    sb.Append("-----------------").AppendLine();
                }
            }

            return sb.ToString();
        }

        private char ConverterItemTabuleiro(ItemTabuleiro itemTabuleiro)
        {
            switch (itemTabuleiro)
            {
                case ItemTabuleiro.X: return 'X';
                case ItemTabuleiro.O: return 'O';
                default: return ' ';
            }
        }

        public bool JogoFinalizado(out ItemTabuleiro? vencedorTabuleiro)
        {
            vencedorTabuleiro = ChecarSequencia();

            if (vencedorTabuleiro != null)
            {
                return true;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matriz[i, j] == ItemTabuleiro.EMPTY)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private ItemTabuleiro? ChecarSequencia()
        {
            if (matriz[0, 0] != ItemTabuleiro.EMPTY && matriz[0, 0] == matriz[0, 1] && matriz[0, 1] == matriz[0, 2])
            {
                return matriz[0, 0];
            }

            if (matriz[1, 0] != ItemTabuleiro.EMPTY && matriz[1, 0] == matriz[1, 1] && matriz[1, 1] == matriz[1, 2])
            {
                return matriz[1, 0];
            }

            if (matriz[2, 0] != ItemTabuleiro.EMPTY && matriz[2, 0] == matriz[2, 1] && matriz[2, 1] == matriz[2, 2])
            {
                return matriz[2, 0];
            }

            if (matriz[0, 0] != ItemTabuleiro.EMPTY && matriz[0, 0] == matriz[1, 0] && matriz[1, 0] == matriz[2, 0])
            {
                return matriz[0, 0];
            }

            if (matriz[0, 1] != ItemTabuleiro.EMPTY && matriz[0, 1] == matriz[1, 1] && matriz[1, 1] == matriz[2, 1])
            {
                return matriz[0, 1];
            }

            if (matriz[0, 2] != ItemTabuleiro.EMPTY && matriz[0, 2] == matriz[1, 2] && matriz[1, 2] == matriz[2, 2])
            {
                return matriz[0, 2];
            }

            if (matriz[0, 0] != ItemTabuleiro.EMPTY && matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2])
            {
                return matriz[0, 0];
            }

            if (matriz[0, 2] != ItemTabuleiro.EMPTY && matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0])
            {
                return matriz[0, 2];
            }

            return null;
        }

        #endregion
    }
}