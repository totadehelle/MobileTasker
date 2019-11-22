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

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Xamarin.Forms.CheckBox ch = (Xamarin.Forms.CheckBox)sender;
            var id = ch.ClassId;
            //CheckedChanged event is fired also when the checkbox is removed, and ClassId is null then, so we need this null-check
            if (id == null)
                return;
            Presenter.ChangeTaskStatus(id);
        }
    }
}
