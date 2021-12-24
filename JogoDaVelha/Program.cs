using System;
using System.Threading;

namespace JogoDaVelha
{
    class Program
    {

        static void Main(string[] args)
        {
            //Inicializa o Jogo mostrando uma breve saudação.
            MostrarIntroducao();

        }

        static void MostrarIntroducao()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Bem-Vindo ao Jogo da Velha!\n");

            Console.WriteLine("Para começar o jogo, informe o nome dos dois jogadores.");
            Console.WriteLine("O jogador 1 será X e o jogador 2 será O.");
            Console.WriteLine("Para fazer uma jogada, basta informar o número do campo do tabuleiro onde você deseja inserir X ou O.");
            Console.WriteLine("Os números das campos são referencias de uma matriz de 3x3. Insira o número correspondente ao campo desejado.");
            Console.WriteLine("Ganha o jogador que primeiro formar uma reta na diagonal, vertical ou horizontal do tabuleiro.\n");

            Console.WriteLine("Deseja iniciar?(S/N)");

            string comando = Console.ReadLine().ToUpper();

            while (comando != "S" && comando != "N")
            {
                Console.WriteLine("\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Comando Inválido.");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Deseja iniciar?(S/N)");

                comando = Console.ReadLine().ToUpper();
            }

            if (comando == "S")
            {
                //Inicializa o Jogo da Velha
                IniciarJogoDaVelha();
            }
            else
            {
                Environment.Exit(1);// Sair
            }


        }
        public static void IniciarJogoDaVelha()
        {
            Jogo jogoDaVelha = new Jogo();
            jogoDaVelha.Jogar();

        }

    }
}