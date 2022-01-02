using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using System.Collections.Generic;

/////////////////
/// Created 27/09/2021
////////////////

namespace Telega.Bot
{
    class Program
    {
        private static string token { get; set; } = "private info";
        private static TelegramBotClient client;

        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);

            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {

            var msg = e.Message;
            if (msg.Text != null)
            {

                switch (msg.Text)
                {
                    case "Шо по ценам?":
                        var stic = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://cdn.tlgrm.ru/stickers/e70/e20/e70e20e6-c2c7-3390-926d-16c170c351ee/192/10.webp",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButton());
                        break;

                    case "Love you":
                        var stic1 = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://tlgrm.ru/_/stickers/e70/e20/e70e20e6-c2c7-3390-926d-16c170c351ee/192/14.webp",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButton());
                        break;
                    case "Олень":
                        var picture2 = await client.SendPhotoAsync(
                            chatId: msg.Chat.Id,
                             photo: "https://iso.500px.com/wp-content/uploads/2016/03/stock-photo-142984111.jpg",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButton());
                        break;

                    case "ТЕМК Двійка":
                        var stic3 = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://tlgrm.ru/_/stickers/e70/e20/e70e20e6-c2c7-3390-926d-16c170c351ee/192/45.webp",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButton());
                        break;

                    case "Добрінька!":
                        var stic4 = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://cdn.tlgrm.ru/stickers/762/b01/762b01fe-9437-3f82-9ddf-3d33a3ece0e0/192/7.webp",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButton());
                        break;

                    case "Привіт":
                        var picture5 = await client.SendPhotoAsync(
                            chatId: msg.Chat.Id,
                            photo: "https://truesharing.ru/wp-content/uploads/2019/05/hello-logo-min.jpg",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButton());
                        break;

                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "Select a command:", replyMarkup: GetButton());
                        break;

                }
            }
        }
        private static IReplyMarkup GetButton()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                    {
                       new List<KeyboardButton>{ new KeyboardButton {Text = "Шо по ценам?" }, new KeyboardButton { Text = "Love you" } },
                       new List<KeyboardButton>{ new KeyboardButton {Text = "Олень" }, new KeyboardButton { Text = "ТЕМК Двійка" } },
                       new List<KeyboardButton>{ new KeyboardButton {Text = "Добрінька!" }, new KeyboardButton { Text = "Привіт" } }
                   }
            };
        }

    }
}
