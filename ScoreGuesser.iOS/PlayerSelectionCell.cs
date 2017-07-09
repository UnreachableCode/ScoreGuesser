using Foundation;
using System;
using System.Linq;
using UIKit;
using System.Threading.Tasks;

namespace ScoreGuesser.iOS
{
    public partial class PlayerSelectionCell : UICollectionViewCell
    {
        Player _playerOne;
        Player _playerTwo;

        UIGestureRecognizer _firstImageTapped;
        UIGestureRecognizer _secondImageTapped;

        ICollectionDelegate _collectionDelegate;

        public PlayerSelectionCell(IntPtr handle) : base(handle) { }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            FirstPlayerImageView.UserInteractionEnabled = true;
            SecondPlayerImageView.UserInteractionEnabled = true;
            InitialiseCell();
        }

        public override void PrepareForReuse()
        {
            base.PrepareForReuse();
            FirstPlayerImageView.RemoveGestureRecognizer(_firstImageTapped);
            SecondPlayerImageView.RemoveGestureRecognizer(_secondImageTapped);
            InitialiseCell();
        }

        internal void PopulateCell(ICollectionDelegate collectionDelegate, Player player1, Player player2)
        {
            _collectionDelegate = collectionDelegate;
            _playerOne = player1;
            _playerTwo = player2;
            SetImages(player1, player2);
            FirstPlayerNameLabel.Text = player1.First_Name + " " + player1.Last_Name;
            SecondPlayerNameLabel.Text = player2.First_Name + " " + player2.Last_Name;
            SetUpTapGestures();
        }

        void InitialiseCell()
        {
            ResultLabel.Text = string.Empty;
            ResultLabel.Alpha = 0;
        }

        void SetUpTapGestures()
        {
            _firstImageTapped = new UITapGestureRecognizer(FirstImageTapped);
            _secondImageTapped = new UITapGestureRecognizer(SecondImageTapped);

            FirstPlayerImageView.AddGestureRecognizer(_firstImageTapped);
            SecondPlayerImageView.AddGestureRecognizer(_secondImageTapped);
        }

        void FirstImageTapped()
        {
            IsScoreGreater(_playerOne, _playerTwo);
        }

        void SecondImageTapped()
        {
            IsScoreGreater(_playerTwo, _playerOne);
        }

        void IsScoreGreater(Player tappedPlayer, Player otherPlayer)
        {
            Animate(0.25, () =>
            {
                ResultLabel.Alpha = 1;
                if (tappedPlayer.FPPG > otherPlayer.FPPG)
                {
                    //correct
                    ResultLabel.Text = "Correct answer!";
                    _collectionDelegate.AddOnePoint();
                }
                else
                {
                    //incorrect
                    ResultLabel.Text = "That is incorrect";
                }
            },
            async () =>
            {
                await Task.Delay(2000);
                _collectionDelegate.ScrollToNext();
            });
        }

        void SetImages(Player player, Player player2)
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