using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using ScoreGuesser.Common.Models;
using System;

namespace ScoreGuesser.Common.Services
{
    public class PlayerDataService : IPlayerDataService
    {
        string _url;

        public async Task<IEnumerable<Player>> FetchPlayersDataAsync(string url)
        {
            var list = new List<Player>();
            try
            {
                using (var client = new HttpClient())
                {
                    var json = await client.GetStringAsync(url);

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
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<byte[]> GetProfilePicture(Player player)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Task<byte[]> contentsTask = client.GetByteArrayAsync(player.ImageUrl);

                    if (contentsTask.Status != TaskStatus.Faulted)
                    {
                        var contents = await contentsTask;

                        return contents;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("Exception caught: " + e);
                return null;
            }
        }
    }
}
