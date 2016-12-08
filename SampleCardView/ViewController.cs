using System;
using Foundation;
using CoreGraphics;
using UIKit;
using ObjCRuntime;
using System.Collections.Generic;
using AsyncImageViews;

namespace SampleCardView
{
	public class Card
	{
		public string Heading {
			get;
			set;
		}

		public string Footer {
			get;
			set;
		}

		public string ImageURL {
			get;
			set;
		}
	}

	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			this.Title = "Card View";
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			List<Card> lstCard = new List<Card>();
			lstCard.Add(new Card() { Heading = "SELENA GOMEZ PANTENE PHOTOSHOOT", Footer = "HD Wallpapers", ImageURL = "http://www.hdwallpapers.in/download/selena_gomez_pantene_photoshoot-1680x1050.jpg" });
			lstCard.Add(new Card() { Heading = "POWER RANGERS ELIZABETH BANKS RITA REPULSA 4K", Footer = "HD Wallpapers", ImageURL = "http://www.hdwallpapers.in/download/power_rangers_elizabeth_banks_rita_repulsa_4k-1680x1050.jpg" });
			lstCard.Add(new Card() { Heading = "BALLERINA 4K", Footer = "HD Wallpapers", ImageURL = "http://www.hdwallpapers.in/download/ballerina_4k-1680x1050.jpg" });
			lstCard.Add(new Card() { Heading = "LAUREN COHAN 2016 4K", Footer = "HD Wallpapers", ImageURL = "http://www.hdwallpapers.in/download/lauren_cohan_2016_4k-1680x1050.jpg" });
			lstCard.Add(new Card() { Heading = "KELLY BROOK 2016", Footer = "HD Wallpapers", ImageURL = "http://www.hdwallpapers.in/download/kelly_brook_2016-1680x1050.jpg" });
			lstCard.Add(new Card() { Heading = "2017 MERCEDES MAYBACH S 650 CABRIOLET", Footer = "HD Wallpapers", ImageURL = "http://www.hdwallpapers.in/download/2017_mercedes_maybach_s_650_cabriolet-1680x1050.jpg" });
			CardTableView.Source = new CardTableSource(lstCard);
			CardTableView.ReloadData();
			CardTableView.BackgroundColor = UIColor.Clear;
			CardTableView.TableFooterView = new UIView();
			CardTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
		}
	}

	public class CardTableSource : UITableViewSource
	{
		List<Card> TableItems;
		string CellIdentifier = "TableCell";

		public CardTableSource(List<Card> items)
		{
			TableItems = items;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return TableItems.Count;
		}

		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 178;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(CellIdentifier) as CardViewCell;
			if (cell == null) {
				var views = NSBundle.MainBundle.LoadNib("CardViewCell", tableView, null);
				cell = Runtime.GetNSObject(views.ValueAt(0)) as CardViewCell;
			}

			cell.CardViewBackground.Layer.CornerRadius = 3f;
			cell.CardHeading.Text = TableItems[indexPath.Row].Heading;
			cell.CardFooter.Text = TableItems[indexPath.Row].Footer;
			AsyncImageView imageView = new AsyncImageView();
			imageView.Frame = new CGRect(0, 32, cell.CardViewBackground.Frame.Width, 100);
			imageView.ContentMode = UIViewContentMode.ScaleAspectFill;
			imageView.AutoresizingMask = UIViewAutoresizing.All;
			imageView.ClipsToBounds = true;
			imageView.ImageURL = NSUrl.FromString(TableItems[indexPath.Row].ImageURL);
			cell.SelectionStyle = UITableViewCellSelectionStyle.None;
			cell.CardViewBackground.Layer.ShadowColor = UIColor.Black.CGColor;
			cell.CardViewBackground.Layer.ShadowOpacity = 0.8f;
			cell.CardViewBackground.Layer.ShadowRadius = 1.0f;
			cell.CardViewBackground.Layer.ShadowOffset = new CGSize(0f, 0f);
			cell.CardViewBackground.BackgroundColor = UIColor.White;
			cell.AutosizesSubviews = true;
			cell.CardViewBackground.AddSubview(imageView);

			return cell;
		}
	}
}
