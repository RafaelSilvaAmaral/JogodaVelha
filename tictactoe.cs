using System;

namespace tictactoe
{
    internal class tictactoe
    {
        static String[] ttt = {" ", " ", " ", " ", " ", " ", " ", " ", " "};
        static String[] ttt2 = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
        static int jogador = 1;
        static int vez;
        static void regras() {
            Console.WriteLine("Os jogadores devem inserir números de 1 a 9, de acordo com o tabuleiro a seguir:\n");
            Console.WriteLine("  {0} | {1} | {2} ", ttt2[6], ttt2[7], ttt2[8]);
            Console.WriteLine(" ---|---|--- ");
            Console.WriteLine("  {0} | {1} | {2} ", ttt2[3], ttt2[4], ttt2[5]);
            Console.WriteLine(" ---|---|--- ");
            Console.WriteLine("  {0} | {1} | {2} \n", ttt2[0], ttt2[1], ttt2[2]);
            Console.WriteLine("O jogador 1 inicia a partida e será o X, o jogador 2 será o O.");
        }
        static int checavez(){
            if ((jogador % 2) != 0) {
                Console.WriteLine ("Vez do jogador 1!");
                return 1;
            }
            else {
                Console.WriteLine ("Vez do jogador 2!");
                return 2;
            }
        }
        static int checastatus(int jogador){
            if (ttt[0] == ttt[3] & ttt[3] == ttt[6] && ttt[0] != " ")
                return jogador;
            else if (ttt[1] == ttt[4] & ttt[4] == ttt[7] && ttt[1] != " ")
                return jogador;
            else if (ttt[2] == ttt[5] & ttt[5] == ttt[8] && ttt[2] != " ")
                return jogador;
            else if (ttt[0] == ttt[1] & ttt[1] == ttt[2] && ttt[0] != " ")
                return jogador;
            else if (ttt[3] == ttt[4] & ttt[4] == ttt[5] && ttt[3] != " ")
                return jogador;
            else if (ttt[6] == ttt[7] & ttt[7] == ttt[8] && ttt[6] != " ")
                return jogador;
            else if (ttt[0] == ttt[4] & ttt[4] == ttt[8] && ttt[0] != " ")
                return jogador;
            else if (ttt[2] == ttt[4] & ttt[4] == ttt[6] && ttt[2] != " ")
                return jogador;
            else if (ttt[0] != " " && ttt[1] != " " && ttt[2] != " " && ttt[3] != " " && ttt[4] != " " && ttt[5] != " " && ttt[6] != " " && ttt[7] != " " && ttt[8] != " ")
                return 3;
            else
                return 4;
        }
        static void imprimetabuleiro(int entrada, int vez) {
            if (vez == 1) 
                ttt[entrada-1] = "X";
            else
                ttt[entrada-1] = "O";
            Console.WriteLine("  {0} | {1} | {2} ", ttt[6], ttt[7], ttt[8]);
            Console.WriteLine(" ---|---|--- ");
            Console.WriteLine("  {0} | {1} | {2} ", ttt[3], ttt[4], ttt[5]);
            Console.WriteLine(" ---|---|--- ");
            Console.WriteLine("  {0} | {1} | {2} \n", ttt[0], ttt[1], ttt[2]);
        }
         static void Main(string[] args)
        {
            int status = 4;
            string entrada;
            int entradaint;
            tictactoe.regras();
            
            do {
                vez = checavez();
                Console.WriteLine("Entre um número de 1 a 9, de acordo com o exemplo inicial:");
                entrada = Console.ReadLine();
                Int32.TryParse(entrada, out entradaint);
                if (entradaint >= 1 && entradaint <= 9) {
                    imprimetabuleiro (entradaint, vez);
                    status = checastatus (jogador);
                    if (status != 4)
                         break;
                    jogador = (jogador % 2) + 1;
                }
                else
                    Console.WriteLine("Entrada incorreta! Favor inserir um número de 1 a 9.");
            } while (status == 4);
            if (status == 1)
                Console.WriteLine ("Jogador 1 venceu!");
            else if (status == 2)
                Console.WriteLine ("Jogador 2 venceu!");
            else if (status == 3)
                Console.WriteLine ("A partida terminou em empate!");
        } 
    }
}