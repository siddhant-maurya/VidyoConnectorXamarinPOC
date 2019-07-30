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
                OnShowIncomingCallUi(message.GetNotification().Title, message.GetNotification().Body);
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
            OnShowIncomingCallUi(title, body);
        }

        
        private PendingIntent GetIncomingCallIntent(string callId)
        {

            Intent intent = new Intent(this.ApplicationContext, typeof(IncomingCall));
            intent.AddFlags(ActivityFlags.NewTask);
            intent.PutExtra("ConnectionGuid", callId);
            return PendingIntent.GetBroadcast(this, new System.Random().Next(), intent, PendingIntentFlags.OneShot);
        }

        private void OnShowIncomingCallUi(string callId, string callerDisplayName)
        {
            var incomingCallIntent = GetIncomingCallIntent(callId);

            Intent myIntent = new Intent();
            var PI = PendingIntent.GetBroadcast(this, new System.Random().Next(), myIntent, PendingIntentFlags.OneShot);
                
            // Build the notification as an ongoing high priority item; this ensures it will show as
            // a heads up notification which slides down over top of the current content.
            var builder = new NotificationCompat.Builder(this, NOTIFICATION_CHANNEL_ID);
            builder.SetOngoing(true);
            builder.SetOnlyAlertOnce(false);
            builder.SetPriority((int)NotificationPriority.High);
            builder.SetTimeoutAfter(60 * 1000);
            builder.SetVisibility(NotificationCompat.VisibilityPublic);

            // Set notification content intent to take user to fullscreen UI if user taps on the
            // notification body.
            builder.SetContentIntent(incomingCallIntent);
            // Set full screen intent to trigger display of the fullscreen UI when the notification
            // manager deems it appropriate.
            builder.SetFullScreenIntent(incomingCallIntent, true);

            // Setup notification content.
            builder.SetSmallIcon(Resource.Drawable.ic_dialog_close_dark);
            builder.SetContentTitle("Incoming Call");
            builder.SetContentText($"Incoming Call from {callerDisplayName}");

            // Use builder.addAction(..) to add buttons to answer or reject the call.
            builder.AddAction(new NotificationCompat.Action(1, "Reject", PI));
            builder.AddAction(new NotificationCompat.Action(1, "Answer", PI));

            var notification = builder.Build();
            notification.Flags = NotificationFlags.AutoCancel & NotificationFlags.Insistent & NotificationFlags.NoClear & NotificationFlags.OngoingEvent;

            NotificationManager notificationManager = (NotificationManager)this.GetSystemService(Context.NotificationService);
            notificationManager.Notify(2, notification);
            
            
        }
    }
}