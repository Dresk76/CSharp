using System.Text.Json.Serialization;
using Newtonsoft.Json;
using PayrollConsoleApp;


string fileName = "employees.json";
string path     = Path.Combine(Directory.GetCurrentDirectory(), fileName);


Employee florAgudelo = new(
    id: 1, 
    name: "Flor", 
    lastName: "Agudelo", 
    identification: "30338774",
    jobTitle: "Artista",
    baseSalary: 1_750_905m,
    // baseSalary: 3_501_811m,
    workedDays: 15,
    overtime: new Overtime(2m, 2m, 2m, 2m),
    holidayDaysWorked: 2m
);

/*
! SE DEBE QUITAR EL COMENTARIO AL TERMINAR EL PROGRAMA
*/
// LIMPIAR CONSOLA
// Console.Clear();

// MOSTRAR SALUDO
Initialize.Greeting();

// VALIDAR EXISTENCIA DEL ARCHIVO JSON DE EMPLEADOS
bool fileFound = EmployeeService.FileExists(path);
if (!fileFound) return;



/*
* MOSTRAR CÁCLCULO DE UN EMPLEADO
*/
ShowEmployeeCalculation(florAgudelo);


/*
* MOSTRAR CALCULO DE VARIOS EMPLEADOS
*/
// List<Employee> employees = ListEmployees(path, true);
// EmployeeListHourlyRate(employees);

// VALOR DE LA HORA EXTRA PARA UN EMPLEADO


// VALOR DE LA HORA BASE DE CADA EMPLEADO DE LA LISTA
// RegularHour.ShowListRegularHoursCalculation(employees);

// VALOR DE HORA EXTRA DE CADA EMPLEADO DE LA LISTA
// OvertimeHours.ShowListOvertimeHoursCalculation(employees);



#region EMPLOYEE

// MOSTRAR CÁCLCULO DE UN EMPLEADO
static void ShowEmployeeCalculation(Employee employee)
{
    // EMPLEADO
    Print.PrintText($"INFORMACIÓN DE EMPLEADO: {employee.Name} {employee.LastName}");
    Print.PrintLine('-');

    // DATOS DEL EMPLEADO
    EmployeeService.PrintEmployee(employee);

    // MOSTRAR EL DESGLOSE DE TARIFAS
    ShowRateBreakdown(employee);
}

// MOSTRAR EL DESGLOSE DE TARIFAS
static void ShowRateBreakdown(Employee employee)
{
    Print.PrintText($"DESGLOSE DE TARIFAS");
    Print.PrintLine('-');

    // HORAS HORAS MENSUALES POR LEY
    decimal monthlyWorkedHours = BaseRateCalculator.CalculateMonthlyLegalHours();
    BaseRateCalculator.ShowMonthlyLegalHours(monthlyWorkedHours, false);

    // VALOR DEL DIA
    decimal dailyRate = BaseRateCalculator.CalculateDailyRate(employee.BaseSalary);
    BaseRateCalculator.ShowDailyRate(dailyRate, false);

    // VALOR DE LA HORA REGULAR
    decimal hourlyRate = BaseRateCalculator.CalculateHourlyRate(employee.BaseSalary, monthlyWorkedHours);
    BaseRateCalculator.ShowHourlyRate(hourlyRate, false);

    // VALOR HORA EXTRA DIURNA
    decimal dayOvertimeRate = OvertimeCalculator.CalculateDayOvertimeRate(hourlyRate);
    OvertimeCalculator.ShowDayOvertimeRate(dayOvertimeRate, false);

    // VALOR HORA EXTRA NOCTURNA
    decimal nightOvertimeRate = OvertimeCalculator.CalculateNightOvertimeRate(hourlyRate);
    OvertimeCalculator.ShowNightOvertimeRate(nightOvertimeRate, false);

    // VALOR HORA EXTRA DIURNA DOMINICAL O FESTIVA
    decimal holidayDayOvertimeRate = OvertimeCalculator.CalculateHolidayDayOvertimeRate(hourlyRate);
    OvertimeCalculator.ShowHolidayDayOvertimeRate(holidayDayOvertimeRate, false);

    // VALOR HORA EXTRA NOCTURNA DOMINICAL O FESTIVA
    decimal holidayNightOvertimeRate = OvertimeCalculator.CalculateHolidayNightOvertimeRate(hourlyRate);
    OvertimeCalculator.ShowHolidayNightOvertimeRate(holidayNightOvertimeRate, false);

    // VALOR DIAS DOMINICALES O FESTIVOS TRABAJADOS
    decimal holidayWorkRate = OvertimeCalculator.CalculateHolidayWorkRate(hourlyRate);
    OvertimeCalculator.ShowHolidayWorkRate(holidayWorkRate, false);

    // VALOR DESCUENTO SALUD
    decimal healthDeductionAmount = DeductionCalculator.CalculateHealthDeductionAmount(employee.BaseSalary);
    DeductionCalculator.ShowHealthDeductionAmount(healthDeductionAmount, false);

    // VALOR DESCUENTO PENSIÓN
    decimal pensionDeductionAmount = DeductionCalculator.CalculatePensionDeductionAmount(employee.BaseSalary);
    DeductionCalculator.ShowPensionDeductionAmount(pensionDeductionAmount, false);

    // MOSTRAR SI APLLICA PARA AUXILIO DE TRANSPORTE
    bool isEligibleForTransportAllowance = AllowanceCalculator.IsEligibleForTransportAllowance(employee.BaseSalary);
    AllowanceCalculator.ShowTransportAllowanceEligibility(isEligibleForTransportAllowance);

    /*
    ! ELIMINAR ESTOS 3 PRINT AL DESPLEGAR LA APP
    */
    Print.ShowMoney("Salario Minimimo Mensual", 1_750_905m, false);
    Print.ShowMoney("Salario Minimimo Quincenal", 1_750_905m / 2m, false);
    Print.PrintLine('-');





    // MOSTRAR RESUMEN DE NOMINA
    Print.PrintText($"RESUMEN DE NÓMINA");
    Print.PrintLine('-');

    // HORAS TRABAJADAS
    decimal workedHours = BaseRateCalculator.CalculateWorkedHours(employee.WorkedDays);
    BaseRateCalculator.ShowWorkedHours(workedHours, false);

    // VALOR A PAGAR DEL SALARIO BASE
    decimal bsePay = BaseRateCalculator.CalculateBasePay(dailyRate, employee.WorkedDays);
    BaseRateCalculator.ShowBasePay(bsePay, false);

    // VALOR A PAGAR DE LAS HORAS EXTRAS DIURNAS
    decimal dayOvertimePay = OvertimeCalculator.CalculateDayOvertimePay(employee.Overtime.DayHours, dayOvertimeRate);
    OvertimeCalculator.ShowDayOvertimePay(dayOvertimePay, false);

    // VALOR A PAGAR DE LAS HORAS EXTRAS NOCTURNAS
    decimal nightOvertimePay = OvertimeCalculator.CalculateNightOvertimePay(employee.Overtime.NightHours, nightOvertimeRate);
    OvertimeCalculator.ShowNightOvertimePay(nightOvertimePay, false);

    // VALOR A PAGAR DE LAS HORAS EXTRAS DIURNAS DOMINICALES O FESTIVAS
    decimal holidayDayOvertimePay = OvertimeCalculator.CalculateHolidayDayOvertimePay(employee.Overtime.HolidayDayHours, holidayDayOvertimeRate);
    OvertimeCalculator.ShowHolidayDayOvertimePay(holidayDayOvertimePay, false);

    // VALOR A PAGAR DE LAS HORAS EXTRAS NOCTURNAS DOMINICALES O FESTIVAS
    decimal holidayNightOvertimePay = OvertimeCalculator.CalculateHolidayNightOvertimePay(employee.Overtime.HolidayNightHours, holidayNightOvertimeRate);
    OvertimeCalculator.ShowHolidayNightOvertimePay(holidayNightOvertimePay, false);

    // VALOR A PAGAR DE DIAS DOMINICALES O FESTIVOS TRABAJADOS
    decimal holidayWorkPay = OvertimeCalculator.CalculateHolidayWorkPay(employee.HolidayDaysWorked, holidayWorkRate);
    OvertimeCalculator.ShowHolidayWorkPay(holidayWorkPay, false);
}

#endregion


#region EMPLOYEE LIST

// DEVOLVER Y MOSTRAR LISTA DE EMPLEADOS
// static List<Employee> ListEmployees(string path, bool showEmployees = true)
// {
//     List<Employee> employees = EmployeeService.ReadFile(path);

//     if (showEmployees)
//     {
//         EmployeeService.PrintListEmployees(employees);
//     }

//     return employees;
// }

// // MOSTRAR VALOR DE LA HORA REGULAR DE VARIOS EMPLEADOS
// static void EmployeeListHourlyRate(List<Employee> employees)
// {
//     foreach (var employee in employees)
//     {
//         var hourlyRate = RegularHour.CalculateHourlyRate(employee.BaseSalary);
//         RegularHour.ShowCalculateHourlyRate(employee, hourlyRate, showSeparator: false);
//     }
//     Print.PrintLine('-');
// }


// MOSTRAR VALOR DE LA HORA EXTRA DE VARIOS EMPLEADOS

#endregion