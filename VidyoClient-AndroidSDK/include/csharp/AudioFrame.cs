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
	public class AudioFrame{
#if __IOS__
		const string importLib = "__Internal";
#else
		const string importLib = "libVidyoClient";
#endif
		private IntPtr objPtr; // opaque VidyoAudioFrame reference.
		public IntPtr GetObjectPtr(){
			return objPtr;
		}
		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoAudioFrameConstructCopyNative(IntPtr other);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern void VidyoAudioFrameDestructNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoAudioFrameGetBitsPerSampleNative(IntPtr f);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoAudioFrameGetDataNative(IntPtr f);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern Boolean VidyoAudioFrameGetDiscontinuityNative(IntPtr f);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern Boolean VidyoAudioFrameGetDiscontinuityBitPresentNative(IntPtr f);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoAudioFrameGetElapsedTimeNative(IntPtr f);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern int VidyoAudioFrameGetEnergyNative(IntPtr f);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern Boolean VidyoAudioFrameGetEnergyBitPresentNative(IntPtr f);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoAudioFrameGetFormatNative(IntPtr f);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoAudioFrameGetNumberOfChannelsNative(IntPtr f);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoAudioFrameGetNumberOfSamplesNative(IntPtr f);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoAudioFrameGetSampleRateNative(IntPtr f);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoAudioFrameGetSizeNative(IntPtr f);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern Boolean VidyoAudioFrameGetSpeechNative(IntPtr f);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern Boolean VidyoAudioFrameGetSpeechBitPresentNative(IntPtr f);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoAudioFrameGetTimestampNative(IntPtr f);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr VidyoAudioFrameGetUserDataNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		public static extern void VidyoAudioFrameSetUserDataNative(IntPtr obj, IntPtr userData);

		public AudioFrame(IntPtr other){
			objPtr = VidyoAudioFrameConstructCopyNative(other);
			VidyoAudioFrameSetUserDataNative(objPtr, GCHandle.ToIntPtr(GCHandle.Alloc(this, GCHandleType.Weak)));
		}
		~AudioFrame(){
			if(objPtr != IntPtr.Zero){
				VidyoAudioFrameSetUserDataNative(objPtr, IntPtr.Zero);
				VidyoAudioFrameDestructNative(objPtr);
			}
		}
		public ulong GetBitsPerSample(){

			ulong ret = VidyoAudioFrameGetBitsPerSampleNative(objPtr);

			return ret;
		}
		public ulong GetData(){

			ulong ret = VidyoAudioFrameGetDataNative(objPtr);

			return ret;
		}
		public Boolean GetDiscontinuity(){

			Boolean ret = VidyoAudioFrameGetDiscontinuityNative(objPtr);

			return ret;
		}
		public Boolean GetDiscontinuityBitPresent(){

			Boolean ret = VidyoAudioFrameGetDiscontinuityBitPresentNative(objPtr);

			return ret;
		}
		public ulong GetElapsedTime(){

			ulong ret = VidyoAudioFrameGetElapsedTimeNative(objPtr);

			return ret;
		}
		public int GetEnergy(){

			int ret = VidyoAudioFrameGetEnergyNative(objPtr);

			return ret;
		}
		public Boolean GetEnergyBitPresent(){

			Boolean ret = VidyoAudioFrameGetEnergyBitPresentNative(objPtr);

			return ret;
		}
		public String GetFormat(){

			IntPtr ret = VidyoAudioFrameGetFormatNative(objPtr);

			return (string)MarshalPtrToUtf8.GetInstance().MarshalNativeToManaged(ret);
		}
		public ulong GetNumberOfChannels(){

			ulong ret = VidyoAudioFrameGetNumberOfChannelsNative(objPtr);

			return ret;
		}
		public ulong GetNumberOfSamples(){

			ulong ret = VidyoAudioFrameGetNumberOfSamplesNative(objPtr);

			return ret;
		}
		public ulong GetSampleRate(){

			ulong ret = VidyoAudioFrameGetSampleRateNative(objPtr);

			return ret;
		}
		public ulong GetSize(){

			ulong ret = VidyoAudioFrameGetSizeNative(objPtr);

			return ret;
		}
		public Boolean GetSpeech(){

			Boolean ret = VidyoAudioFrameGetSpeechNative(objPtr);

			return ret;
		}
		public Boolean GetSpeechBitPresent(){

			Boolean ret = VidyoAudioFrameGetSpeechBitPresentNative(objPtr);

			return ret;
		}
		public ulong GetTimestamp(){

			ulong ret = VidyoAudioFrameGetTimestampNative(objPtr);

			return ret;
		}
	};
}
