
using System.Diagnostics;
using System.Security.Cryptography;

namespace Testes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declarando as variáveis do jogo
            int chute, tentativas = 0, numeroMin = 1, numeroMax, tentativasMax;
            bool cond = true;

            //Tela de início
            Console.WriteLine(@"
░█████╗░██████╗░██╗██╗░░░██╗██╗███╗░░██╗██╗░░██╗███████╗  ░█████╗░  
██╔══██╗██╔══██╗██║██║░░░██║██║████╗░██║██║░░██║██╔════╝  ██╔══██╗  
███████║██║░░██║██║╚██╗░██╔╝██║██╔██╗██║███████║█████╗░░  ██║░░██║  
██╔══██║██║░░██║██║░╚████╔╝░██║██║╚████║██╔══██║██╔══╝░░  ██║░░██║  
██║░░██║██████╔╝██║░░╚██╔╝░░██║██║░╚███║██║░░██║███████╗  ╚█████╔╝  
╚═╝░░╚═╝╚═════╝░╚═╝░░░╚═╝░░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝╚══════╝  ░╚════╝░  

███╗░░██╗██╗░░░██╗███╗░░░███╗███████╗██████╗░░█████╗░
████╗░██║██║░░░██║████╗░████║██╔════╝██╔══██╗██╔══██╗
██╔██╗██║██║░░░██║██╔████╔██║█████╗░░██████╔╝██║░░██║
██║╚████║██║░░░██║██║╚██╔╝██║██╔══╝░░██╔══██╗██║░░██║
██║░╚███║╚██████╔╝██║░╚═╝░██║███████╗██║░░██║╚█████╔╝
╚═╝░░╚══╝░╚═════╝░╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚═╝░╚════╝░");
            Console.WriteLine("\nBem vindo(a) ao jogo!!");

            do
            {
                //Escolhendo a dificuldade
                Console.WriteLine(@"Primeiro, escolha a dificuldade
1 - Fácil - 1 a 50 - 15 tentativas
2 - Médio - 1 a 100 - 10 tentativas
3 - Difícil 1 a 200 - 5 tentativas");
                int dificuldade = int.Parse(Console.ReadLine()!);
                switch (dificuldade)
                {
                    case 1:
                        Console.WriteLine("Você escolheu a dificuldade fácil!");
                        numeroMax = 50;
                        tentativasMax = 15;
                        break;
                    case 2:
                        Console.WriteLine("Você escolheu a dificuldade média!");
                        numeroMax = 100;
                        tentativasMax = 10;
                        break;
                    case 3:
                        Console.WriteLine("Você escolheu a dificuldade difícil!");
                        numeroMax = 200;
                        tentativasMax = 5;
                        break;
                    default:
                        Console.WriteLine("Dificuldade inválida. Utilizando dificuldade padrão (médio)");
                        numeroMax = 100;
                        tentativasMax = 10;
                        break;
                }
                int numeroSecreto = RandomNumberGenerator.GetInt32(1, numeroMax);
                do
                {
                    tentativas++;
                    Console.WriteLine($"\nDigite um número entre {numeroMin} e {numeroMax} ");
                    chute = int.Parse(Console.ReadLine()!);
                    if (chute < numeroSecreto)
                    {
                        Console.WriteLine("O número secreto é maior que " + chute);
                        numeroMin = chute < numeroMin ? numeroMin : chute;
                    }
                    else if (chute > numeroSecreto)
                    {
                        Console.WriteLine("O número secreto é menor que " + chute);
                        numeroMax = chute > numeroMax ? numeroMax : chute;
                    }
                } while (chute != numeroSecreto && tentativas < tentativasMax);

                if (chute == numeroSecreto) { 
                    //Mensagem de parabéns
                    Console.WriteLine(@"
    ██████╗░░█████╗░██████╗░░█████╗░██████╗░███████╗███╗░░██╗░██████╗
    ██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔════╝████╗░██║██╔════╝
    ██████╔╝███████║██████╔╝███████║██████╦╝█████╗░░██╔██╗██║╚█████╗░
    ██╔═══╝░██╔══██║██╔══██╗██╔══██║██╔══██╗██╔══╝░░██║╚████║░╚═══██╗
    ██║░░░░░██║░░██║██║░░██║██║░░██║██████╦╝███████╗██║░╚███║██████╔╝
    ╚═╝░░░░░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═════╝░╚══════╝╚═╝░░╚══╝╚═════╝░");
                    string palavraTentativa = tentativas > 1 ? "tentativas" : "tentativa";
                    Console.WriteLine("Você descobriu o número secreto!! Você acertou em " + tentativas + " " + palavraTentativa);
                }
                else
                {
                    Console.WriteLine("\nVocê não conseguiu descobrir o número secreto, ele era " + numeroSecreto);
                }
                    //Perguntando se quer sair do jogo
                    Console.WriteLine("\nDeseja jogar novamente? (s/n)");
                string resposta = Console.ReadLine()!;
                if (resposta == "s" || resposta == "S")
                {
                    //Reiniciando as variáveis
                    tentativas = 0;
                    numeroMin = 1;
                    numeroMax = 100;
                    numeroSecreto = RandomNumberGenerator.GetInt32(1, numeroMax);
                }
                else if (resposta == "n" || resposta == "N")
                {
                    cond = false;
                    Console.WriteLine("Obrigado por jogar!");
                }
                else
                {
                    Console.WriteLine("Resposta inválida. O jogo será encerrado.");
                    cond = false;
                }
            } while (cond);



        }
    }
}
