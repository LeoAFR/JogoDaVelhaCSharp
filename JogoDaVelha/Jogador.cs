using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    class Jogador
    {
        public string Nome { get; private set; }
        public ConsoleColor Cor { get; private set; }
        public ItemTabuleiro ItemTabuleiro { get; private set; }


        public Jogador(string nome, ConsoleColor cor, ItemTabuleiro itemTabuleiro)
        {
            this.Nome = nome;
            this.Cor = cor;
            this.ItemTabuleiro = itemTabuleiro;
        }

        public void Jogar(Tabuleiro Tabuleiro, int linha, int coluna)
        {
            Tabuleiro.Jogar(linha, coluna, ItemTabuleiro);
        }
    }
}
