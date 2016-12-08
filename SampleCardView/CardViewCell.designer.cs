// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SampleCardView
{
	[Register ("CardViewCell")]
	partial class CardViewCell
	{
		[Outlet]
		public UIKit.UILabel CardFooter { get; private set; }

		[Outlet]
		public UIKit.UILabel CardHeading { get; private set; }

		[Outlet]
		public UIKit.UIView CardViewBackground { get; private set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CardFooter != null) {
				CardFooter.Dispose ();
				CardFooter = null;
			}

			if (CardHeading != null) {
				CardHeading.Dispose ();
				CardHeading = null;
			}

			if (CardViewBackground != null) {
				CardViewBackground.Dispose ();
				CardViewBackground = null;
			}
		}
	}
}
