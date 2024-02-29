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
    [Activity(Label = "Board")]
    public class Board : Activity
    {
        Button goBackBtn, addBtn, clearBtn;
        EditText editTxt;
        LinearLayout centerLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.board);
            Init();
            goBackBtn.Click += GoBackBtn_Click;
            addBtn.Click += AddBtn_Click;
            clearBtn.Click += ClearBtn_Click;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            centerLayout.RemoveAllViews();
            editTxt.Text = "";
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            int btnsToAdd;
            if (editTxt.Text == "")
            {
                btnsToAdd = 0;
            }
            else
            {
                btnsToAdd = int.Parse(editTxt.Text);
            }
            for (int i = 0; i < btnsToAdd; i++)
            {
                var btn = new Button(this)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
                    { Weight = 1 },
                    Id = i + 1
                };
                btn.Click += Btn_Click;
                centerLayout.AddView(btn);
            }

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int buttonId = clickedButton.Id;
            Toast.MakeText(Application.Context, buttonId.ToString(), ToastLength.Short).Show();
        }

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            Finish();
        }

        void Init()
        {
            goBackBtn = FindViewById<Button>(Resource.Id.goBackBtn);
            addBtn = FindViewById<Button>(Resource.Id.addBtn);
            clearBtn = FindViewById<Button>(Resource.Id.clearBtn);
            editTxt = FindViewById<EditText>(Resource.Id.chooseNum);
            centerLayout = FindViewById<LinearLayout>(Resource.Id.centerLayout);
        }
    }
}