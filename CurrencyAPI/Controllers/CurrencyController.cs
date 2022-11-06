using CurrencyAPI.Helper;
using CurrencyAPI.Models;
using CurrencyAPI.Services;
using CurrencyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CurrencyController : ControllerBase
    {
        ICurrencyService _currencyService = new CurrencyService();
        [HttpGet]
        [ActionName("AllCurrencies")]
        public AllResponseDataCurrencies GetAllCurrencies()
        {  
           return _currencyService.GetAll();
        }
    
        [HttpPost]
        [ActionName("GetCurrencyByCode")]
        public ResponseDataCurrency GetCurrencyByCode(Currencies request)
        {
            return _currencyService.GetCurrencyByCode(request);
        }
    }
}
