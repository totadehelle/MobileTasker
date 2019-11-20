using System.Collections.ObjectModel;
using System.Windows.Input;
using MobileTasker.Entities;

namespace MobileTasker.Core
{
    public interface IPresenter
    {
        ObservableCollection<TaskItem> Tasks { get; set; }
        ICommand AddCommand { get; }
        ICommand DeleteCommand { get; }
    }
}