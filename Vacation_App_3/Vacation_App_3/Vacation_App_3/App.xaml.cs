using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Vacation_App_3.Features;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Vacation_App_3
{
    public partial class App : Application
    {
        private static TodoDBAsyncWrapper db;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());

        }
        public static TodoDBAsyncWrapper DataBase
        {
            get
            {
                if (db == null)
                {
                    db = new TodoDBAsyncWrapper();
                }
                return db;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }       

}
