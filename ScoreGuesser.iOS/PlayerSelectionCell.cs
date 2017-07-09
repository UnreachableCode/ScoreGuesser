using System;
using UIKit;
using System.Threading.Tasks;
using ScoreGuesser.Common.Models;
using ScoreGuesser.Common.Services;
using Foundation;

namespace ScoreGuesser.iOS
{
    public partial class PlayerSelectionCell : UICollectionViewCell
    {
        Player _playerOne;
        Player _playerTwo;

        UIGestureRecognizer _firstImageTapped;
        UIGestureRecognizer _secondImageTapped;

        IPlayerDataService _playerDataService; //todo Dependency Inject.
        ICollectionDelegate _collectionDelegate;

        public PlayerSelectionCell(IntPtr handle) : base(handle) { }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            FirstPlayerImageView.UserInteractionEnabled = true;
            SecondPlayerImageView.UserInteractionEnabled = true;
            InitialiseCell();
            _playerDataService = new PlayerDataService();
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
            FirstPlayerNameLabel.Text = player1.FirstName + " " + player1.LastName;
            SecondPlayerNameLabel.Text = player2.FirstName + " " + player2.LastName;
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
                if (tappedPlayer.FanduelPointsPerGame > otherPlayer.FanduelPointsPerGame)
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
            DownloadImageAsync(player, (succeeded, imageBytes) =>
            {
                SetImage(FirstPlayerImageView, succeeded, imageBytes);
            });

            DownloadImageAsync(player2, (succeeded, imageBytes) =>
            {
                SetImage(SecondPlayerImageView, succeeded, imageBytes);
            });
        }

        void SetImage(UIImageView imageView, bool succeeded, byte[] imageBytes)
        {
            UIImage image = null;
            if (succeeded)
            {
                image = UIImage.LoadFromData(NSData.FromArray(imageBytes));
            }
            else
            {
                image = UIImage.FromBundle("NoPlayerImage");
            }
            imageView.Image = image;
        }

        async void DownloadImageAsync(Player player, Action<bool, byte[]> completionHandler)
        {
            var downloadedImage = await _playerDataService.GetProfilePicture(player);

            if (downloadedImage != null)
            {
                completionHandler(true, downloadedImage);
            }
        }
    }
}