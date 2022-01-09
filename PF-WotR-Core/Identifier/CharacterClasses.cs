namespace PF_WotR_Core.Identifier
{
    public class CharacterClasses : Identifier
    {
        public static readonly CharacterClasses INSTANCE = new CharacterClasses();

        private CharacterClasses() { }

        public const string ALCHEMIST  = "0937bec61c0dabc468428f496580c721";
        public const string ARCANIST   = "52dbfd8505e22f84fad8d702611f60b7";
        public const string BARBARIAN  = "f7d7eb166b3dd594fb330d085df41853";
        public const string BARD       = "772c83a25e2268e448e841dcd548235f";
        public const string CLERIC     = "67819271767a9dd4fbfd4ae700befea0";
        public const string DRUID      = "610d836f3a3a9ed42a4349b62f002e96";
        public const string FIGHTER    = "48ac8db94d5de7645906c7d0ad3bcfbd";
        public const string INQUISITOR = "f1a70d9e1b0b41e49874e1fa9052a1ce";
        public const string KINETICIST = "42a455d9ec1ad924d889272429eb8391";
        public const string MAGUS      = "45a4607686d96a1498891b3286121780";
        public const string MONK       = "e8f21e5b58e0569468e420ebea456124";
        public const string PALADIN    = "bfa11238e7ae3544bbeb4d0b92e897ec";
        public const string RANGER     = "cda0615668a6df14eb36ba19ee881af6";
        public const string ROGUE      = "299aa766dee3cbf4790da4efb8c72484";
        public const string SLAYER     = "c75e0971973957d4dbad24bc7957e4fb";
        public const string SORCERER   = "b3a505fb61437dc4097f43c3f8f9a4cf";
        public const string WITCH      = "1b9873f1e7bfe5449bc84d03e9c8e3cc";
        public const string WIZARD     = "ba34257984f4c41408ce1dc2004e342e";
    }
}
