using System.Collections.Generic;
using System.Threading.Tasks;
using MobileTasker.Entities;

namespace MobileTasker.Core
{
    public interface IRepository
    {
        Task Add(TaskItem task);
        Task<TaskItem> Get(int id);
        Task<IList<TaskItem>> GetAll();
        Task<bool> Update(int id, TaskItem task);
        Task<bool> Delete(int id);
        Task DeleteAllCompleted();
    }
}