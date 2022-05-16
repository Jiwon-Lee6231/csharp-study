using System;

namespace CSharp
{
    class Program
    {
        enum Choice
        {
            ROCK = 1,
            SCISSORS = 0,
            PAPER = 2
        }

        static void Main(string[] args)
        {
            // 0 : 가위, 1 : 바위, 2 : 보
            // const int ROCK = 1;
            // const int SCISSORS = 0;
            // const int PAPER = 2;

            Random rand = new Random();
            int aiChoice = rand.Next(0, 3);

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case (int)Choice.SCISSORS :
                    Console.WriteLine("당신의 선택은 가위입니다.");
                    break;
                case (int)Choice.ROCK :
                    Console.WriteLine("당신의 선택은 바위입니다.");
                    break;
                case (int)Choice.PAPER :
                    Console.WriteLine("당신의 선택은 보입니다.");
                    break;
            }

            switch (aiChoice)
            {
                case (int)Choice.SCISSORS:
                    Console.WriteLine("컴퓨터의 선택은 가위입니다.");
                    break;
                case (int)Choice.ROCK:
                    Console.WriteLine("컴퓨터의 선택은 바위입니다.");
                    break;
                case (int)Choice.PAPER:
                    Console.WriteLine("컴퓨터의 선택은 보입니다.");
                    break;
            }

            // 승리 무승부 패배
            if (choice == aiChoice)  
            {
                Console.WriteLine("무승부입니다.");
            } 
            else if (choice == 0 && aiChoice == 2) 
            {
                Console.WriteLine("승리입니다.");
            }
            else if (choice == 1 && aiChoice == 0)
            {
                Console.WriteLine("승리입니다.");
            }
            else if (choice == 2 && aiChoice == 1)
            {
                Console.WriteLine("승리입니다.");
            }
            else
            {
                Console.WriteLine("패배입니다.");
            }
        }
    }
}
