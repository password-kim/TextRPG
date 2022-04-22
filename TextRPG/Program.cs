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
        enum MonsterType
        {
            None = 0,
            Slime = 1,
            Orc = 2,
            Skeleton = 3
        }

        struct Player
        {
            public int hp;
            public int attack;
        }

        struct Monster
        {
            public int hp;
            public int attack;
        }

        static ClassType ChooseClass()
        {
            Console.WriteLine("========[직업 선택]========");
            Console.WriteLine("당신의 직업을 선택해주세요.");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");
            Console.WriteLine("===========================");
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
                    Console.WriteLine($"HP : {player.hp}  ATT : {player.attack}");
                    break;
                case ClassType.Archer:
                    player.hp = 75;
                    player.attack = 12;
                    Console.WriteLine($"HP : {player.hp}  ATT : {player.attack}");
                    break;
                case ClassType.Mage:
                    player.hp = 50;
                    player.attack = 15;
                    Console.WriteLine($"HP : {player.hp}  ATT : {player.attack}");
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }

        }
        static void CreateRandomMonster(out Monster monster)
        {
            Random rand = new Random();
            int type = rand.Next(1, 4);

            switch (type)
            {
                case (int)MonsterType.Slime:
                    monster.hp = 10;
                    monster.attack = 1;
                    Console.WriteLine("슬라임이 스폰되었습니다..!");
                    Console.WriteLine($"HP: {monster.hp}  ATT: {monster.attack}");
                    Console.WriteLine("===========================");
                    break;
                case (int)MonsterType.Orc:
                    monster.hp = 30;
                    monster.attack = 5; 
                    Console.WriteLine("오크가 스폰되었습니다..!");
                    Console.WriteLine($"HP: {monster.hp}  ATT: {monster.attack}");
                    Console.WriteLine("===========================");
                    break;
                case (int)MonsterType.Skeleton:
                    monster.hp = 20;
                    monster.attack = 10;
                    Console.WriteLine("스켈레톤이 스폰되었습니다..!");
                    Console.WriteLine($"HP: {monster.hp}  ATT: {monster.attack}");
                    Console.WriteLine("===========================");
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
        }

        static void EnterGame()
        {
            while (true)
            {
                Console.WriteLine("=====[마을 입장]=====");
                Console.WriteLine("마을에 접속했습니다!");
                Console.WriteLine("[1] 필드로 간다.");
                Console.WriteLine("[2] 로비로 돌아가기");
                Console.WriteLine("=====================");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        EnterField();
                        break;
                    case "2":
                        return;
                }
            }
        }

        static void EnterField()
        {
            Console.WriteLine("========[필드 입장]========");
            Console.WriteLine("필드에 입장하였습니다!");

            Monster monster;
            CreateRandomMonster(out monster);

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

                    // 필드입장
                    EnterGame();
                }
            }
        }
    }
}
