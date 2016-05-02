using System;

namespace WelcomeToTheFruitBowl
{
    public class Player
    {
        public enum RaceType
        {
            Dwarf,
            Elf,
            Human
        }

        private readonly RaceType Race;

        private Stats stats;

        public Player(string name, RaceType race)
        {
            Name = name;
            Race = race;

            switch (Race)
            {
                case RaceType.Dwarf:
                    stats = new Stats(25, 1, 1, 0, 0);
                    break;
                case RaceType.Elf:
                    stats = new Stats(15, 10, 0, 1, 0);
                    break;
                case RaceType.Human:
                    stats = new Stats(20, 5, 0, 0, 1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public string Name { get; set; }
    }
}