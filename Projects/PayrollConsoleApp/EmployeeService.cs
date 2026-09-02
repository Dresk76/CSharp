using System.Globalization;
using Newtonsoft.Json;

namespace PayrollConsoleApp
{
    public static class EmployeeService
    {
        private static readonly CultureInfo Colombia = new("es-CO");


        // Mostrar los datos de un empleado por consola
        public static void PrintEmployee(Employee employee)
        {
            Console.WriteLine($"""
                {"- Id",-55}: {employee.Id}
                {"- Nombre",-55}: {employee.Name}
                {"- Apellido",-55}: {employee.LastName}
                {"- Cédula",-55}: {employee.Identification}
                {"- Cargo",-55}: {employee.JobTitle}
                {"- Salario Base",-55}: {employee.BaseSalary.ToString("C2", Colombia)}
                {"- Días Trabajados",-55}: {employee.WorkedDays}
                {"- Horas Extras Diurnas",-55}: {employee.Overtime.DayHours}
                {"- Horas Extras Nocturnas",-55}: {employee.Overtime.NightHours}
                {"- Horas Extras Diurnas Domingo/Festivo",-55}: {employee.Overtime.HolidayDayHours}
                {"- Horas Extras Nocturnas Domingo/Festivo",-55}: {employee.Overtime.HolidayNightHours}
                {"- Días Domingos/Festivos Trabajados",-55}: {employee.HolidayDaysWorked}
                """);
                Print.PrintLine('-');
        }


        // Validar si el archivo JSON que contiene los empleados existe
        public static bool FileExists(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"El archivo que desea consultar no existe en la ruta '{path}'.\n");
                Print.PrintLine('-');
                return false;
            }
            else
            {
                Console.WriteLine($"Se encontró el archivo '{Path.GetFileName(path)}'.\n");
                Print.PrintLine('-');
                return true;
            }
        }


        // Devuelve una lista de empleados para trabajar con sus valores pasandole el JSON
        public static List<Employee> ReadFile(string path)
        {
            var fileContent = File.ReadAllText(path);

            EmployeeFile? employeeFile = JsonConvert.DeserializeObject<EmployeeFile?>(fileContent);

            if (employeeFile?.Employees == null)
            {
                Console.WriteLine($"El archivo '{Path.GetFileName(path)}' esta vacío.");
                return [];
            }

            return employeeFile.Employees;
        }


        // Muestra la informacion por consola de la lista de empleados asignada
        public static void PrintListEmployees(List<Employee> employeeList)
        {
            foreach (var employee in employeeList)
            {
                PrintEmployee(employee);
            }
        }
    }


    public record EmployeeFile
    {
        public List<Employee>? Employees { get; set; }
    }

}