namespace WelcomeToTheFruitBowl
{
    public class Stats
    {
        private int currentHealth;
        public int CurrentHealthBonus { get; set; } = 0;
        public int Health
        {
            get { return currentHealth + CurrentHealthBonus; }
            set { currentHealth = value; }
        }

        private int currentMana;
        public int CurrentManaBonus { get; set; } = 0;
        public int Mana
        {
            get { return currentMana + CurrentManaBonus; }
            set { currentMana = value; }
        }

        private int currentStrength;
        public int CurrentStrengthBonus { get; set; } = 0;
        public int Strength
        {
            get { return currentStrength + CurrentStrengthBonus; }
            set { currentStrength = value; }
        }

        private int currentSpeed;
        public int CurrentSpeedBonus { get; set; } = 0;
        public int Speed
        {
            get { return currentSpeed + CurrentSpeedBonus; }
            set { currentSpeed = value; }
        }

        private int currentIntelligence;
        public int CurrentIntelligenceBonus { get; set; } = 0;
        public int Intelligence
        {
            get { return currentIntelligence + CurrentIntelligenceBonus; }
            set { currentIntelligence = value; }
        }

        public Stats(int health, int mana, int strength, int speed, int intelligence)
        {
            currentHealth = health;
            currentMana = mana;
            currentStrength = strength;
            currentSpeed = speed;
            currentIntelligence = intelligence;
        }
    }
}
