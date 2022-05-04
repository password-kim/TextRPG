using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG
{
    public enum PlayerType
    {
        None = 0,
        Knight = 1,
        Archer = 2,
        Mage = 3
    }

    class Player : Creature
    {
        protected PlayerType _type = PlayerType.None;

        protected Player(PlayerType type) : base(CreatureType.Player)
        {
            _type = type;
        }

        public PlayerType GetPlayerType() { return _type; }
        
    }

    class Knight : Player
    {
        public Knight() : base(PlayerType.Knight)
        {
            SetInfo(100, 10);
            Console.WriteLine("========[기사]========");
            Console.WriteLine("기사를 선택하셨습니다!");
        }
    }

    class Archer : Player
    {
        public Archer() : base(PlayerType.Archer)
        {
            SetInfo(75, 12);
            Console.WriteLine("========[궁수]========");
            Console.WriteLine("궁수를 선택하셨습니다!");
        }
    }

    class Mage : Player
    {
        public Mage() : base(PlayerType.Mage)
        {
            SetInfo(60, 15);
            Console.WriteLine("========[마법사]========");
            Console.WriteLine("마법사를 선택하셨습니다!");
        }
    }
}
