using CurrencyAPI.Helper;
using CurrencyAPI.Models;

namespace CurrencyAPI.Services.Interfaces
{
    public interface ICurrencyService
    {
        AllResponseDataCurrencies GetAll(); 
        ResponseDataCurrency GetCurrencyByCode(Currencies request);
    }
}
