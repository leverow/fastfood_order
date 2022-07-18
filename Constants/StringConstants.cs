using Telegram.Bot.Types.ReplyMarkups;

namespace bot.Constants;

public static class StringConstants
{
    public static Dictionary<string, string> LanguageNames => new()
    {
        { "uz-Uz", "O'zbekcha" },
        { "ru-Ru", "Русский" },
        { "en-Us", "English" },
    };
    public static Dictionary<string, string> SettingButtons => new()
    {
        { "til", "Til" },
        { "ortga", "Ortga" },
    };

    public static Dictionary<string, string> FoodNames => new()
    {
        { "classic", "Classic hot dog" },
        { "americano", "Americano hot dog" },
        { "double", "Double hot-dog" },
        { "meat", "Meat hot-dog" },
        { "franch", "Franch hot-dog" },
        { "ichimliklar", "Ichimliklar" },
        { "ortga", "Ortga" },
    }; 


    public static Dictionary<string, string> Drinks => new()
    {
        { "cola", "CocaCola" },
        { "pepsi", "Pepsi" },
        { "juice", "Sharbat" },
        { "davom-tish", "Haridni davom etish" },
        { "ortga", "Ortga" },

    };

    public static Dictionary<string, string> MainMenu => new()
    {
        { "buyurtma", "Buyurtma berish" },
        { "sozlama", "Sozlamalar" },
        { "haqimizda", "Biz haqimizda" },
    };

    public static Dictionary<string, string> FoodChoosed => new()
    {
        { "sosiska", "Sosiska" },
        { "sir", "Sir xoxland" },
        { "indeyka", "Indeyka" },
        { "govyadina", "Govyadina" },
        { "sous", "Baloneziya sous" },
        { "continue", "Davom etish" },
    };

    public static Dictionary<string, string> FoodCount => new()
    {
        { "1", "1" },
        { "2", "2" },
        { "3", "3" },
        { "4", "4" },
        { "5", "5" },
        { "6", "6" },
        { "7", "7" },
        { "8", "8" },
        { "9", "9" },
        { "10", "10" },
    };

    public static Dictionary<string, string> ReadyFood => new()
    {
        { "davom-etish", "Haridni davom etish" },
        { "zakaz-berish", "Zakaz berish" },
    };

    public static Dictionary<string, string> TakeFood => new()
    {
        { "location", "Locatsiya jo'natish" },
    };
}