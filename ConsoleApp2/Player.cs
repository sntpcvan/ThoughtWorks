using System;
using System.Collections.Generic;
using System.Text;
using static ConsoleApp2.GameMachine;

namespace ConsoleApp2
{
    public enum PlayerMood { AlwaysCOoperate = 1, AlwaysCheat = 0 }
    public abstract class Player
    {
        public abstract selection GamePlay();

        public selection oppenentSelection { get; private set; }

        public void setOppenentSelection(selection selected, int iteration)
        {
            if (iteration == 1)
            {
                oppenentSelection = selection.COoperate;
                return;
            }
            oppenentSelection = selected;
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

        public override selection GamePlay()
        {
            return selection.COoperate;
        }
    }

    public class HumanPlayer : Player
    {

        public override selection GamePlay()
        {
            return GetRandom() == 1 ? selection.COoperate : selection.Cheat;
        }
    }

    public class EvilBot : Player
    {
        public override selection GamePlay()
        {
            return selection.Cheat;
        }

    }

    public class CopyCatBot : Player
    {
        public override selection GamePlay()
        {
            return oppenentSelection;
        }

    }
}
