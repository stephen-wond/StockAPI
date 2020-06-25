using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace StocksWebAPI.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly ITelegramBotClient _telegramClient;
        private readonly ILogger<UpdateService> _logger;

        public UpdateService(ITelegramBotClient telegramClient, ILogger<UpdateService> logger)
        {
            _telegramClient = telegramClient;
            _logger = logger;
        }

        public async Task EchoAsync(Update update)
        {
            if (update.Type != UpdateType.Message)
                return;

            var message = update.Message;

            _logger.LogInformation("Received Message from {0}", message.Chat.Id);

            switch (message.Type)
            {
                case MessageType.Text:
                    // Echo each Message
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, message.Text);
                    break;

                case MessageType.Photo:
                    // Download Photo
                    var fileId = message.Photo.LastOrDefault()?.FileId;
                    var file = await _telegramClient.GetFileAsync(fileId);

                    var filename = file.FileId + "." + file.FilePath.Split('.').Last();
                    using (var saveImageStream = System.IO.File.Open(filename, FileMode.Create))
                    {
                        await _telegramClient.DownloadFileAsync(file.FilePath, saveImageStream);
                    }

                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, "Thx for the Pics");
                    break;
            }
        }
    }
}