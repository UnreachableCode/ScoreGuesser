using Foundation;
using System;
using UIKit;

namespace ScoreGuesser
{
    public partial class CongratulationsViewController : UIViewController
    {
        public CongratulationsViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            PlayAgainButton.Layer.BorderColor = UIColor.White.CGColor;
            PlayAgainButton.TouchUpInside += PlayAgainButton_TouchUpInside;
        }

        void PlayAgainButton_TouchUpInside(object sender, EventArgs e)
        {
            var viewController = Storyboard.InstantiateViewController("MainViewController");
            PresentViewController(viewController, false, null);
        }
    }
}