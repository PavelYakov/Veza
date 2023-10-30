using Microsoft.AspNetCore.Mvc;
using VezaApp.Models;


namespace VezaApp.Controllers
{
    [Route("api/currency")]
    [ApiController]
    public class CurrencyCalculatorController : Controller
    {

        [HttpPost("calculate")]
        public IActionResult CalculateCurrency([FromBody] CurrencyCalculationRequest request)
        {
            if (request == null)
            {
                return BadRequest("Пожалуйста, предоставьте данные в формате JSON");
            }

            decimal totalValue = 0;
            foreach (var currencyData in request.Summa)
            {
                string currency = currencyData.Currency;
                decimal value = currencyData.Value;

                if (CurrencyExchangeRates.ExchangeRates.ContainsKey(currency))
                {
                    decimal exchangeRate = CurrencyExchangeRates.ExchangeRates[currency];
                    totalValue += value * exchangeRate;
                }
                else
                {
                    return BadRequest($"Курс обмена для валюты {currency} не найден");
                }
            }

            return Ok(new CurrencyCalculationResult
            {
                Result = totalValue,
                ResultCurrency = request.ResultCurrency
            });
        }

    }
}

