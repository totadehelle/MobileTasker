using System;
using Autofac;
using MobileTasker.Core;
using MobileTasker.DataAccess;
using MobileTasker.Presenters;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTasker
{
    public partial class App : Application
    {
        public IContainer Container { get; set; }
        
        public App()
        {
            InitializeComponent();
            var builder = new ContainerBuilder();
            builder.RegisterType<TasksViewModel>().As<IPresenter>().InstancePerDependency();
            builder.RegisterType<TasksModel>().AsSelf().InstancePerDependency();
            //builder.RegisterType<TasksRepository>().As<IRepository>().InstancePerDependency();
            Container = builder.Build();
            MainPage = new NavigationPage(new MainPage(Container.Resolve<IPresenter>()));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
