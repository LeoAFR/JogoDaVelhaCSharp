using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    class Jogo
    {
        private Tabuleiro tabuleiro = new Tabuleiro();

        private Jogador[] jogadores = new Jogador[2];

        private int jogadorAtivoControle = -1; //mudar

        public void Jogar()
        {
            Console.Clear();

            LerNomesJogadores();

            ItemTabuleiro? vencedorTabuleiro;

            while (!tabuleiro.JogoFinalizado(out vencedorTabuleiro))
            {
                Console.Clear();

                MostrarTabuleiro();

                Jogador jogadorAtivo = ProximoJogador();

                Console.ForegroundColor = jogadorAtivo.Cor;
                Console.WriteLine("Jogador {0} , é a sua vez!", jogadorAtivo.Nome);

                while (true)
                {
                    Console.Write("\nDigite o número de um dos campos disponíveis para fazer uma jogada: ");
                    string play = Console.ReadLine();

                    try
                    {
                        ProcessaJogo(play, jogadorAtivo);
                        break;
                    }
                    catch (TrataErros e)
                    {
                        Console.WriteLine("Erro: {0}", e.Message);
                    }
                }
            }

            Console.Clear();

            MostrarTabuleiro();

            Console.WriteLine("A partida terminou!\n");

            Jogador jogadorVencedor = null;

            if (vencedorTabuleiro != null)
            {
                if (jogadores[0].ItemTabuleiro == vencedorTabuleiro)
                {
                    jogadorVencedor = jogadores[0];
                }
                else
                {
                    jogadorVencedor = jogadores[1];
                }

                Console.WriteLine("O vencedor é o jogador {0}! Parabéns!\n", jogadorVencedor.Nome);

                ReinicializaJogo();

            }
            else
            {
                Console.WriteLine("Resultado: Empate!\n\n");

                ReinicializaJogo();

            }

        }

        private void ReinicializaJogo()
        {
            Console.WriteLine("Deseja iniciar uma nova partida?(S/N)");
            string comando = Console.ReadLine().ToUpper();

            while (comando != "S" && comando != "N")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Comando Inválido.\n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Deseja iniciar uma nova partida?(S/N)");
                comando = Console.ReadLine().ToUpper();
            }

            if (comando == "S")
            {
                Console.Clear();//Limpa console

                Jogo jogo = new Jogo();
                jogo.Jogar();
            }
            else
            {
                Environment.Exit(1);// Sair
            }



        }

        #region EventosDoJogo
        private void ProcessaJogo(string jogar, Jogador jogador)
        {
            int row;
            int col;

            try
            {
                if (!int.TryParse(jogar.Substring(0, 1), out row) || !int.TryParse(jogar.Substring(1, 1), out col))
                {
                    throw new TrataErros("A jogada fornecida é inválida");
                }

                if (row < 0 || row > 2 || col < 0 || col > 2)
                {
                    throw new TrataErros("Os índices utilizados estão fora do intervalo permitido");
                }

                jogador.Jogar(tabuleiro, row, col);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new TrataErros("A jogada fornecida é inválida", e);
            }
        }

        #endregion

        #region Jogadores
        private void LerNomesJogadores()
        {
            //Recebe os nomes dos jogadores, faz a validação e Define.

            string nomeJogador1;
            while (true)
            {
                Console.Write("Informe o nome do Jogador 1: ");
                nomeJogador1 = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nomeJogador1))
                {
                    Console.WriteLine("O nome do jogador 1 não é inválido, não pode ser vazio. Exemplo: Jose\n");
                }
                else
                {
                    break;
                }
            }

            string nomeJogador2;
            while (true)
            {
                Console.Write("Informe o nome do Jogador 2: ");
                nomeJogador2 = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nomeJogador2))
                {
                    Console.WriteLine("O nome do jogador 2 é inválido, não pode ser vazio. Exemplo: Maria\n");
                }
                else if (nomeJogador1.ToUpper() == nomeJogador2.ToUpper())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Os nomes dos jogadores não podem ser iguais.\n");

                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    break;
                }
            }

            //Define os Jogadores, sendo jogador 1 X e jogador 2 O
            jogadores[0] = new Jogador(nomeJogador1, ConsoleColor.Green, ItemTabuleiro.X);
            jogadores[1] = new Jogador(nomeJogador2, ConsoleColor.Blue, ItemTabuleiro.O);
        }

        private Jogador ProximoJogador()
        {
            jogadorAtivoControle = (jogadorAtivoControle + 1) % 2;
            return jogadores[jogadorAtivoControle];
        }

        #endregion

        #region Tabuleiro
        private void MostrarTabuleiro()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(tabuleiro.FormatarTabuleiro());
        }
        #endregion

    }
}
