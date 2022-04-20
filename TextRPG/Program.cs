using System;

namespace TextRPG
{
    class Program
    {
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }

        static ClassType ChooseClass()
        {
            Console.WriteLine("당신의 직업을 선택해주세요.");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");
            Console.Write(">>");

            string input = Console.ReadLine();

            ClassType choice = ClassType.None;

            switch (input)
            {
                case "1":
                    choice = ClassType.Knight;
                    Console.WriteLine("당신은 기사를 선택하였습니다.");
                    break;
                case "2":
                    choice = ClassType.Archer;
                    Console.WriteLine("당신은 궁수를 선택하였습니다.");
                    break;
                case "3":
                    choice = ClassType.Mage;
                    Console.WriteLine("당신은 마법사를 선택하였습니다.");
                    break;
            }

            return choice;
        }
        static void Main(string[] args)
        {
            ClassType choice = ClassType.None;

            while (choice == ClassType.None)
            {
                choice = ChooseClass();
            }
        }
    }
}
