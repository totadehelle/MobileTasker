using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MobileTasker.Entities;

namespace MobileTasker.Core
{
    public interface IPresenter
    {
        ObservableCollection<TaskItem> Tasks { get; set; }
        RelayCommand AddCommand { get; }
        RelayCommand DeleteCommand { get; }
        void ChangeTaskStatus(string textId);
    }
}