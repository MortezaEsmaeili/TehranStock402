// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;

Console.WriteLine("Hello, World!");
TelegramBotClient botClient = new TelegramBotClient("6136125871:AAGl0M8eKfGJfpRVYq8j5K3MYJqcsdD7ETo");
var token = new CancellationTokenSource();
var cancelationToken = token.Token;

var ReOpt = new ReceiverOptions { AllowedUpdates = { } };
//await botClient.ReceiveAsync(OnMessage, ErrorMessage, ReOpt, cancelationToken);
await botClient.SendTextMessageAsync("-4151963742", "Hi This is the second bot Message");
return;
async Task ErrorMessage(ITelegramBotClient client, Exception exception, CancellationToken token)
{
    await Console.Out.WriteLineAsync(exception.ToString());
}

async Task OnMessage(ITelegramBotClient client, Update update, CancellationToken token)
{
    if (update.Message is Message message)
    {
       await SendMessageRequest(message);
    }
}

async Task SendMessageRequest(Message message)
{
    //"-4151963742"
    await botClient.SendTextMessageAsync(message.Chat.Id, "Hi This is the first bot Message");
}