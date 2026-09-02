using System.Globalization;

namespace PayrollConsoleApp
{
    public static class BaseRateCalculator
    {
        // Parámetros de Jornada Laboral
        private const int DaysPerMonth = 30;
        private const int DaysPerBiweekly = 15;
        private const int WorkDaysPerWeek = 6;
        private const decimal WeeklyWorkHours = 42m;


        #region HORAS MENSUALES POR LEY

        // CALCULAR HORAS MENSUALES POR LEY
        public static decimal CalculateMonthlyLegalHours()
        {
            decimal monthlyWorkedHours = (WeeklyWorkHours / WorkDaysPerWeek) * DaysPerMonth;
            return monthlyWorkedHours;
        }

        // MOSTRAR HORAS MENSUALES POR LEY
        public static void ShowMonthlyLegalHours(decimal monthlyWorkedHours, bool showSeparator = true)
        {
            Print.ShowHour("Horas Mes por Ley", monthlyWorkedHours, showSeparator);
        }

        #endregion



        #region HORAS TRABAJADAS

        // CALCULAR LAS HORAS TRABAJADAS
        public static decimal CalculateWorkedHours(decimal workedDays)
        {
            decimal workedHours = (WeeklyWorkHours / WorkDaysPerWeek) * workedDays;
            return workedHours;
        }

        // MOSTRAR LAS HORAS TRABAJADAS
        public static void ShowWorkedHours(decimal workedHours, bool showSeparator = true)
        {
            Print.ShowHour("Horas Trabajadas", workedHours, showSeparator);
        }

        #endregion



        #region VALOR DEL DIA

        // CALCULAR VALOR DEL DIA
        public static decimal CalculateDailyRate(decimal baseSalary)
        {
            decimal dailyRate = baseSalary / DaysPerMonth;
            return Math.Round(dailyRate, 2, MidpointRounding.AwayFromZero);
        }

        // MOSTRAR VALOR DEL DIA
        public static void ShowDailyRate(decimal dailyRate, bool showSeparator = true)
        {
            Print.ShowMoney("Valor Día", dailyRate, showSeparator);
        }

        #endregion



        #region VALOR DE LA HORA REGULAR

        // CALCULAR VALOR DE LA HORA REGULAR
        public static decimal CalculateHourlyRate(decimal baseSalary, decimal monthlyWorkedHours)
        {
            decimal hourlyRate = baseSalary / monthlyWorkedHours;
            return Math.Round(hourlyRate, MidpointRounding.AwayFromZero);
        }

        // MOSTRA VALOR DE LA HORA REGULAR
        public static void ShowHourlyRate(decimal hourlyRate, bool showSeparator = true)
        {
            Print.ShowMoney("Valor Hora", hourlyRate, showSeparator);
        }

        #endregion



        #region VALOR A PAGAR DEL SALARIO BASE

        /*
        ! ELIMINAR ESTE METODO AL HACER VALIDACIONES DE SI SOLO SE USA EL SALARIO BASE
        */
        public static bool IsWithinBiweeklyDaysLimit(int workedDays)
        {
            return workedDays <= DaysPerBiweekly;
        }

        // CALCULAR VALOR A PAGAR DEL SALARIO BASE
        public static decimal CalculateBasePay(decimal dailyRate, int workedDays)
        {
            /*
            ! ELIMINAR ESTE LINEA AL HACER VALIDACIONES DE SI SOLO SE USA EL SALARIO BASE
            */
            // if (isWithinBiweeklyDaysLimit)

            decimal biweeklyBasePay = dailyRate * workedDays;
            return Math.Round(biweeklyBasePay, 2, MidpointRounding.AwayFromZero);
        }

        // MOSTRAR VALOR A PAGAR DEL SALARIO BASE
        public static void ShowBasePay(decimal biweeklyBasePay, bool showSeparator = true)
        {
            Print.ShowMoney("Salario Base", biweeklyBasePay, showSeparator);
        }

        #endregion
    }
}