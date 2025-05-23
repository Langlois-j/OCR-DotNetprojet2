﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Provides services method to manage the application language
    /// </summary>
    public class LanguageService : ILanguageService
    {
        /// <summary>
        /// Set the UI language
        /// </summary>
        public void ChangeUiLanguage(HttpContext context, string language)
        {
            string culture = SetCulture(language);
            UpdateCultureCookie(context, culture);
        }

        /// <summary>
        /// Set the culture
        /// </summary>
        public string SetCulture(string language)
        {
            string culture = "";
            // TODO complete the code 
            // Default language is "en", french is "fr" and spanish is "es".
            
            switch (language.ToUpper()) // mise en majsule pour controle plus strict amélioration possible avec fonction complémentaire sans accents et retrait d'éventuel espace en amont ou aval 
            {
                case "FRENCH":
                    culture = "fr";
                    break;
                case "ENGLISH":
                    culture = "en";
                    break;
                case "SPANISH":
                    culture = "es";
                    break;
                default:
                    culture = "en";
                    break;
            }
            return culture;
        }

        /// <summary>
        /// Update the culture cookie
        /// </summary>
        public void UpdateCultureCookie(HttpContext context, string culture)
        {
            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
        }
    }
}
