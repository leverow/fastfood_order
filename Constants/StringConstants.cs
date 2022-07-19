namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    public static Dictionary<string, string> LanguageNames => new()
    {
        { "uz-Uz", "O'zbekcha 🇺🇿" },
        { "ru-Ru", "Pусский 🇷🇺" },
        { "en-Us", "English 🇺🇸" },
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


    public static Dictionary<string, string> DisplayDrinks => new()
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

    public static Dictionary<string, string> FoodsCount => new()
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

    public static Dictionary<string, string> DisplayReadyFood => new()
    {
        { "davom-etish", "Haridni davom etish" },
        { "zakaz-berish", "Zakaz berish" },
    };

    public static Dictionary<string, string> DisplayTakeFood => new()
    {
        { "location", "Locatsiya jo'natish" },
    };
}