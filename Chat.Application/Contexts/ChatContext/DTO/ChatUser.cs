using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Contexts.ChatContext.DTO
{
    public record ChatUser(string Name, string EmailAddress, string ConnectionID); 
}
