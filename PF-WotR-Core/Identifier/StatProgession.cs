namespace PF_WotR_Core.Identifier
{
    public class StatProgession: Identifier
    {
        public static readonly StatProgession INSTANCE = new StatProgession();

        private StatProgession() { }

        public const string BAB_FULL            = "b3057560ffff3514299e8b93e7648a9d"; // Base Attack Bonus
        public const string BAB_LOW             = "0538081888b2d8c41893d25d098dee99"; // Base Attack Bonus
        public const string BAB_MEDIUM          = "4c936de4249b61e419a3fb775b9f2581"; // Base Attack Bonus
        public const string SAVES_HIGH          = "ff4662bde9e75f145853417313842751"; // Fortitude, Reflex, Will
        public const string SAVES_LOW           = "dc0c7c1aba755c54f96c089cdf7d14a3"; // Fortitude, Reflex, Will
        public const string SAVES_PRESTIGE_HIGH = "1f309006cd2855e4e91a6c3707f3f700"; // Fortitude, Reflex, Will
        public const string SAVES_PRESTIGE_LOW  = "dc5257e1100ad0d48b8f3b9798421c72"; // Fortitude, Reflex, Will
    }
}
