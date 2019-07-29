using System;
using Android.App;
using Android.Content.PM;
using Android.Gms.Common;
using Android.Media;
using Android.OS;
using Android.Util;
using Firebase.Iid;
using Firebase.Messaging;

namespace VidyoConnector.Android
{
    [Activity(Label = "VidyoConnector.Android", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        bool isStarted = false;
        internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            isStarted = true;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            

            try
            {
                CreateNotificationChannel();
                LoadApplication(new App(VidyoController.GetInstance()));
            }
            catch (Exception e)
            {
                Logger.GetInstance().Log(e.Message);
            }
            IsPlayServicesAvailable();
            Log.Debug("TOKEN", "INSTANCE ID Token" + FirebaseInstanceId.Instance.Token);

            FirebaseMessaging.Instance.SubscribeToTopic("your_topic_name");
            //CreateNotificationChannel();
        }
        public bool IsPlayServicesAvailable()
        {
            string msg;
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {
                    msg = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                }
                else
                {
                    msg = "device not supported";
                }
                //Finish();
                return false;
            }
            else
            {
                msg = "Google Play Services is available";
                return true;
            }
        }

        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(CHANNEL_ID,
                                                  "FCM Notifications",
                                                  NotificationImportance.Max)
            {

                Description = "Firebase Cloud Messages appear in this channel",
                LightColor = (int)ConsoleColor.Red,
                Importance = NotificationImportance.Max,
                LockscreenVisibility = NotificationVisibility.Public,
            };

            var ringtoneUri = RingtoneManager.GetActualDefaultRingtoneUri(this, RingtoneType.Ringtone);
            channel.SetSound(ringtoneUri, new AudioAttributes.Builder()
                                            .SetFlags(AudioFlags.AudibilityEnforced & AudioFlags.HwAvSync)
                                            .SetUsage(AudioUsageKind.NotificationRingtone)
                                            .SetContentType(AudioContentType.Music)
                                            .SetLegacyStreamType(Stream.Ring)
                                            .Build());

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
    }
}
