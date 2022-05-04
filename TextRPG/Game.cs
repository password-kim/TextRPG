using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG
{
    public enum GameMode
    {
        None = 0,
        Lobby = 1,
        Town = 2,
        Field = 3
    }

    class Game
    {
        private GameMode mode = GameMode.Lobby;
        private Player player = null;
        private Monster monster = null;
        private Random rand = new Random();

        public void Process()
        {
            switch (mode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Field:
                    ProcessField();
                    break;
            }
        }

        public void ProcessLobby()
        {
            Console.WriteLine("=====[직업 선택]=====");
            Console.WriteLine("직업을 선택하세요.");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");
            Console.WriteLine("=====================");
            Console.Write(">>");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    player = new Knight();
                    Console.WriteLine($"HP: {player.GetHp()} / ATT: {player.GetAttack()} ");
                    Console.WriteLine("======================");
                    mode = GameMode.Town;
                    break;
                case "2":
                    player = new Archer();
                    Console.WriteLine($"HP: {player.GetHp()} / ATT: {player.GetAttack()} ");
                    Console.WriteLine("======================");
                    mode = GameMode.Town;
                    break;
                case "3":
                    player = new Mage();
                    Console.WriteLine($"HP: {player.GetHp()} / ATT: {player.GetAttack()} ");
                    Console.WriteLine("======================");
                    mode = GameMode.Town;
                    break;
                default:
                    break;
            }
        }

        public void ProcessTown()
        {
            Console.WriteLine("======[마을입장]======");
            Console.WriteLine("마을에 입장했습니다!");
            Console.WriteLine("[1] 필드로 가기");
            Console.WriteLine("[2] 로비로 돌아가기");
            Console.WriteLine("[3] 게임 종료");
            Console.WriteLine("======================");
            Console.Write(">>");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    mode = GameMode.Field;
                    break;
                case "2":
                    mode = GameMode.Lobby;
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
            }
        }

        public void ProcessField()
        {
            Console.WriteLine("==========[필드입장]==========");
            Console.WriteLine("필드에 입장하셨습니다.");

            CreateRandomMonster();
            
            Console.WriteLine("[1] 싸운다");
            Console.WriteLine("[2] 도망간다");
            Console.WriteLine("=============================");
            Console.Write(">>");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ProcessFight();
                    break;
                case "2":
                    TryEscape();
                    break;
            }
        }

        public void CreateRandomMonster()
        {
            int randValue = rand.Next(0, 3);
            switch (randValue)
            {
                case 0:
                    monster = new Slime();
                    Console.WriteLine($"HP: {monster.GetHp()} / ATT: {monster.GetAttack()}");
                    break;
                case 1:
                    monster = new Orc();
                    Console.WriteLine($"HP: {monster.GetHp()} / ATT: {monster.GetAttack()}");
                    break;
                case 2:
                    monster = new Skeleton();
                    Console.WriteLine($"HP: {monster.GetHp()} / ATT: {monster.GetAttack()}");
                    break;
            }
        }

        public void ProcessFight()
        {
            while (true)
            {
                int damage = player.GetAttack();
                monster.OnDamaged(damage);
                if (monster.IsDead())
                {
                    Console.WriteLine("=======[전투 승리]=======");
                    Console.WriteLine("전투에서 승리하셨습니다!!");
                    Console.WriteLine($"남은체력: {player.GetHp()}");
                    Console.WriteLine("========================");
                    mode = GameMode.Town;
                    break;
                }

                damage = monster.GetAttack();
                player.OnDamaged(damage);
                if (player.IsDead())
                {
                    Console.WriteLine("=========[사망]=========");
                    Console.WriteLine("당신은 사망하셨습니다..");
                    Console.WriteLine("========================");
                    mode = GameMode.Lobby;
                    break;
                }
            }
        }

        public void TryEscape()
        {
            int randValue = rand.Next(0, 100);

            if (randValue < 33)
            {
                Console.WriteLine("========[도주 성공]========");
                Console.WriteLine("성공적으로 도망쳤습니다..!");
                Console.WriteLine("==========================");
                mode = GameMode.Town;
            }
            else
            {
                Console.WriteLine("=====[도주 실패]=====");
                Console.WriteLine("도주에 실패하였습니다.");
                Console.WriteLine("전투에 돌입합니다.");
                Console.WriteLine("====================");
                ProcessFight();
            }
        }
    }
}
