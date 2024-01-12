using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.Service.Helper
{
    public class TelegramHelper
    {
        private const string APIKey = "6136125871:AAGl0M8eKfGJfpRVYq8j5K3MYJqcsdD7ETo";
        private const string ChatID = "6136125871";

        public async Task<bool> sendMessage(string message)
        {
            string retval = string.Empty;
            string url = $"https://api.telegram.org/bot{APIKey}/sendMessage?chat_id={ChatID}&text={message}";
            using (var webClient = new WebClient())
            {
                retval = webClient.DownloadString(url);
            }
            if (retval == null)
            {
                return false;
            }
            return true;
        }
    }
}
