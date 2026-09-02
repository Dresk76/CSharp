using System.Globalization;

namespace PayrollConsoleApp
{
    public static class AllowanceCalculator
    {
        // Salario Mínimo Colombiano
        private const decimal MinimumWage = 1_750_905;

        // Auxilio de Transporte Colombiano
        private const decimal TransportationAllowance  = 249_095m;


        #region AUXILIO DE TRANSPORTE

        // CALCULAR SI APLICA PARA AUXILIO DE TRANSPORTE
        public static bool IsEligibleForTransportAllowance(decimal baseSalary)
        {
            decimal minimumWageThreshold = MinimumWage * 2m;

            if (baseSalary > minimumWageThreshold) return false;

            return true;
        }

        // MOSTRAR SI APLLICA PARA AUXILIO DE TRANSPORTE
        public static void ShowTransportAllowanceEligibility(bool minimumWageThreshold, bool showSeparator = true)
        {
            string transportAllowanceMessage;
            decimal transportAllowanceAmount;

            if (minimumWageThreshold)
            {
                transportAllowanceMessage = "Aplica para Auxilio de Transporte";
                transportAllowanceAmount = TransportationAllowance;
            }
            else
            {
                transportAllowanceMessage ="No Aplica para Auxilio de Transporte";
                transportAllowanceAmount = 0m;
            }

            Print.ShowMoney(transportAllowanceMessage, transportAllowanceAmount, showSeparator);
        }

        #endregion


        #region AUXILIO DE CONECTIVIDAD

        // CALCULAR VALOR AUXILIO DE CONECTIVIDAD


        // MOSTRAR VALOR AUXILIO DE CONECTIVIDAD

        #endregion
    }
}