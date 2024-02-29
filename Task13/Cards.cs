using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task13
{
    [Activity(Label = "Cards")]
    public class Cards : Activity
    {
        Button closeBtn, showBtn, clsBtn;
        EditText editTxt;
        LinearLayout main;
        Random rnd = new Random();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.cards);

            Init();
            closeBtn.Click += CloseBtn_Click;
            showBtn.Click += ShowBtn_Click;
            clsBtn.Click += ClsBtn_Click;
        }

        private void ClsBtn_Click(object sender, EventArgs e)
        {
            main.RemoveAllViews();
        }

        private void ShowBtn_Click(object sender, EventArgs e)
        {
            main.RemoveAllViews();
            int imgToShow = int.Parse(editTxt.Text);
            char[] types = { 's', 'c', 'h', 'd' };
            LinearLayout layout = new LinearLayout(this);
            for (int i = 0; i <= imgToShow; i++)
            {
                if (i % 5 == 0)
                {
                    if (i > 0)
                    {
                        var img = new ImageView(this);
                        img.SetImageResource(Resources.GetIdentifier($"img{rnd.Next(1, 14)}{types[rnd.Next(4)]}", "drawable", this.PackageName));
                        img.LayoutParameters = new LinearLayout.LayoutParams(0, 200, 1);
                        layout.AddView(img);
                    }
                        main.AddView(layout);
                        layout = new LinearLayout(this);
                        continue;
                    }
                    //add image
                    var imgv = new ImageView(this);
                    imgv.SetImageResource(Resources.GetIdentifier($"img{rnd.Next(1, 14)}{types[rnd.Next(4)]}", "drawable", this.PackageName));
                    imgv.LayoutParameters = new LinearLayout.LayoutParams(0, 200, 1);
                    layout.AddView(imgv);
                }

                main.AddView(layout);

            }

            private void CloseBtn_Click(object sender, EventArgs e)
            {
                Finish();
            }

            void Init()
            {
                main = FindViewById<LinearLayout>(Resource.Id.mainLayout);
                closeBtn = FindViewById<Button>(Resource.Id.close);
                showBtn = FindViewById<Button>(Resource.Id.show);
                clsBtn = FindViewById<Button>(Resource.Id.cls);
                editTxt = FindViewById<EditText>(Resource.Id.editTxt);
            }
        }
    }