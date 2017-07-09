using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
using System;

namespace ScoreGuesser.iOS
{
    public class PlayerDataDownloader
    {
        string _url;

        public PlayerDataDownloader(string url)
        {
            _url = url;
        }

        public async Task<List<Player>> FetchPlayersDataAsync(string url)
        {
            var list = new List<Player>();
            using (WebClient client = new WebClient())
            {
                var json = await client.DownloadStringTaskAsync(url);

                dynamic dyn = JsonConvert.DeserializeObject(json);

                foreach (var player in dyn.players)
                {
                    string first_Name = player.first_name;
                    string last_Name = player.last_name;
                    string imageUrl = player.images.@default.url;
                    float fppg = player.fppg != null ? player.fppg.ToObject<float>() : 0;

                    list.Add(new Player(first_Name, last_Name, imageUrl, fppg));
                }
            }

            return list;
        }
    }
}
