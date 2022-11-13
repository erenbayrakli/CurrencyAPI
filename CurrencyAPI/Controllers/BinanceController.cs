using CurrencyAPI.Helper;
using CurrencyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static CurrencyAPI.Models.BinanceModel;

namespace CurrencyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BinanceController : ControllerBase
    {
        private IBinanceService _binanceService;
        public BinanceController(IBinanceService binanceService)
        {
            _binanceService = binanceService;
        }
        [HttpPost]
        [ActionName("SearchCoin")]
        public ResponseDataCoin SearchCoin(RequestDataCoin request)
        {
            return _binanceService.SearchCoin(request);
        }
        [HttpPost]
        [ActionName("GetCoinByCode")]
        public ResponseDataCoin GetCoinByCode(Coins request)
        {
            return _binanceService.GetCoinByCode(request);
        }
    }
}
