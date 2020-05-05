using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace IFAvaliacao.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, Immersive = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           SetContentView(Resource.Layout.SplashScreen);
        }

        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }


        async void SimulateStartup()
        {
            await Task.Delay(3000);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}