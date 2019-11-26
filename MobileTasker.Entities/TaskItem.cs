using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MobileTasker.Entities.Annotations;

namespace MobileTasker.Entities
{
    public class TaskItem : INotifyPropertyChanged
    {
        private bool _isCompleted;
        public int Id { get; set; }
        public string Text { get; set; }

        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                _isCompleted = value;
                OnPropertyChanged("IsCompleted");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
