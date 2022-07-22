namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    public Dictionary<string, string> LanguageNames => new()
    {
        { "uz-Uz", _localizer["uzbek"] },
        { "en-Us", _localizer["english"] },
        { "ru-Ru", _localizer["russia"] },
    };
}