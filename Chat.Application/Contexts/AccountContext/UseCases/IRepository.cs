using Chat.Domain.Contexts.AccountContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Contexts.AccountContext.UseCases
{
    public interface IRepository
    {
        #region Create
        Task<bool> AnyAsync(string email, CancellationToken cancellationToken);
        Task SaveAsync(User user, CancellationToken cancellationToken);
        #endregion

        #region Auth
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        #endregion
    }
}
