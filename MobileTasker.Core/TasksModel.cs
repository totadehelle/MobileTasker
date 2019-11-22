using System.Collections.Generic;
using MobileTasker.Entities;
using System.Threading.Tasks;

namespace MobileTasker.Core
{
    public class TasksModel
    {
        private readonly IRepository _repository;

        public TasksModel(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskItem> CreateTask(string text)
        {
            var task = new TaskItem() { Text = text, IsCompleted = false };
            return await _repository.Add(task);
        }

        public async Task DeleteCompleted()
        {
            await _repository.DeleteAllCompleted();
        }

        public async Task<bool> EditTask(TaskItem task)
        {
            return await _repository.Update(task.Id, task);
        }

        public async Task<IList<TaskItem>> GetAllTasks()
        {
            return await _repository.GetAll();
        }
    }
}