using NSubstitute;
using NUnit.Framework;
using ScoreGuesser.Common.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using ScoreGuesser.Common.Models;
using System.Net.Http;
using System;

namespace ScoreGuesser.Tests.Services
{
    [TestFixture]
    public class PlayerDataServiceTests
    {
        [Test]
        public async Task FetchPlayerDataAsync_WhenCalled_ReturnsPlayersAsync()
        {
            var playerDataService = new PlayerDataService();
            var validUrl = @"https://cdn.rawgit.com/liamjdouglas/bb40ee8721f1a9313c22c6ea0851a105/raw/6b6fc89d55ebe4d9b05c1469349af33651d7e7f1/Player.json";

            var response = await playerDataService.FetchPlayersDataAsync(validUrl);

            Assert.IsInstanceOf<IEnumerable<Player>>(response);
        }

        [Test]
        public async Task FetchPlayerDataAsync_WhenCalledWithNoUrl_ThrowsArgumentNullException()
        {
            var playerDataService = new PlayerDataService();

            var response = playerDataService.FetchPlayersDataAsync(string.Empty);

            Assert.ThrowsAsync<ArgumentNullException>(() => response);
        }
    }
}
