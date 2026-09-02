using System.Globalization;

namespace PayrollConsoleApp
{
    public static class CurrencyFormat
    {
        // Configuración de jornada laboral
        private static readonly CultureInfo Colombia = new("es-CO");


        // FORMATO DE PESO COLOMBIANO
        public static string ColombianCurrencyFormat(decimal value)
        {
            return new string(value.ToString("C2", Colombia));
        }
    }
}