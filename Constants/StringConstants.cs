namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    public Dictionary<string, string> LanguageNames => new()
    {
        { "uz-Uz", "O'zbekcha 🇺🇿" },
        { "en-Us", "English 🇺🇸" },
        { "ru-Ru", "Pусский 🇷🇺" },
    };
}