using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System.Timers;
using System;
using Android.Util;
using Android.Graphics.Drawables;

namespace Laboratory_Exercise__1_Alson__A55
{
    internal class Randomizer
    {
        private int speed;
        private Timer timer;
        private Random rand;
        private int cnt;
        private string[] arr;
        private ImageView iv;
        private TextView tv;


        public Randomizer(TextView tv_main, ImageView iv_main, string[] arr_main)
        {

            tv = tv_main;
            iv = iv_main;
            arr = arr_main;


        }

        public void SetInterval(int n)
        {
            speed = n;
        }

        public void PlayRandom()
        {
            timer = new Timer();
            timer.Interval = speed;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            rand = new Random();
            cnt = rand.Next(arr.Length);
            cnt %= arr.Length;
            tv.Text = arr[cnt];

            int resourcesId = (int)typeof(Resource.Drawable).GetField(arr[cnt]).GetValue(null);
            iv.SetImageDrawable(iv.Context.GetDrawable(resourcesId));
            iv.LayoutParameters.Height = 200;
            iv.LayoutParameters.Width = 200;

            throw new NotImplementedException();

        }

        public void Istappo()
        {
            try
            {
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while stopping the timer: " + ex.Message);

            }

        }
    }
}
