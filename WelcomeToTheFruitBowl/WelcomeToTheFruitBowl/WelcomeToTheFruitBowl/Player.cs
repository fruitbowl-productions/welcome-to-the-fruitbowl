using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;

namespace WelcomeToTheFruitBowl
{
    public class Player
    {
        public string Name;

        public string Race;

        private Stats stats;

        public Player(string race, string name)
        {
            Name = name;
            Race = race;
            if (Race == "Human")
            {
                stats = new Stats(20,5,0,0,1);
            }
            else if (Race == "Elf")
            {
                stats = new Stats(15, 10, 0, 1, 0);
            }
            else if (Race == "Dwarf")
            {
                stats = new Stats(25, 1, 1, 0, 0);
            }
            else
            {
                throw new NotImplementedException();  
            }
        }
    }
}
