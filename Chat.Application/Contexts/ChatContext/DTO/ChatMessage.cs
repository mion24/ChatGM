using Chat.Application.Contexts.SharedContext.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Contexts.ChatContext.DTO
{
    public class ChatMessage(string Message, DateTime Date, ChatUser Sender)
    {
        public string Message { get; } = $"{Sender.Name} - {Date} {Message}";
        public DateTime Date { get; } = Date;
        public ChatUser Sender { get; } = Sender;
    }
}
