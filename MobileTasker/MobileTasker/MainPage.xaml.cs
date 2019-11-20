using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileTasker.Core;
using MobileTasker.Entities;
using MobileTasker.Presenters;
using Plugin.InputKit;
using Plugin.InputKit.Shared.Controls;
using Xamarin.Forms;
using IK = Plugin.InputKit.Shared.Controls;

namespace MobileTasker
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public IPresenter Presenter { get; set; }
        
        public MainPage(IPresenter presenter)
        {
            InitializeComponent();
            Presenter = presenter;
            this.BindingContext = Presenter;
        }


        private void taskList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private void addButton_OnClicked(object sender, EventArgs e)
        {
            Presenter.Tasks.Add(new TaskItem() { Text = "third", IsCompleted = false });
        }
    }
}
