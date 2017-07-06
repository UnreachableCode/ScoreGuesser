// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ScoreGuesser.iOS
{
    [Register ("PlayerSelectionCell")]
    partial class PlayerSelectionCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView FirstPlayerImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FirstPlayerNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView SecondPlayerImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SecondPlayerNameLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FirstPlayerImageView != null) {
                FirstPlayerImageView.Dispose ();
                FirstPlayerImageView = null;
            }

            if (FirstPlayerNameLabel != null) {
                FirstPlayerNameLabel.Dispose ();
                FirstPlayerNameLabel = null;
            }

            if (SecondPlayerImageView != null) {
                SecondPlayerImageView.Dispose ();
                SecondPlayerImageView = null;
            }

            if (SecondPlayerNameLabel != null) {
                SecondPlayerNameLabel.Dispose ();
                SecondPlayerNameLabel = null;
            }
        }
    }
}