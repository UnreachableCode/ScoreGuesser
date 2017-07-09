using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace ScoreGuesser.iOS
{
    public class Player
    {
        public Player(string first_Name, string last_Name, string imageUrl, float fppg)
        {
            First_Name = first_Name;
            Last_Name = last_Name;
            ImageUrl = imageUrl;
            FPPG = fppg;
        }

        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string ImageUrl { get; set; }
        public float FPPG { get; set; }

        public async Task<UIImage> LoadImage()
        {
            try
            {
                var httpClient = new HttpClient();

                Task<byte[]> contentsTask = httpClient.GetByteArrayAsync(ImageUrl);

                if (contentsTask.Status != TaskStatus.Faulted)
                {
                    var contents = await contentsTask;

                    return UIImage.LoadFromData(NSData.FromArray(contents));
                }
                else
                {
                    return UIImage.FromBundle("NoPlayerImage");
                }
            }
            catch
            {
                return null;
            }
        }
    }
}