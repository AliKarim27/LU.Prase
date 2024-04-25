using LU.Prase.Debugging;

namespace LU.Prase
{
    public class PraseConsts
    {
        public const string LocalizationSourceName = "Prase";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "1b8db4a60ef44e7a8c2aa15df48d7c50";
    }
}
