using Telegram.Bot;
using Telegram.Bot.Types;

namespace fastfood_order.Services;

public partial class BotUpdateHandler
{
    private async Task HandleCallBackQueryAsync(ITelegramBotClient botClient, CallbackQuery? query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        var from = query.From;
        
        _logger.LogInformation("Received CallbackQuery from {from.Firstname}: {query.Data}", from?.FirstName, query.Data);

        if(query.Data.Contains("ayirish"))
        {
            await botClient.DeleteMessageAsync(
                chatId: query.Message.Chat.Id,
                messageId: query.Message.MessageId,
                cancellationToken: cancellationToken
            );
            if(query.Data == "ayirish_1")
            {
                await _userService.RemoveHotDogAsync(query.From.Id, americano_hot_dog: 1);
                await FoodCount(botClient,query.Message, cancellationToken, 1);
            };
            if(query.Data == "ayirish_2")
            {
                await _userService.RemoveHotDogAsync(query.From.Id, double_hot_dog: 1);
                await FoodCount(botClient,query.Message, cancellationToken, 2);
            }
            if(query.Data == "ayirish_3")
            {
                await _userService.RemoveHotDogAsync(query.From.Id, franch_hot_dog: 1);
                await FoodCount(botClient,query.Message, cancellationToken, 3);
            }
            if(query.Data == "ayirish_4")
            {
                await _userService.RemoveHotDogAsync(query.From.Id, meat_hot_dog: 1);
                await FoodCount(botClient,query.Message, cancellationToken, 4);
            }
            if(query.Data == "ayirish_5")
            {
                await _userService.RemoveHotDogAsync(query.From.Id, classic_hot_dog: 1);
                await FoodCount(botClient,query.Message, cancellationToken, 5);
            }
            
            
        }
        else if(query.Data.Contains("qoshish"))
        {
            if(query.Data == "qoshish_1")
            {
                await _userService.AddHotDogAsync(query.From.Id, americano_hot_dog: 1);
                await FoodCount(botClient,query.Message, cancellationToken, 1);
            }
            if(query.Data == "qoshish_2")
            {
                await _userService.AddHotDogAsync(query.From.Id, double_hot_dog: 1);
                await FoodCount(botClient,query.Message, cancellationToken, 2);
            }
            if(query.Data == "qoshish_3")
            {
                await _userService.AddHotDogAsync(query.From.Id, franch_hot_dog: 1);
                await FoodCount(botClient,query.Message, cancellationToken, 3);
            }
            if(query.Data == "qoshish_4")
            {
                await _userService.AddHotDogAsync(query.From.Id, meat_hot_dog: 1);
                await FoodCount(botClient,query.Message, cancellationToken, 4);
            }
            if(query.Data == "qoshish_5")
            {
                await _userService.AddHotDogAsync(query.From.Id, classic_hot_dog: 1);
                await FoodCount(botClient,query.Message, cancellationToken, 5);
            }

            await botClient.DeleteMessageAsync(
                chatId: query.Message.Chat.Id,
                messageId: query.Message.MessageId,
                cancellationToken: cancellationToken
            );
        }



         if(query.Data == "accept")
         {
            await CheckAndSaveLocation(botClient, query.Message, cancellationToken);
         } 
         else if(query.Data == "discard")
         {
            await SendLocation(botClient, query.Message, cancellationToken);
         }

    }
}