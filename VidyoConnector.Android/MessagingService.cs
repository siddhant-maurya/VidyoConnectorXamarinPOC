using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;

namespace VidyoConnector.Android
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MessagingService : FirebaseMessagingService
    {
        private readonly string NOTIFICATION_CHANNEL_ID = "my_notification_channel";

        public override void OnMessageReceived(RemoteMessage message)
        {
            if (!message.Data.GetEnumerator().MoveNext())
            {
                SendNotification(message.GetNotification().Title, message.GetNotification().Body);
            }
            else
            {
                SendNotification(message.Data);
                Intent intent = new Intent(this.ApplicationContext, typeof(IncomingCall));
                intent.AddFlags(ActivityFlags.NewTask);
                StartActivity(intent);

            }
        }

        private void SendNotification(IDictionary<string, string> data)
        {
            string title, body;
            data.TryGetValue("title", out title);
            data.TryGetValue("body", out body);
            SendNotification(title,  body);
        }

        private void SendNotification(string title, string body)
        {
            NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                NotificationChannel notificationChannel = new NotificationChannel(NOTIFICATION_CHANNEL_ID,"Notification Channel",
                    NotificationImportance.Max);
                notificationChannel.Description = "Description";
                notificationChannel.EnableLights(true);
                notificationChannel.LightColor = Color.Blue;
                notificationChannel.SetVibrationPattern(new long[] {0, 100,500,1000 });

                notificationManager.CreateNotificationChannel(notificationChannel);
            }

            Intent myIntent = new Intent();
            var PI = PendingIntent.GetBroadcast(this, new System.Random().Next(), myIntent, PendingIntentFlags.OneShot);
            NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(this, NOTIFICATION_CHANNEL_ID);
            notificationBuilder.SetAutoCancel(true)
                .SetDefaults(-1)
                .SetWhen(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
                .SetContentTitle(title)
                .SetContentText(body)
                .SetSmallIcon(Resource.Drawable.ic_dialog_close_dark)
                .SetContentInfo("info")
                .AddAction(new NotificationCompat.Action(1, "Reject", PI))
                .AddAction(new NotificationCompat.Action(1, "Answer", PI));

            notificationManager.Notify(new Random().Next(), notificationBuilder.Build());
        }
    }
}