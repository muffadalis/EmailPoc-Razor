using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Models
{
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
