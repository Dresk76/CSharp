using System.Globalization;

namespace PayrollConsoleApp
{
    public static class DeductionCalculator
    {
        // Tasas de Descuento
        private const decimal HealthDeductionRate = 0.04m;
        private const decimal PensionDeductionRate = 0.04m;


        #region DESCUENTO SALUD 4%

        // CALCULAR VALOR DESCUENTO SALUD
        public static decimal CalculateHealthDeductionAmount(decimal baseSalary)
        {
            decimal healthDeductionAmount = baseSalary * HealthDeductionRate;
            return Math.Round(healthDeductionAmount, 2, MidpointRounding.AwayFromZero);
        }

        // MOSTRAR VALOR DESCUENTO SALUD
        public static void ShowHealthDeductionAmount(decimal healthDeductionAmount, bool showSeparator = true)
        {
            Print.ShowMoney("Valor Descuento Salud (4%)", healthDeductionAmount, showSeparator);
        }

        #endregion


        #region DESCUENTO PENSIÓN 4%

        // CALCULAR VALOR DESCUENTO PENSIÓN
        public static decimal CalculatePensionDeductionAmount(decimal baseSalary)
        {
            decimal pensionDeductionAmount = baseSalary * PensionDeductionRate;
            return Math.Round(pensionDeductionAmount, 2, MidpointRounding.AwayFromZero);
        }

        // MOSTRAR VALOR DESCUENTO PENSIÓN
        public static void ShowPensionDeductionAmount(decimal pensionDeductionAmount, bool showSeparator = true)
        {
            Print.ShowMoney("Valor Descuento Pensión (4%)", pensionDeductionAmount, showSeparator);
        }

        #endregion
    }
}