using System;

using Foundation;
using UIKit;

namespace SampleCardView
{
	public partial class CardViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("CardViewCell");
		public static readonly UINib Nib;

		static CardViewCell()
		{
			Nib = UINib.FromName("CardViewCell", NSBundle.MainBundle);
		}

		protected CardViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
