using System;
using UIKit;
using System.Collections.Generic;
using Foundation;

namespace ScoreGuesser.iOS
{
    public partial class ViewController : UIViewController
    {
        PlayerDataDownloader _playerDataDownloader;
        List<Player> _playerList;

        protected ViewController(IntPtr handle) : base(handle) { }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            string url = @"https://cdn.rawgit.com/liamjdouglas/bb40ee8721f1a9313c22c6ea0851a105/raw/6b6fc89d55ebe4d9b05c1469349af33651d7e7f1/Player.json";

            _playerDataDownloader = new PlayerDataDownloader(url);

            _playerList = await _playerDataDownloader.FetchPlayersDataAsync(url);
        }
    }
}


