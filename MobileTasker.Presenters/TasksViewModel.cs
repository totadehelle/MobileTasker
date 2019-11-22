using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MobileTasker.Core;
using MobileTasker.Entities;
using MobileTasker.Presenters.Annotations;
using GalaSoft.MvvmLight.Command;
using System.Linq;


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
        public RelayCommand AddCommand { get; }
        public RelayCommand DeleteCommand { get; }
        
        public TasksViewModel(TasksModel model)
        {
            _model = model;
            var taskList = _model.GetAllTasks().Result;
            var taskCollection = new ObservableCollection<TaskItem>(taskList);
            Tasks = taskCollection;
            AddCommand = new RelayCommand(AddNewTask);
            DeleteCommand = new RelayCommand(DeleteAllCompleted);
        }
        
        public async void DeleteAllCompleted()
        {
            if (Tasks.Count == 0)
                return;
            await _model.DeleteCompleted();
            var tasksToDelete = Tasks.Where(t => t.IsCompleted == true).ToList();
            foreach(var task in tasksToDelete)
            {
                if (task.IsCompleted)
                    Tasks.Remove(task);                        
            }            
        }

        public async void AddNewTask()
        {
            if(string.IsNullOrEmpty(NewTaskText))
                return;
            var newTask = await _model.CreateTask(NewTaskText);
            Tasks.Add(newTask);
            NewTaskText = "";
        }

        public async void ChangeTaskStatus(string textId)
        {
            var isConverted = int.TryParse(textId, out int id);
            var task = Tasks.Where(t => t.Id == id).First();
            var updated = await _model.EditTask(task);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }        
    }
}