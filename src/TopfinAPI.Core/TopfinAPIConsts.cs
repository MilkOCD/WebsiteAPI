using TopfinAPI.Debugging;

namespace TopfinAPI
{
    public class TopfinAPIConsts
    {
        public const string LocalizationSourceName = "TopfinAPI";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "6679d06e1a854c2a8b2df9c584e05048";
    }
}
