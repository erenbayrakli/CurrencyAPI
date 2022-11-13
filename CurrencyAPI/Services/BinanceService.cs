using CurrencyAPI.Helper;
using CurrencyAPI.Services.Interfaces;
using System.Net;
using static CurrencyAPI.Models.BinanceModel;

namespace CurrencyAPI.Services
{
    public class BinanceService : IBinanceService
    {
        WebClient wb = new();
        ResponseDataCoin response = new();
        public string GetData(string coin)
        {
            string url = $"https://api.binance.com/api/v1/depth?symbol={coin}USDT&limit=20";
            string data = wb.DownloadString(url);
            string coinPrice = data.Substring(35, 8);
            char[] MyChar = { '"', '[' };
            string lastPrice = coinPrice.TrimStart(MyChar);
            string value = lastPrice + " " + "USDT";
            return value;
        }
        public ResponseDataCoin SearchCoin(RequestDataCoin request)
        {
            try
            {
                string data =  GetData(request.Code);
                response.Code = request.Code.ToUpper();
                response.Value = data;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = "Can't find this coin. Please check your coin code!"; 
                return response; 
            }
        }
        public ResponseDataCoin GetCoinByCode(Coins request)
        {
            try
            {
                string data = GetData(request.ToString());
                response.Code = request.ToString().ToUpper();
                response.Value = data;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = "Can't find this coin. Please check your coin code!";
                return response;
            }
        }
    }
}
