using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Vacation_App_3.Droid
{
   [Activity(Label = "오성도우미", Icon = "@mipmap/icon", Theme = "@style/MainTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
        }
        protected override void OnResume()
        {
            base.OnResume();
            Task startUP = new Task(() => { SimulateStartUp();  });
            startUP.Start();
        }

        async void SimulateStartUp()
        {
            await Task.Delay(10);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            Finish();
            OverridePendingTransition(0, 0);
        }
    }
}