using System.Text;

namespace AcortURL.Helpers
{
    public static class GenerarShortURL
    {
        public static string GenerarShortUrl()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            var shortUrl = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                shortUrl.Append(chars[random.Next(chars.Length)]);
            }

            return shortUrl.ToString();
        }
    }
}
