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

        struct Player
        {
            public int hp;
            public int attack;
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

        static void CreatePlayer(ClassType choice , out Player player)
        {
            switch (choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Archer:
                    player.hp = 75;
                    player.attack = 12;
                    break;
                case ClassType.Mage:
                    player.hp = 50;
                    player.attack = 15;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }

        }

        static void Main(string[] args)
        {
            while (true)
            {
                ClassType choice = ChooseClass();
                if(choice != ClassType.None)
                {
                    // 캐릭터 생성
                    Player player;

                    CreatePlayer(choice, out player);

                    Console.WriteLine($"HP : {player.hp}  ATT : {player.attack}");

                    // 필드입장
                }
            }
        }
    }
}
