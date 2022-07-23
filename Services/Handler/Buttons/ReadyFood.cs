using bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    public string[] EndBuy => new string[]
    {
        _localizer["go-shop"],
        _localizer["ended"],
    };
    private async Task ReadyFood(ITelegramBotClient botClient, Message? message, CancellationToken token)
    {
        // int?[] orders = {
        //     0,//Americano
        //     0,//Double
        //     0,//Franch
        //     0,//Meat
        //     0//Classic
        // };
        
        var americano_hotdog = await _userService.GetAmericanoHotdogAsync(message.From.Id);
        var double_hotdog = await _userService.GetDoubleHotdogAsync(message.From.Id);
        var franch_hotdog = await _userService.GetFranchHotdogAsync(message.From.Id);
        var meat_hotdog = await _userService.GetMeatHotdogAsync(message.From.Id);
        var classic_hotdog = await _userService.GetClassicHotdogAsync(message.From.Id);

        var total = 0;
        if(americano_hotdog is not 0) total += americano_hotdog * AmericanoHotdogPrice ?? 0;
        if(double_hotdog is not 0) total += double_hotdog * DoubleHotdogPrice ?? 0;
        if(franch_hotdog is not 0) total += franch_hotdog * FranchHotdogPrice ?? 0;
        if(meat_hotdog is not 0) total += meat_hotdog * MeatHotdogPrice ?? 0;
        if(classic_hotdog is not 0) total += classic_hotdog * ClassicHotdogPrice ?? 0;

        var orders = @$"{_localizer["orders"]}

{(americano_hotdog > 0 ? "🌭 Americano hot-dog " + americano_hotdog + " × "+ AmericanoHotdogPrice +"\n" : null)}{(double_hotdog > 0 ? "🌭 Double hot-dog " + double_hotdog + " × "+ DoubleHotdogPrice +"\n" : null)}{(franch_hotdog > 0 ? "🌭 Franch hot-dog " + franch_hotdog + " × "+ FranchHotdogPrice +"\n" : null)}{(meat_hotdog > 0 ? "🌭 Meat hot-dog " + meat_hotdog + " × "+ MeatHotdogPrice +"\n" : null)}{(classic_hotdog > 0 ? "🌭 Classic hot-dog " + classic_hotdog + " × "+ ClassicHotdogPrice +"\n" : null)}
{_localizer["totalPrice"]} {total:N0} {_localizer["uzs"]}";

        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: orders,
            // replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(DisplayReadyFood, 2),
            parseMode: ParseMode.Html,
            cancellationToken: token
        );

        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: _localizer["endBuy"],
            replyMarkup: MarkupHelpers.GetReplyKeyboardMarkup(EndBuy, 2),
            parseMode: ParseMode.Html,
            cancellationToken: token
        );
    }
}