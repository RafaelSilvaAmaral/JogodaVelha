using System;

namespace tictactoe
{
    internal class tictactoe
    {
        static String[] ttt = {" ", " ", " ", " ", " ", " ", " ", " ", " "}; // Matriz inicial, com todos as posições vazias
        static String[] ttt2 = {"1", "2", "3", "4", "5", "6", "7", "8", "9"}; // Matriz utilizada na explicação do jogo
        static int jogador = 1; // Jogador 1 começa jogando
        static int vez;
        // Esse método printa na tela as informações necessárias para os jogadores poderem jogar
        static void regras() {
            Console.WriteLine("Os jogadores devem inserir números de 1 a 9, de acordo com o tabuleiro a seguir:\n");
            Console.WriteLine("  {0} | {1} | {2} ", ttt2[6], ttt2[7], ttt2[8]);
            Console.WriteLine(" ---|---|--- ");
            Console.WriteLine("  {0} | {1} | {2} ", ttt2[3], ttt2[4], ttt2[5]);
            Console.WriteLine(" ---|---|--- ");
            Console.WriteLine("  {0} | {1} | {2} \n", ttt2[0], ttt2[1], ttt2[2]);
            Console.WriteLine("O jogador 1 inicia a partida e será o X, o jogador 2 será o O.");
        }
        // Esse método checa de qual jogador é a vez atualmente
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
        // Esse método checa se um dos jogadores ganhou, se a partida terminou ou empate ou se a partida deve continuar
        // 1 -> Vitória do Jogador 1
        // 2 -> Vitória do Jogador 2
        // 3 -> Empate
        // 4 -> Partida continua
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
        // Esse método imprime o tabuleiro atualizado na tela, ele insere o movimento do jogador antes de imprimir
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
            // Ficará em loop enquanto não houver vencedor ou ocorrer empate
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