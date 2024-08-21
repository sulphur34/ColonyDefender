using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

namespace Utils
{
    public class Localisation : MonoBehaviour
    {
        private const string EnglishCode = "en";
        private const string English = "English";
        private const string RussianCode = "ru";
        private const string Russian = "Russian";
        private const string TurkishCode = "tr";
        private const string Turkish = "Turkish";

        private void Awake()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
    ChangeLanguage();
#endif
            LeanLocalization.SetCurrentLanguageAll(English);
        }

        private void ChangeLanguage()
        {
            string languageCode = EnglishCode;

            string language = languageCode switch
            {
                EnglishCode => English,
                RussianCode => Russian,
                TurkishCode => Turkish,
                _ => English
            };

            LeanLocalization.SetCurrentLanguageAll(English);
        }
    }
}