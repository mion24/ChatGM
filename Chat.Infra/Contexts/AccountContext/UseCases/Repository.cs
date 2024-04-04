using Chat.Application.Contexts.AccountContext.UseCases;
using Chat.Domain.Contexts.AccountContext.Entities;
using Chat.Infra.Contexts.Data;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infra.Contexts.AccountContext.UseCases
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AnyAsync(string email, CancellationToken cancellationToken)
            => await _context.Users.AsNoTracking().AnyAsync(x => x.EmailAddress == email, cancellationToken);

        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.EmailAddress == email, cancellationToken);
        }

        public async Task SaveAsync(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
