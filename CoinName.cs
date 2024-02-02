using System;
using System.Collections.Concurrent;

public static class CoinName
{
    public const string RefahCoin = "Refah0310";
    public const string SamanCoin = "Saman0412";
    public const string MellatCoin = "Mellat0211";
    public const string SaderatCoin = "Refah0312";
    public const string AyandehCoin = "Ayandeh0411";
    public static ConcurrentDictionary<string, decimal> _coins = new ConcurrentDictionary<string, decimal>();
    public static CoinName()
    {
        _coins.AddOrUpdate(RefahCoin, 0);
        _coins.AddOrUpdate(SamanCoin, 0);
        _coins.AddOrUpdate(MellatCoin, 0);
        _coins.AddOrUpdate(SaderatCoin, 0);
        _coins.AddOrUpdate(AyandehCoin, 0);
    }
}
