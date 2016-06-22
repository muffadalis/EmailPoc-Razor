using System;
using System.Collections.Generic;
using ConsoleApplication.Models;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new UserModel();
       
            var templatePaths = new[]
            {
                "EmailTemplates"
            };

            var templateServiceConfiguration = new TemplateServiceConfiguration
            {
                TemplateManager = new MyResolvePathTemplateManager(templatePaths),
                Debug = true,
                Namespaces = new HashSet<string> { "ConsoleApplication.Models", "System" }
            };
            
            var service = RazorEngineService.Create(templateServiceConfiguration);

            var key = service.GetKey("Body.cshtml");
            var body = service.RunCompile(key, typeof(UserModel), model);

            var pm = new PreMailer.Net.PreMailer(body);
            
            var result = pm.MoveCssInline(removeStyleElements: true, stripIdAndClassAttributes: true);

            Console.WriteLine(result.Html);

        }
    }
}