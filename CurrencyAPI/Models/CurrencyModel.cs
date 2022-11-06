namespace CurrencyAPI.Models
{ 
    public class ResponseDataCurrency
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public string BuyingRate { get; set; }
        public string SellingRate { get; set; }
        public string EffectiveBuyingRate { get; set; }
        public string EffectiveSellingRate { get; set; } 
    }
    public class AllResponseDataCurrencies
    {
        public List<ResponseDataCurrency> Data { get; set; }
        public string Exception { get; set; }
    }
}
