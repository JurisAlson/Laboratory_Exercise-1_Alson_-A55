using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System.Timers;
using System;

namespace Laboratory_Exercise__1_Alson__A55
{
    [Activity(Label = "Randdomapp", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Randomizer r;
        TextView text1;
        Button btn, btn2, btnstop;
        ImageView iv;
        Timer timer;
        Random rand;
        int cnt = 0;
        string[] schools = { "UP", "LASALLE", "ATENEO", "MAPUA","MCL" };
        string[] names = { "POGI", "DM", "SEMIPOGI", "WAKOKOK", "ISPRIKITIK" };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.layout1);

            btn = FindViewById<Button>(Resource.Id.button1);
            btn2 = FindViewById<Button>(Resource.Id.button2);
            btnstop = FindViewById<Button>(Resource.Id.button3);
            text1 = FindViewById<TextView>(Resource.Id.textView1);
            iv = FindViewById<ImageView>(Resource.Id.imageView1);
            iv.SetImageResource(Resource.Drawable.MCL);

            btn.Click += delegate
            {
                timer = new Timer();
                timer.Interval = 100;
                timer.Elapsed += timer_Elapsed;
                timer.Start();
            };
            btn2.Click += ClassRandomizer;

            btnstop.Click += Istapo;
        }
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            rand = new Random();
            cnt = rand.Next(schools.Length);
            text1.Text = schools[cnt];
            int resourcesId = (int)typeof(Resource.Drawable).GetField(schools[cnt]).GetValue(null);
            iv.SetImageDrawable(GetDrawable(resourcesId));
            iv.LayoutParameters.Height = 200;
            iv.LayoutParameters.Width = 200;

            throw new NotImplementedException();
        }
        public void Istapo(object sender, EventArgs e)
        {   
                try
                {
                    if (timer != null)
                    {
                        timer.Stop();
                        timer.Dispose();
                    }
                    else if (r != null)
                    {
                    r.Istappo();
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("An error occurred while stopping the timer: " + ex.Message);
                }
        }


        public void ClassRandomizer(object sender, EventArgs e)
        {
            r = new Randomizer(text1, iv, schools);
            r.SetInterval(10);
            r.PlayRandom();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }
    }
}