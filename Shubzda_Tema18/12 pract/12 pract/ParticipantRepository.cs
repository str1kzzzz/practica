using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _12_pract
{
    public class ParticipantRepository : IRepository<ParticipantModel>
    {
        private readonly AppDbContextFactory _factory;

        public ParticipantRepository(AppDbContextFactory factory)
        {
            _factory = factory;
        }

        public async Task<List<ParticipantModel>> GetAllAsync()
        {
            using var context = _factory.CreateDbContext();
            return await context.Participants.ToListAsync();
        }

        public async Task<ParticipantModel> GetAsync(int id)
        {
            using var context = _factory.CreateDbContext();
            return await context.Participants.FindAsync(id);
        }

        public async Task AddAsync(ParticipantModel entity)
        {
            using var context = _factory.CreateDbContext();
            var ev = await context.Events
                .Include(e => e.Participants)
                .FirstOrDefaultAsync(e => e.Id == entity.EventId);

            if (ev == null)
                throw new System.Exception("Event not found");
            ev.Participants.Add(entity);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ParticipantModel entity)
        {
            using var context = _factory.CreateDbContext();
            context.Participants.Remove(entity);
            await context.SaveChangesAsync();
        }

        public Task SaveAsync() => Task.CompletedTask;
    }
}
