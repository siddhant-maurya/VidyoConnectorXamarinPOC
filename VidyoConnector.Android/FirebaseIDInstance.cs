using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Iid;

namespace VidyoConnector.Android
{
    public class FirebaseIDInstance: FirebaseInstanceIdService
    {
        public override void OnTokenRefresh()
        {
            var refreshToken = FirebaseInstanceId.Instance.Token;
            SendTokenToServer(refreshToken);
        }

        private void SendTokenToServer(string refreshToken)
        {
            Log.Debug(PackageName, refreshToken);
        }
    }
}