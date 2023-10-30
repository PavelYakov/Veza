namespace VezaApp.Models
{
    public class CurrencyExchangeRates
    {
        public static Dictionary<string, decimal> ExchangeRates = new Dictionary<string, decimal>
    {
        { "euro", 3.38m },  // Курс евро к белорусскому рублю
        { "usd", 3.30m },   // Курс доллара к белорусскому рублю
        { "byn", 1.00m },   
    };
    }
}
