using CurrencyAPI.Helper;
using CurrencyAPI.Models;
using CurrencyAPI.Services.Interfaces;
using System.Xml;

namespace CurrencyAPI.Services
{
    public class CurrencyService : ICurrencyService
    {
        AllResponseDataCurrencies AllCurrencies = new();
        ResponseDataCurrency Currency = new();

        string exchangeRate = "http://www.tcmb.gov.tr/kurlar/today.xml";
        public AllResponseDataCurrencies GetAll()
        {
            AllCurrencies.Data = new List<ResponseDataCurrency>();

            try
            {
                var doc = new XmlDocument();
                doc.Load(exchangeRate);
                if (doc.SelectNodes("Tarih_Date").Count < 1)
                {
                    AllCurrencies.Exception = "Cannot find currency";
                    return AllCurrencies;
                }
                foreach (XmlNode item in doc.SelectNodes("Tarih_Date")[0].ChildNodes)
                {
                    ResponseDataCurrency currency = new();
                    currency.Code = item.Attributes["Kod"].Value;
                    currency.Name = item["Isim"].InnerText;
                    currency.Unit = int.Parse(item["Unit"].InnerText);
                    currency.BuyingRate = item["ForexBuying"].InnerText.Replace(".", ",");
                    currency.SellingRate = item["ForexSelling"].InnerText.Replace(".", ",");
                    currency.EffectiveBuyingRate = item["BanknoteBuying"].InnerText.Replace(".", ",");
                    currency.EffectiveSellingRate = item["BanknoteSelling"].InnerText.Replace(".", ",");
                    AllCurrencies.Data.Add(currency);
                }
                return AllCurrencies;
            }
            catch (Exception ex)
            {
                AllCurrencies.Exception = ex.Message;
                return AllCurrencies;
            }

        }
        public ResponseDataCurrency GetCurrencyByCode(Currencies request)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(exchangeRate);
                if (doc.SelectNodes("Tarih_Date").Count < 1)
                {
                    return Currency;
                }
                foreach (XmlNode item in doc.SelectNodes("Tarih_Date")[0].ChildNodes)
                {
                    if (item.Attributes["Kod"].Value == request.ToString())
                    {

                        Currency.Code = item.Attributes["Kod"].Value;
                        Currency.Name = item["Isim"].InnerText;
                        Currency.Unit = int.Parse(item["Unit"].InnerText);
                        Currency.BuyingRate = item["ForexBuying"].InnerText.Replace(".", ",");
                        Currency.SellingRate = item["ForexSelling"].InnerText.Replace(".", ",");
                        Currency.EffectiveBuyingRate = item["BanknoteBuying"].InnerText.Replace(".", ",");
                        Currency.EffectiveSellingRate = item["BanknoteSelling"].InnerText.Replace(".", ",");
                    }

                }
                return Currency;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
