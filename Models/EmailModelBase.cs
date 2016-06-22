using System.Collections.Generic;

namespace ConsoleApplication.Models
{
    public abstract class EmailModelBase : ITranslations
    {
        private Dictionary<string, string> _translations;

        public string this[string key]
        {
            get { return _translations.ContainsKey(key) ? _translations[key] : string.Empty; }
        }

        public void AddTranslations(Dictionary<string, string> translations)
        {
            _translations = translations;
        }

        public ITranslations Translations => this;

        public abstract string Component { get;  }
        public abstract string Css { get;  }
        public string Footer { get; set; }
    }
}