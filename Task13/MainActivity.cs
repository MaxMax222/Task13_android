using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
namespace Task13
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button changesBtn, nextBtn, exitBtn, imgBtn;
        TextView txt;
        EditText editTxt;
        LinearLayout center;
        Random rnd;
        string abc;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Init();
            changesBtn.Click += ChangesBtn_Click;
            nextBtn.Click += NextBtn_Click;
            exitBtn.Click += ExitBtn_Click;
            imgBtn.Click += ImgBtn_Click;
        }

        private void ImgBtn_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Cards));
        }

        private void ExitBtn_Click(object sender, System.EventArgs e)
        {
            Finish();
        }

        private void NextBtn_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Board));
        }

        private void ChangesBtn_Click(object sender, System.EventArgs e)
        {
            ChangeTxt(rnd.Next(31));
            ChangeEdit(rnd.Next(31));
            ChangeLayout();
        }

        private void ChangeLayout()
        {
            LinearLayout.LayoutParams p = new LinearLayout.LayoutParams(rnd.Next(50,400), rnd.Next(50,400));
            center.LayoutParameters = p;
            center.SetBackgroundColor(new Color(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
        }

        private void ChangeEdit(int len)
        {
            string msg = "";
            for (int i = 0; i < len; i++)
            {
                msg += abc[rnd.Next(abc.Length)];
            }

            editTxt.Text = msg;
            editTxt.SetBackgroundColor(new Color(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            int width = rnd.Next(50,300);
            int height = rnd.Next(50,300);
            LinearLayout.LayoutParams p = new LinearLayout.LayoutParams(width, height);
            editTxt.LayoutParameters = p;
        }

        private void ChangeTxt(int len)
        {
            string msg = "";
            for (int i = 0; i < len; i++)
            {
                msg += abc[rnd.Next(abc.Length)];
            }

            txt.Text = msg;
            txt.SetBackgroundColor(new Color(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            int width = rnd.Next(50,300);
            int height = rnd.Next(50,300);
            LinearLayout.LayoutParams p = new LinearLayout.LayoutParams(width, height);
            txt.LayoutParameters = p;
        }

        void Init()
        {
            changesBtn = FindViewById<Button>(Resource.Id.changesBtn);
            nextBtn = FindViewById<Button>(Resource.Id.nextBtn);
            exitBtn = FindViewById<Button>(Resource.Id.exitBtn);
            imgBtn = FindViewById<Button>(Resource.Id.imagesScreen);
            txt = FindViewById<TextView>(Resource.Id.txt);
            editTxt = FindViewById<EditText>(Resource.Id.editTxt);
            center = FindViewById<LinearLayout>(Resource.Id.centerLayout);
            rnd = new Random();
            abc = "qwertyuiopasdfghjklzxcvbnm1234567890-=`,./;'[]~!@#$%^&*()_+QWERTYUIOP{}|ASDFGHJKL:ZXCVBNM<>?";
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}