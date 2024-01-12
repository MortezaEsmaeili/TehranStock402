// See https://aka.ms/new-console-template for more information
using MSHB.TsetmcReader.Service.Helper;

Console.WriteLine("Hello, World!");
TelegramHelper telegramHelper = new TelegramHelper();

await telegramHelper.sendMessage("سلام این اولین پیام بات است");
