namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    public Dictionary<string, string> LanguageNames => new()
    {
        { "uz-Uz", _localizer["uzbek"] },
        { "en-Us", _localizer["english"] },
        { "ru-Ru", _localizer["russia"] },
    };

    public string[] IsTrueLocation => new string[]
    {
        _localizer["true"],
        _localizer["false"]
    };
    public const int AmericanoHotdogPrice = 16000;
    public const int DoubleHotdogPrice = 16000;
    public const int FranchHotdogPrice = 16000;
    public const int MeatHotdogPrice = 14000;
    public const int ClassicHotdogPrice = 12000;
    
    
}