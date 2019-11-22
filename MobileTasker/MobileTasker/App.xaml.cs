using Autofac;
using MobileTasker.Core;
using MobileTasker.DataAccess;
using MobileTasker.Presenters;
using Xamarin.Forms;

namespace MobileTasker
{
    public partial class App : Application
    {
        public IContainer Container { get; set; }
        public const string DBFILENAME = "tasker.db";
        public App()
        {
            InitializeComponent();
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(DBFILENAME);
            var builder = new ContainerBuilder();
            builder.RegisterType<TasksViewModel>().As<IPresenter>().InstancePerDependency();
            builder.RegisterType<TasksModel>().AsSelf().InstancePerDependency();
            builder.Register(c => new TasksRepository(dbPath)).As<IRepository>().InstancePerDependency();
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
