namespace ConsoleApplication.Models
{
    public interface ITranslations
    {
        string this[string key] { get; }
    }
}