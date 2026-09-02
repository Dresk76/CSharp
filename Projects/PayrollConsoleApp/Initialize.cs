namespace PayrollConsoleApp
{
    /*
* NOTAS O INFORMACION IMPORTANTE
EJEMPLO
* RECUERDA ACTUALIZAR EL ARCHIVO JSON


! ALERTAS CRITICAS O CODOGO OBSOLETO
EJEMPLO
! ESTE METODO SERA ELIMINADO PRONTO


? PREGUNTAS O DUDAS
EJEMPLO
? SE NECESITA MANEJAR UNA EXCEPCION AQUI


TODO: TAREAS PENDIENTES
EJEMPLO
TODO: OPTIMIZAR EL RENDIMIENTO DEL METODO
*/

    public static class Initialize
    {
        public static void Greeting()
        {
            string  title       = "BIENVENIDO A LA APP";
            string  subTitle    = "CONSOLA DE NÓMINA";
            char    doubleLine  = '='; 

            Print.PrintLine(doubleLine);
            Print.PrintText(title);
            Print.PrintText(subTitle);
            Print.PrintLine(doubleLine, space: true);
        }
    }
}