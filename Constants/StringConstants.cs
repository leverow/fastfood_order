namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    public static Dictionary<string, string> LanguageNames => new()
    {
        { "uz-Uz", "O'zbekcha 🇺🇿" },
        { "ru-Ru", "Pусский 🇷🇺" },
        { "en-Us", "English 🇺🇸" },
    };

    public static Dictionary<string, string> MainMenu => new()
    {
        { "buyurtma", "Buyurtma berish" },
        { "sozlama", "Sozlamalar" },
        { "haqimizda", "Biz haqimizda" },
    };

    public static Dictionary<string, string> DisplayReadyFood => new()
    {
        { "davom-etish", "Haridni davom etish" },
        { "zakaz-berish", "Zakaz berish" },
    };

    public static Dictionary<string, string> DisplayTakeFood => new()
    {
        { "location", "Locatsiya jo'natish" },
    };
    public static string[] ContinueButton => new string[]
    {
        "Davom etish"
    };
}