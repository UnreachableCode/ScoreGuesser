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

namespace ScoreGuesser
{
    [Register ("CongratulationsViewController")]
    partial class CongratulationsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PlayAgainButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (PlayAgainButton != null) {
                PlayAgainButton.Dispose ();
                PlayAgainButton = null;
            }
        }
    }
}