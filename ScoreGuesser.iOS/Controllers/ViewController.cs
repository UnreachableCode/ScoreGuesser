using System;
using System.Linq;
using UIKit;
using System.Collections.Generic;
using Foundation;
using ScoreGuesser.Common.Models;
using ScoreGuesser.Common.Services;

namespace ScoreGuesser.iOS
{

    public partial class ViewController : UIViewController, IUICollectionViewDataSource, ICollectionDelegate
    {
        IPlayerDataService _playerDataDownloader; //todo: Dependency Inject this eventually.
        List<Player> _playerList;

        int _currentPosition;
        int _correctGuesses;

        protected ViewController(IntPtr handle) : base(handle) { }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            string url = @"https://cdn.rawgit.com/liamjdouglas/bb40ee8721f1a9313c22c6ea0851a105/raw/6b6fc89d55ebe4d9b05c1469349af33651d7e7f1/Player.json";

            _playerDataDownloader = new PlayerDataService();

            var result = await _playerDataDownloader.FetchPlayersDataAsync(url);
            _playerList = result.ToList();

            PlayerCollectionView.DataSource = this;
        }

        public nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return 30;
        }

        public UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (PlayerSelectionCell)collectionView.DequeueReusableCell("PlayerSelectionCell", indexPath);
            var rand = new Random();
            var nextCell = rand.Next(0, _playerList.Count);
            var nextCell2 = rand.Next(0, _playerList.Count);
            cell.PopulateCell(this, _playerList[nextCell], _playerList[nextCell2]);
            return cell;
        }

        void ICollectionDelegate.ScrollToNext()
        {
            var index = NSIndexPath.FromRowSection(++_currentPosition, 0);
            PlayerCollectionView.ScrollToItem(index, UICollectionViewScrollPosition.Top, true);
        }

        void ICollectionDelegate.AddOnePoint()
        {
            _correctGuesses++;
            CorrectGuessesLabel.Text = "Correct Guesses: " + _correctGuesses;
            if (_correctGuesses >= 10)
            {
                var viewController = Storyboard.InstantiateViewController("CongratulationsViewController");
                PresentViewController(viewController, true, null);
            }
        }
    }
}