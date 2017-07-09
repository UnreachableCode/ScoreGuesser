using System.Collections.Generic;
using System.Threading.Tasks;
using ScoreGuesser.Common.Models;

namespace ScoreGuesser.Common.Services
{
    public interface IPlayerDataService
    {
        Task<IEnumerable<Player>> FetchPlayersDataAsync(string url);
        Task<byte[]> GetProfilePicture(Player player);
    }
}
