namespace WelcomeToTheFruitBowl
{
    public class Stats
    {
        private int currentHealth;

        private int currentIntelligence;

        private int currentMana;

        private int currentSpeed;

        private int currentStrength;

        public Stats(int health, int mana, int strength, int speed, int intelligence)
        {
            currentHealth = health;
            currentMana = mana;
            currentStrength = strength;
            currentSpeed = speed;
            currentIntelligence = intelligence;
        }

        public int CurrentHealthBonus { get; set; } = 0;

        public int Health
        {
            get { return currentHealth + CurrentHealthBonus; }
            set { currentHealth = value; }
        }

        public int CurrentManaBonus { get; set; } = 0;

        public int Mana
        {
            get { return currentMana + CurrentManaBonus; }
            set { currentMana = value; }
        }

        public int CurrentStrengthBonus { get; set; } = 0;

        public int Strength
        {
            get { return currentStrength + CurrentStrengthBonus; }
            set { currentStrength = value; }
        }

        public int CurrentSpeedBonus { get; set; } = 0;

        public int Speed
        {
            get { return currentSpeed + CurrentSpeedBonus; }
            set { currentSpeed = value; }
        }

        public int CurrentIntelligenceBonus { get; set; } = 0;

        public int Intelligence
        {
            get { return currentIntelligence + CurrentIntelligenceBonus; }
            set { currentIntelligence = value; }
        }
    }
}