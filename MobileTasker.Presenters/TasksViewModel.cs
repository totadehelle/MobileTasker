using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MobileTasker.Core;
using MobileTasker.Entities;
using MobileTasker.Presenters.Annotations;

namespace MobileTasker.Presenters
{
    public class TasksViewModel : IPresenter, INotifyPropertyChanged
    {
        public ObservableCollection<TaskItem> Tasks { get; set; }
        private readonly TasksModel _model;
        private string _newTaskText;

        public string NewTaskText
        {
            get => _newTaskText;
            set
            {
                _newTaskText = value;
                OnPropertyChanged("NewTaskText");
            }
        }

        public ICommand AddCommand => new CommandHandler(AddNewTask);
        public ICommand DeleteCommand => new CommandHandler(DeleteAllCompleted);
        public ICommand ChangeStatusCommand => new CommandHandler(ChangeTaskStatus);

        public TasksViewModel(TasksModel model)
        {
            _model = model;
            Tasks = new ObservableCollection<TaskItem>()
            {
                new TaskItem(){ Text = "first", IsCompleted = false},
                new TaskItem(){ Text = "second", IsCompleted = true},
            };
        }
        
        public async void DeleteAllCompleted()
        {
            await _model.DeleteCompleted();
            var taskList = await _model.GetAllTasks();
            var taskCollection = new ObservableCollection<TaskItem>(taskList);
            Tasks = taskCollection;
        }

        //TODO: непонятно как получить сюда конкретный таск, который изменился!
        public async void ChangeTaskStatus()
        {
            throw new System.NotImplementedException();
        }

        public async void AddNewTask()
        {
            if(string.IsNullOrEmpty(NewTaskText))
                return;
            await _model.CreateTask(NewTaskText);
            NewTaskText = "";
            var taskList = await _model.GetAllTasks();
            var taskCollection = new ObservableCollection<TaskItem>(taskList);
            Tasks = taskCollection;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}