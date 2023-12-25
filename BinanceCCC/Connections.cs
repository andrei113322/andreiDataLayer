using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binance.API.Csharp.Client;
using Binance.API.Csharp.Client.Models.Market.TradingRules;

namespace BinanceCCC
{
    public class Connections
    {
        private string apiKey = "CXX4LxqXPI8J8Q0jXaXcOduUGuaQ73P4V9xKD2jX62ly4zdpv2U0T5hqvg2i8evH";
        private string SApiKey = "m7dDAp2tKvTvSeCI1jOeuVgORozwPpXsWTvHfCWAfxslydjDWg9imQGM1AB9sPMR";
        private BinanceClient myBClient;
        public Connections()
        {
            ApiClient myClient = new ApiClient(apiKey, SApiKey);
            myBClient = new BinanceClient(myClient);
        }

        public async Task<Dictionary<string, decimal>> GetCriptoValue(List<string> input)
        {
            try
            {
                var tickerPrices = await myBClient.GetAllPrices();
                Dictionary<string, decimal>  result = new Dictionary<string, decimal>();
                foreach (var item in input)
                {
                    result.Add(item, Convert.ToDecimal(tickerPrices.FirstOrDefault(SymbolPrice => SymbolPrice.Symbol == item).Price));
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }
    }
}
