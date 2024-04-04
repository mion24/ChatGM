using Chat.Application.Contexts.SharedContext.UseCases;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Chat.Application.Contexts.AccountContext.UseCases.Authenticate
{
    public class AuthenticateAccountResponse : Response
    {
        public AuthenticateAccountResponse(string message, ResponseData data)
        {
            Message = message;
            Status = 200;
            Notifications = null;
            Data = data;
        }

        public AuthenticateAccountResponse(string message, int status, IEnumerable<Notification>? notifications = null)
        {
            Message = message;
            Status = status;
            Notifications = notifications;
        }

        public ResponseData? Data { get; set; }
    }

    public class ResponseData
    {
        public string Token { get; set; } = string.Empty;
        public Guid Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string[] Roles { get; set; } = [];
    }
}
