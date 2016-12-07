﻿using Android.Content;
using Android.Print;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(Forms9Patch.Droid.PrintService))]
namespace Forms9Patch.Droid
{
	public class PrintService : IPrintService
	{
		public void Print(WebView viewToPrint, string jobName)
		{
			var droidViewToPrint = Platform.CreateRenderer(viewToPrint).ViewGroup.GetChildAt(0) as Android.Webkit.WebView;

			if (droidViewToPrint != null)
			{
				// Only valid for API 19+
				var version = Android.OS.Build.VERSION.SdkInt;

				if (version >= Android.OS.BuildVersionCodes.Kitkat)
				{
					var printMgr = (PrintManager)Forms.Context.GetSystemService(Context.PrintService);
					printMgr.Print(jobName, droidViewToPrint.CreatePrintDocumentAdapter(), null);
				}
			}
		}

		public bool CanPrint()
		{
			return Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat;
		}
	}
}
