namespace PayrollConsoleApp
{
    public static class Print
    {
        private const int AmountDecoration = 2;


        #region CENTER
        
        // CENTRA UN TEXTO EN LA CONSOLA
        private static string CenterText(string text)
        {
            int spaces = (Console.WindowWidth - text.Length) / 2;

            var decoration = CreateCharacters('-', AmountDecoration);
            var padding = CreateCharacters(' ', spaces - AmountDecoration);

            if (spaces <= 0)
            {
                return text;
            }

            return decoration + padding + text + padding + decoration;
        }


        // CENTRA UNA LINEA DE CHARACTERS EN LA CONSOLA
        private static string CenterLine(char character)
        {
            int width = Console.WindowWidth;
            var line = CreateCharacters(character, width);

            return line;
        }

        #endregion


        # region PRINT
        
        // IMPRIME UNA CANTIDAD DE CHARACTERS EN LA CONSOLA
        private static string CreateCharacters(char character, int value)
        {
            return new string(character, Math.Max(0, value));
        }

        // IMPRIME UN TEXTO CENTRADO EN LA CONSOLA
        public static void PrintText(string text)
        {
            Console.WriteLine(CenterText(text));
        }


        // IMPRIME UNA LINEA DE CHARACTERS CENTRADOS EN LA CONSOLA
        public static void PrintLine(char character, bool space = false)
        {


            Console.WriteLine(space ? CenterLine(character) + Environment.NewLine 
                                    : CenterLine(character));
        }

        // MOSTRAR LOS CÁLCULOS REALIZADOS CON FORMATO MONEDA
        public static void ShowMoney(string message, decimal value, bool showSeparator)
        {
            var currencyFormat = CurrencyFormat.ColombianCurrencyFormat(value);

            Console.WriteLine($"- {message,-55}: {currencyFormat}");
            
            if (!showSeparator) return;

            PrintLine('-');
        }

        // MOSTRAR LOS CÁLCULOS REALIZADOS CON FORMATO HORA
        public static void ShowHour(string message, decimal hours, bool showSeparator)
        {
            Console.WriteLine($"- {message,-55}: {hours:0.##}");
            
            if (!showSeparator) return;

            PrintLine('-');
        }
        
        #endregion
    }
}