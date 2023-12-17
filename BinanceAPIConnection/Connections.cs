using Binance.API.Csharp.Client;
using Binance.API.Csharp.Client.Models.Market;
using Binance.API.Csharp.Client.Models.Market.TradingRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanceAPIConnection
{
    internal class Connections
    {
        private string apiKey = "CXX4LxqXPI8J8Q0jXaXcOduUGuaQ73P4V9xKD2jX62ly4zdpv2U0T5hqvg2i8evH";
        private string SApiKey = "m7dDAp2tKvTvSeCI1jOeuVgORozwPpXsWTvHfCWAfxslydjDWg9imQGM1AB9sPMR";
        private BinanceClient myBClient;

        Connections()
        {
            ApiClient myClient = new ApiClient(apiKey, SApiKey);
            myBClient = new BinanceClient(myClient);
        }

        public decimal GetCriptoValue(string symbol)
        {
            try
            {
                var tickerPrices = myBClient.GetAllPrices().Result;
                return Convert.ToDecimal(tickerPrices.FirstOrDefault(SymbolPrice => SymbolPrice.Symbol == symbol).Price);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return -1; // or throw an exception, handle the error based on your requirements
            }
        }
    }
}
