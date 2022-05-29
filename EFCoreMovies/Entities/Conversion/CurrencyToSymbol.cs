using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace EFCoreMovies.Entities.Conversion
{
    public class CurrencyToSymbol : ValueConverter<Currency, string>
    {
        public CurrencyToSymbol() : base(s => MapToString(s), c => MapToCurrency(c)) { }

        private static string MapToString(Currency currency)
        {
            return currency switch
            {
                Currency.GBP => "₤",
                Currency.USD => "$",
                Currency.Euro => "€",
                Currency.TRL => "₺",
                _ => string.Empty
            };
        }

        private static Currency MapToCurrency(string symbol)
        {
            return symbol switch
            {
                "₤" => Currency.GBP,
                "$" => Currency.USD,
                "€" => Currency.Euro,
                "₺" => Currency.TRL,
                _ => Currency.Unknown
            };
        }
    }
}
