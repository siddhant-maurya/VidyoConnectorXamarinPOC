package md5a5062c2e70c63c4337b0dff06f518469;


public class FirebaseIDInstance
	extends com.google.firebase.iid.FirebaseInstanceIdService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTokenRefresh:()V:GetOnTokenRefreshHandler\n" +
			"";
		mono.android.Runtime.register ("VidyoConnector.Android.FirebaseIDInstance, VidyoConnector.Android", FirebaseIDInstance.class, __md_methods);
	}


	public FirebaseIDInstance ()
	{
		super ();
		if (getClass () == FirebaseIDInstance.class)
			mono.android.TypeManager.Activate ("VidyoConnector.Android.FirebaseIDInstance, VidyoConnector.Android", "", this, new java.lang.Object[] {  });
	}


	public void onTokenRefresh ()
	{
		n_onTokenRefresh ();
	}

	private native void n_onTokenRefresh ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
