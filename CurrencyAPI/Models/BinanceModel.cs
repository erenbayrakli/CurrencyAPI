namespace CurrencyAPI.Models
{
    public class BinanceModel
    {
        public class ResponseDataCoin
        {
            public string Code { get; set; }  
            public string Value { get; set; }
            public string Error { get; set; }
        }
        public class RequestDataCoin
        {
            public string Code { get; set; } 
        }
    }
}
