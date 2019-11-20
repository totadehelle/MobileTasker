using MobileTasker.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileTasker.Entities;
using Microsoft.EntityFrameworkCore;

namespace MobileTasker.DataAccess
{
    public class TasksRepository : IRepository
    {
        private readonly AppContext _context;

        public TasksRepository(AppContext context)
        {
            _context = context;
        }

        public async Task Add(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task<TaskItem> Get(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<IList<TaskItem>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<bool> Update(int id, TaskItem task)
        {
            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return false;
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task DeleteAllCompleted()
        {
            var completed = _context.Tasks.Where(t => t.IsCompleted).Select(t => t);
            foreach (var task in completed)
            {
                _context.Tasks.Remove(task);
            }
            await _context.SaveChangesAsync();
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}