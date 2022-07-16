using fastfood_order.Services;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);

var token = builder.Configuration.GetValue("BotToken", string.Empty);

builder.Services.AddSingleton(new TelegramBotClient(token));
builder.Services.AddHostedService<BotBackgroundService>();

var app = builder.Build();


app.Run();
