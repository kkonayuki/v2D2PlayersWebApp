using DAL.DataContext;
using DAL.Entities;
using DAL.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Functions.Crud
{
    public class CRUD : ICRUD
    {
        public async Task<T> Create<T>(T objectForDb) where T : class
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    await context.AddAsync<T>(objectForDb);
                    await context.SaveChangesAsync();
                    return objectForDb;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete<T>(int entityId) where T : class
        {

            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    T recordToDelete = await context.FindAsync<T>(entityId);
                    if (recordToDelete != null)
                    {
                        context.Remove(recordToDelete);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> Read<T>(int entityId) where T : class
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    T result = await context.FindAsync<T>(entityId);
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<T>> ReadAll<T>() where T : class
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var result = await context.Set<T>().ToListAsync();
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Player>> ReadPlayersByTeam(int entityId)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var result = await context.Players.Where(p=>p.TeamId == entityId).ToListAsync();
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> Update<T>(T objectToUpdate, int entityId) where T : class
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var objectFound = await context.FindAsync<T>(entityId);
                    if (objectFound != null)
                    {   
                        context.Entry(objectFound).CurrentValues.SetValues(objectToUpdate);
                        await context.SaveChangesAsync();
                    }
                    return objectFound;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
