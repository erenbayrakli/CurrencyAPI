using CurrencyAPI.Helper;
using static CurrencyAPI.Models.BinanceModel;

namespace CurrencyAPI.Services.Interfaces
{
    public interface IBinanceService
    {
        ResponseDataCoin SearchCoin(RequestDataCoin request);
        ResponseDataCoin GetCoinByCode(Coins request);

    }
}
