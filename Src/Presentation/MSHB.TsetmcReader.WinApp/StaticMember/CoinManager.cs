using System;
using System.Collections.Concurrent;

namespace MSHB.TsetmcReader.WinApp
{
    public static class CoinManager
    {
        public const string RefahCoin   = "Refah0312";
        public const string SamanCoin   = "Saman0412";
        public const string MellatCoin  = "Mellat0211";
        public const string SaderatCoin = "Saderat0310";
        public const string AyandehCoin = "Ayandeh0411";
        public static ConcurrentDictionary<string, decimal> _coins = new ConcurrentDictionary<string, decimal>();
        static CoinManager()
        {
            _coins.TryAdd(MellatCoin, 0);
            _coins.TryAdd(SaderatCoin, 0);
            _coins.TryAdd(SamanCoin, 0);
            _coins.TryAdd(AyandehCoin, 0);
            _coins.TryAdd(RefahCoin, 0);
        }
        public static decimal GetDiffPrice(string coin1, string coin2)
        {
            return Math.Abs(_coins[coin1] - _coins[coin2]);
        }
    }
}
