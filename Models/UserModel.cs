using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Models
{
    public interface ITranslations
    {
        string this[string key] { get; }
    }

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

    public class UserModel : EmailModelBase
    {
        public UserModel()
        {
            ProductUrl = "http://example.com";
            ProductDescription = "Expense Management";

            AddTranslations(new Dictionary<string, string>
            {
                {"192", "Please click"},
                {"193", "here"},
                {"194", "to sign in to"},
                {"223", "Welcome to"},
                {"224", "Your company administrator has created a login for you to access"},
                {"225", "Username:"},
                {"386", "Password:"},
                {"387", "Details relating to your password will be sent to you in a separate email."}
            });

            Footer = "This has a footer";
        }

        public string ProductUrl { get; set; }

        public string ProductDescription { get; set; }

        public override string Component => "Component_91";
        public override string Css => "Bmo";
    }
}
