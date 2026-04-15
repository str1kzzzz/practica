using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _12_pract
{
    public class EventRepository : IRepository<EventModel>
    {
        private readonly AppDbContextFactory _factory;

        public EventRepository(AppDbContextFactory factory)
        {
            _factory = factory;
        }

        public async Task<List<EventModel>> GetAllAsync()
        {
            using var context = _factory.CreateDbContext();
            return await context.Events
                .Include(e => e.Participants)
                .ToListAsync();
        }

        public async Task<EventModel> GetAsync(int id)
        {
            using var context = _factory.CreateDbContext();
            return await context.Events
                .Include(e => e.Participants)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(EventModel entity)
        {
            using var context = _factory.CreateDbContext();
            context.Events.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(EventModel entity)
        {
            using var context = _factory.CreateDbContext();
            context.Events.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
        }
    }
}
