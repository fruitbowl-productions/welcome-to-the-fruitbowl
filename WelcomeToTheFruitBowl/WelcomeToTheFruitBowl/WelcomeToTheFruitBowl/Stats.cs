using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WelcomeToTheFruitBowl
{
    class Stats
    {
        public int Health;
        public int CurrentHealth;
        public int Mana;
        public int CurrentMana;
        private int strength;
        private int currentStrengthBonus;

        public int Strength
        {
            get { return strength + currentStrengthBonus; }
            set { strength = value; }
        }

        private int speed;
        private int currentSpeedBonus;

        public int Speed
        {
            get { return speed + currentSpeedBonus; }
            set { speed = value; }
        }

        private int intelligence;
        private int currentIntelligenceBonus;

        public int Intelligence
        {
            get { return intelligence + currentIntelligenceBonus; }
            set { intelligence = value; }
        }



        public Stats(int hp, int ma, int str, int spd, int ite)
        {
            Health = hp;
            CurrentHealth = hp;
            Mana = ma;
            CurrentMana = ma;
            Strength = str;
            currentStrengthBonus = 0;
            Speed = spd;
            currentSpeedBonus = 0;
            Intelligence = ite;
            currentIntelligenceBonus = 0;
        }
    }
}
