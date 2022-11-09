using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace TopfinAPI.Localization
{
    public static class TopfinAPILocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(TopfinAPIConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(TopfinAPILocalizationConfigurer).GetAssembly(),
                        "TopfinAPI.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
