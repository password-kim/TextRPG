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
            Console.WriteLine("[2] 궁사");
            Console.WriteLine("[3] 마법사");
            Console.WriteLine("=====================");
            Console.Write(">>");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    player = new Knight();
                    mode = GameMode.Town;
                    break;
                case "2":
                    player = new Archer();
                    mode = GameMode.Town;
                    break;
                case "3":
                    player = new Mage();
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
            }
        }

        public void ProcessField()
        {

        }
    }
}
