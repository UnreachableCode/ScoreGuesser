// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ScoreGuesser.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UILabel CorrectGuessesLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UICollectionView PlayerCollectionView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (PlayerCollectionView != null) {
				PlayerCollectionView.Dispose ();
				PlayerCollectionView = null;
			}

			if (CorrectGuessesLabel != null) {
				CorrectGuessesLabel.Dispose ();
				CorrectGuessesLabel = null;
			}
		}
	}
}
