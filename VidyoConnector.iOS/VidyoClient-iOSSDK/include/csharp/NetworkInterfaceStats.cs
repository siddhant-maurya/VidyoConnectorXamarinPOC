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
	public class NetworkInterfaceStats{
#if __IOS__
		const string importLib = "__Internal";
#else
		const string importLib = "libVidyoClient";
#endif
		private IntPtr objPtr; // opaque VidyoNetworkInterfaceStats reference.
		public IntPtr GetObjectPtr(){
			return objPtr;
		}
		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern Boolean VidyoNetworkInterfaceStatsGetisUpNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoNetworkInterfaceStatsGetnameNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoNetworkInterfaceStatsGettypeNative(IntPtr obj);

		public Boolean isUp;
		public String name;
		public String type;
		public NetworkInterfaceStats(IntPtr obj){
			objPtr = obj;

			isUp = VidyoNetworkInterfaceStatsGetisUpNative(objPtr);
			name = (string)MarshalPtrToUtf8.GetInstance().MarshalNativeToManaged(VidyoNetworkInterfaceStatsGetnameNative(objPtr));
			type = (string)MarshalPtrToUtf8.GetInstance().MarshalNativeToManaged(VidyoNetworkInterfaceStatsGettypeNative(objPtr));
		}
	};
}