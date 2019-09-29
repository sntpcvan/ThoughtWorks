using System;
using System.Collections.Generic;
using System.Text;
using static ConsoleApp2.GameMachine;

namespace ConsoleApp2
{

    public abstract class Player
    {

        public Player(string _name)
        {
            this.Name = _name;
        }
        public abstract Selection GamePlay();

        public readonly string Name;

        public List<Selection> playerMemory = new List<Selection>(); // opponents memory         
        protected Selection GetOppenentsLastSelection()
        {
            if (playerMemory.Count > 0)
            {
                return playerMemory[(playerMemory.Count) - 1];
            }
            return Selection.FirstSelection;

        }
        protected int GetRandom()
        {
            Random random = new Random();
            int _random = random.Next(0, 2);
            return _random;
        }
    }

    public class KindBot : Player
    {
        public KindBot(string _name) : base(_name)
        {
        }

        public override Selection GamePlay()
        {
            return Selection.COoperate;
        }
    }

    public class HumanPlayer : Player
    {
        public HumanPlayer(string _name) : base(_name)
        {
        }

        public override Selection GamePlay()
        {
            return GetRandom() == 1 ? Selection.COoperate : Selection.Cheat;
        }
    }

    public class EvilBot : Player
    {
        public EvilBot(string _name) : base(_name)
        {
        }

        public override Selection GamePlay()
        {
            return Selection.Cheat;
        }
    }

    public class CopyCatBot : Player
    {
        public CopyCatBot(string _name) : base(_name)
        {
        }

        public override Selection GamePlay()
        {
            if (GetOppenentsLastSelection() == Selection.FirstSelection)
                return Selection.COoperate;

            return this.GetOppenentsLastSelection();
        }
    }

    public class GruderBot : Player
    {
        public GruderBot(string _name) : base(_name)
        {
        }

        private bool startGrudge { get; set; } = false;
        public override Selection GamePlay()
        {
            var oppenentSelection = GetOppenentsLastSelection();

            if (oppenentSelection != Selection.FirstSelection &&
                (oppenentSelection == Selection.Cheat || this.startGrudge))
            {
                this.startGrudge = true;
                return Selection.Cheat;
            }

            return Selection.COoperate;
        }
    }
}
