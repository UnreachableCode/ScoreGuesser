using Foundation;
using System;
using UIKit;

namespace ScoreGuesser.iOS
{
    public partial class PlayerSelectionCell : UICollectionViewCell
    {
        public PlayerSelectionCell(IntPtr handle) : base(handle) { }

        internal void PopulateCell(Player player, Player player2)
        {
            DownloadImageAsync(player, (succeeded, image) =>
            {
                if (succeeded)
                {
                    FirstPlayerImageView.Image = image;
                }
            });

            DownloadImageAsync(player2, (succeeded, image) =>
            {
                if (succeeded)
                {
                    SecondPlayerImageView.Image = image;
                }
            });
        }

        async void DownloadImageAsync(Player player, Action<bool, UIImage> completionHandler)
        {
            var downloadedImage = await player.LoadImage();
            completionHandler(true, downloadedImage);
        }
    }
}