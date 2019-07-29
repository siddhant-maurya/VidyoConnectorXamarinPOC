// DO NOT EDIT! This is an autogenerated file. All changes will be
// overwritten!

//	Copyright (c) 2016 Vidyo, Inc. All rights reserved.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.InteropServices;

namespace VidyoClient
{
	public class Application{
#if __IOS__
		const string importLib = "__Internal";
#else
		const string importLib = "libVidyoClient";
#endif
		private IntPtr objPtr; // opaque VidyoApplication reference.
		public IntPtr GetObjectPtr(){
			return objPtr;
		}
		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoApplicationConstructNative(IntPtr endpoint);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoApplicationConstructCopyNative(IntPtr other);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern void VidyoApplicationDestructNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern Boolean VidyoApplicationRegisterUpdaterEventListenerNative(IntPtr app, DownloadCompletedCallback onDownloadCompleted, DownloadFailedCallback onDownloadFailed);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern void VidyoApplicationSetWebProxyCredentialsNative(IntPtr app, IntPtr webProxyUserName, IntPtr webProxyPassword);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern Boolean VidyoApplicationStartUpdateServiceNative(IntPtr app, IntPtr currentVersion, IntPtr workingDirectory, IntPtr server, IntPtr caFilePath, IntPtr webProxyUsername, IntPtr webProxyPassword);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern void VidyoApplicationStopUpdateServiceNative(IntPtr app);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr VidyoApplicationGetUserDataNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		public static extern void VidyoApplicationSetUserDataNative(IntPtr obj, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void DownloadCompletedCallback(IntPtr app, IntPtr version, IntPtr downloadedFile);
		private static DownloadCompletedCallback _mDownloadCompletedCallback;
		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoApplicationDownloadCompletedCallbackGetversionCStr(IntPtr version);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoApplicationDownloadCompletedCallbackGetdownloadedFileCStr(IntPtr downloadedFile);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void DownloadFailedCallback(IntPtr app, ApplicationDownloadFailedReason reason);
		private static DownloadFailedCallback _mDownloadFailedCallback;
		public enum ApplicationDownloadFailedReason{
			ApplicationDOWNLOADFAILEDREASON_WebProxyAuthenticationRequired,
			ApplicationDOWNLOADFAILEDREASON_MiscError
		}
		public interface IRegisterUpdaterEventListener{

			void DownloadCompletedCallback(String version, String downloadedFile);
			void DownloadFailedCallback(ApplicationDownloadFailedReason reason);
		}
		private static IRegisterUpdaterEventListener _mIRegisterUpdaterEventListener;
		public Application(Endpoint endpoint){

			objPtr = VidyoApplicationConstructNative((endpoint != null) ? endpoint.GetObjectPtr():IntPtr.Zero);
			VidyoApplicationSetUserDataNative(objPtr, GCHandle.ToIntPtr(GCHandle.Alloc(this, GCHandleType.Weak)));
		}
		public Application(IntPtr other){
			objPtr = VidyoApplicationConstructCopyNative(other);
			VidyoApplicationSetUserDataNative(objPtr, GCHandle.ToIntPtr(GCHandle.Alloc(this, GCHandleType.Weak)));
		}
		~Application(){
			if(objPtr != IntPtr.Zero){
				VidyoApplicationSetUserDataNative(objPtr, IntPtr.Zero);
				VidyoApplicationDestructNative(objPtr);
			}
		}
		public Boolean RegisterUpdaterEventListener(IRegisterUpdaterEventListener _iIRegisterUpdaterEventListener){
			_mIRegisterUpdaterEventListener = _iIRegisterUpdaterEventListener;
			_mDownloadCompletedCallback = DownloadCompletedCallbackDelegate;
			_mDownloadFailedCallback = DownloadFailedCallbackDelegate;

			Boolean ret = VidyoApplicationRegisterUpdaterEventListenerNative(objPtr, _mDownloadCompletedCallback, _mDownloadFailedCallback);

			return ret;
		}
		public void SetWebProxyCredentials(String webProxyUserName, String webProxyPassword){

			IntPtr nWebProxyUserName = MarshalPtrToUtf8.GetInstance().MarshalManagedToNative(webProxyUserName ?? string.Empty);
			IntPtr nWebProxyPassword = MarshalPtrToUtf8.GetInstance().MarshalManagedToNative(webProxyPassword ?? string.Empty);
			VidyoApplicationSetWebProxyCredentialsNative(objPtr, nWebProxyUserName, nWebProxyPassword);
			Marshal.FreeHGlobal(nWebProxyPassword);
			Marshal.FreeHGlobal(nWebProxyUserName);
		}
		public Boolean StartUpdateService(String currentVersion, String workingDirectory, String server, String caFilePath, String webProxyUsername, String webProxyPassword){

			IntPtr nCurrentVersion = MarshalPtrToUtf8.GetInstance().MarshalManagedToNative(currentVersion ?? string.Empty);
			IntPtr nWorkingDirectory = MarshalPtrToUtf8.GetInstance().MarshalManagedToNative(workingDirectory ?? string.Empty);
			IntPtr nServer = MarshalPtrToUtf8.GetInstance().MarshalManagedToNative(server ?? string.Empty);
			IntPtr nCaFilePath = MarshalPtrToUtf8.GetInstance().MarshalManagedToNative(caFilePath ?? string.Empty);
			IntPtr nWebProxyUsername = MarshalPtrToUtf8.GetInstance().MarshalManagedToNative(webProxyUsername ?? string.Empty);
			IntPtr nWebProxyPassword = MarshalPtrToUtf8.GetInstance().MarshalManagedToNative(webProxyPassword ?? string.Empty);
			Boolean ret = VidyoApplicationStartUpdateServiceNative(objPtr, nCurrentVersion, nWorkingDirectory, nServer, nCaFilePath, nWebProxyUsername, nWebProxyPassword);
			Marshal.FreeHGlobal(nWebProxyPassword);
			Marshal.FreeHGlobal(nWebProxyUsername);
			Marshal.FreeHGlobal(nCaFilePath);
			Marshal.FreeHGlobal(nServer);
			Marshal.FreeHGlobal(nWorkingDirectory);
			Marshal.FreeHGlobal(nCurrentVersion);

			return ret;
		}
		public void StopUpdateService(){

			VidyoApplicationStopUpdateServiceNative(objPtr);
		}
#if __IOS__
[ObjCRuntime.MonoPInvokeCallback(typeof(DownloadCompletedCallback))]
#endif
		private static void DownloadCompletedCallbackDelegate(IntPtr app, IntPtr version, IntPtr downloadedFile){
			IntPtr n_version = VidyoApplicationDownloadCompletedCallbackGetversionCStr(version);

			IntPtr n_downloadedFile = VidyoApplicationDownloadCompletedCallbackGetdownloadedFileCStr(downloadedFile);

			if(_mIRegisterUpdaterEventListener != null)
				_mIRegisterUpdaterEventListener.DownloadCompletedCallback((string)MarshalPtrToUtf8.GetInstance().MarshalNativeToManaged(n_version), (string)MarshalPtrToUtf8.GetInstance().MarshalNativeToManaged(n_downloadedFile));
		}
#if __IOS__
[ObjCRuntime.MonoPInvokeCallback(typeof(DownloadFailedCallback))]
#endif
		private static void DownloadFailedCallbackDelegate(IntPtr app, ApplicationDownloadFailedReason reason){
			if(_mIRegisterUpdaterEventListener != null)
				_mIRegisterUpdaterEventListener.DownloadFailedCallback(reason);
		}
	};
}
