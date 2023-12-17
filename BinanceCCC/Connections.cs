using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binance.API.Csharp.Client;

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

        public decimal GetCriptoValue(string symbol)
        {
            try
            {
                var tickerPrices = myBClient.GetAllPrices().Result;
                decimal result = Convert.ToDecimal(tickerPrices.FirstOrDefault(SymbolPrice => SymbolPrice.Symbol == symbol).Price);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return -1; // or throw an exception, handle the error based on your requirements
            }
        }
    }
}
