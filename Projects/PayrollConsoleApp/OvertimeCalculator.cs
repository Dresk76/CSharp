using System.Globalization;

namespace PayrollConsoleApp
{
    public static class OvertimeCalculator
    {
        // Multiplicadores
        private const decimal DayOvertimeMultiplier = 1.25m;
        private const decimal NightOvertimeMultiplier = 1.75m;
        private const decimal HolidayDayOvertimeMultiplier = 2.15m;
        private const decimal HolidayNightOvertimeMultiplier = 2.65m;
        private const decimal HolidayWorkMultiplier = 1.90m;


        #region HORA EXTRA DIURNA 25%

        // CALCULAR VALOR HORA EXTRA DIURNA
        public static decimal CalculateDayOvertimeRate(decimal hourlyRate)
        {
            decimal dayOvertimeRate = hourlyRate * DayOvertimeMultiplier;
            return Math.Round(dayOvertimeRate, 2, MidpointRounding.AwayFromZero);
        }

        // MOSTRAR VALOR HORA EXTRA DIURNA
        public static void ShowDayOvertimeRate(decimal dayOvertimeRate, bool showSeparator = true)
        {
            Print.ShowMoney("Valor Hora Extra Diurna (25%)", dayOvertimeRate, showSeparator);
        }

        // CALCULAR VALOR A PAGAR DE LAS HORAS EXTRAS DIURNAS
        public static decimal CalculateDayOvertimePay(decimal dayOvertimeHours, decimal dayOvertimeRate)
        {
            decimal dayOvertimePay = dayOvertimeHours * dayOvertimeRate;
            return Math.Round(dayOvertimePay, 2, MidpointRounding.AwayFromZero);
        }

        // MOSTRAR VALOR A PAGAR DE LAS HORAS EXTRAS DIURNAS
        public static void ShowDayOvertimePay(decimal dayOvertimePay, bool showSeparator = true)
        {
            Print.ShowMoney("Valor Horas Extras Diurnas", dayOvertimePay, showSeparator);
        }

        #endregion



        #region HORA EXTRA NOCTURNA 75%

        // CALCULAR VALOR HORA EXTRA NOCTURNA
        public static decimal CalculateNightOvertimeRate(decimal hourlyRate)
        {
            decimal nightOvertimeRate = hourlyRate * NightOvertimeMultiplier;
            return Math.Round(nightOvertimeRate, 2, MidpointRounding.AwayFromZero);
        }

        // MOSTRAR VALOR HORA EXTRA NOCTURNA
        public static void ShowNightOvertimeRate(decimal nightOvertimeRate, bool showSeparator = true)
        {
            Print.ShowMoney("Valor Hora Extra Nocturna (75%)", nightOvertimeRate, showSeparator);
        }

        // CALCULAR VALOR A PAGAR DE LAS HORAS EXTRAS NOCTURNAS
        public static decimal CalculateNightOvertimePay(decimal nightOvertimeHours, decimal nightOvertimeRate)
        {
            decimal nightOvertimePay = nightOvertimeHours * nightOvertimeRate;
            return Math.Round(nightOvertimePay, 2, MidpointRounding.AwayFromZero);
        }

        // MOSTRAR VALOR A PAGAR DE LAS HORAS EXTRAS NOCTURNAS
        public static void ShowNightOvertimePay(decimal nightOvertimePay, bool showSeparator = true)
        {
            Print.ShowMoney("Valor Horas Extras Nocturnas", nightOvertimePay, showSeparator);
        }

        #endregion



        #region HORA EXTRA DIURNA DOMINICAL O FESTIVA 115%

        // CALCULAR VALOR HORA EXTRA DIURNA DOMINICAL O FESTIVA
        public static decimal CalculateHolidayDayOvertimeRate(decimal hourlyRate)
        {
            decimal holidayDayOvertimeRate = hourlyRate * HolidayDayOvertimeMultiplier;
            return Math.Round(holidayDayOvertimeRate, 2, MidpointRounding.AwayFromZero);
        }

        // MOSTRAR VALOR HORA EXTRA DIURNA DOMINICAL O FESTIVA
        public static void ShowHolidayDayOvertimeRate(decimal holidayDayOvertimeRate, bool showSeparator = true)
        {
            Print.ShowMoney("Valor Hora Extra Diurna Dominical o Festiva (115%)", holidayDayOvertimeRate, showSeparator);
        }

        // CALCULAR VALOR A PAGAR DE LAS HORAS EXTRAS DIURNAS DOMINICALES O FESTIVAS
        public static decimal CalculateHolidayDayOvertimePay(decimal holidayDayOvertimeHours, decimal holidayDayOvertimeRate)
        {
            decimal holidayDayOvertimePay = holidayDayOvertimeHours * holidayDayOvertimeRate;
            return Math.Round(holidayDayOvertimePay, 2, MidpointRounding.AwayFromZero);
        }

        // MOSTRAR VALOR A PAGAR DE LAS HORAS EXTRAS DIURNAS DOMINICALES O FESTIVAS
        public static void ShowHolidayDayOvertimePay(decimal holidayDayOvertimePay, bool showSeparator = true)
        {
            Print.ShowMoney("Valor Horas Extras Diurnas Dominicales o Festivas", holidayDayOvertimePay, showSeparator);
        }

        #endregion



        #region HORA EXTRA NOCTUNRA DOMINICAL O FESTIVA 165%

        // CALCULAR VALOR HORA EXTRA NOCTURNA DOMINICAL O FESTIVA
        public static decimal CalculateHolidayNightOvertimeRate(decimal hourlyRate)
        {
            decimal holidayNightOvertimeRate = hourlyRate * HolidayNightOvertimeMultiplier;
            return Math.Round(holidayNightOvertimeRate, 2, MidpointRounding.AwayFromZero);
        }

        // MOSTRAR VALOR HORA EXTRA NOCTURNA DOMINICAL O FESTIVA
        public static void ShowHolidayNightOvertimeRate(decimal holidayNightOvertimeRate, bool showSeparator = true)
        {
            Print.ShowMoney("Valor Hora Extra Nocturna Dominical o Festiva (165%)", holidayNightOvertimeRate, showSeparator);
        }

        // CALCULAR VALOR A PAGAR DE LAS HORAS EXTRAS NOCTURNAS DOMINICALES O FESTIVAS
        public static decimal CalculateHolidayNightOvertimePay(decimal holidayNightOvertimeHours, decimal holidayNightOvertimeRate)
        {
            decimal holidayNightOvertimePay = holidayNightOvertimeHours * holidayNightOvertimeRate;
            return Math.Round(holidayNightOvertimePay, 2, MidpointRounding.AwayFromZero);
        }

        // MOSTRAR VALOR A PAGAR DE LAS HORAS EXTRAS NOCTURNAS DOMINICALES O FESTIVAS
        public static void ShowHolidayNightOvertimePay(decimal holidayNightOvertimePay, bool showSeparator = true)
        {
            Print.ShowMoney("Valor Horas Extras Nocturnas Dominicales o Festivas", holidayNightOvertimePay, showSeparator);
        }

        #endregion



        #region DIAS DOMINICALES O FESTIVOS TRABAJADOS 90%

        // CALCULAR VALOR DIA DOMINICAL O FESTIVO TRABAJADO
        public static decimal CalculateHolidayWorkRate(decimal hourlyRate)
        {
            decimal holidayWorkRate = hourlyRate * HolidayWorkMultiplier;
            return Math.Round(holidayWorkRate, 2, MidpointRounding.AwayFromZero);
        }

        // MOSTRAR VALOR DIA DOMINICAL O FESTIVO TRABAJADO
        public static void ShowHolidayWorkRate(decimal holidayWorkRate, bool showSeparator = true)
        {
            Print.ShowMoney("Valor Día Dominical o Festivo (90%)", holidayWorkRate, showSeparator);
        }

        // CALCULAR VALOR A PAGAR DE DIAS DOMINICALES O FESTIVOS TRABAJADOS
        public static decimal CalculateHolidayWorkPay(decimal holidayWorkDay, decimal holidayWorkRate)
        {
            decimal holidayWorkPay = holidayWorkDay * holidayWorkRate;
            return Math.Round(holidayWorkPay, 2, MidpointRounding.AwayFromZero);
        }

        // MOSTRAR VALOR A PAGAR DE DIAS DOMINICALES O FESTIVOS TRABAJADOS
        public static void ShowHolidayWorkPay(decimal holidayWorkPay, bool showSeparator = true)
        {
            Print.ShowMoney("Valor Días Dominicales o Festivos Trabajados", holidayWorkPay, showSeparator);
        }

        #endregion
    }
}