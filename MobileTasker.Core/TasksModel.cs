﻿using MobileTasker.Entities;
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

        public async Task CreateTask(string text)
        {
            var task = new TaskItem() { Text = text, IsCompleted = false };
            await _repository.Add(task);
        }

        public async Task<bool> DoTask(TaskItem task)
        {
            task.IsCompleted = true;
            return await _repository.Update(task.Id, task);
        }
        public async Task<bool> UndoTask(TaskItem task)
        {
            task.IsCompleted = false;
            return await _repository.Update(task.Id, task);
        }


        public async Task<bool> EditTask(TaskItem task)
        {
            return await _repository.Update(task.Id, task);
        }
    }
}