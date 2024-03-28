using Chat.Application.Contexts.SharedContext.UseCases;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Contexts.AccountContext.UseCases.Create
{
    public class CreateAccountResponse : SharedContext.UseCases.Response
    {
        public CreateAccountResponse(string message, ResponseData data)
        {
            Message = message;
            Status = 201;
            Notifications = null;
            Data = data;
        }

        public CreateAccountResponse(string message, int status, IEnumerable<Notification>? notifications = null)
        {
            Message = message;
            Status = status;
            Notifications = notifications;
        }

        public ResponseData? Data { get; set; }
    }
    
    public record ResponseData(Guid Id);
}
