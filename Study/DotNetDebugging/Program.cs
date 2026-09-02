using System.Diagnostics;

int value = 6;
int result = Fibonacci(value);
Console.WriteLine($"El resultado de Fibonacci({value}) = {result}");


static int Fibonacci(int n)
{
    Debug.WriteLine($"Debug.WriteLine | Ingresando al método {nameof(Fibonacci)}");
    Debug.WriteLine($"Debug.WriteLine | Estamos buscando el número {n}");

    int n1 = 0;
    int n2 = 1;
    int sum;

    for (int i = 2; i <= n; i++)
    {
        sum = n1 + n2;
        n1 = n2;
        n2 = sum;
        Debug.WriteLineIf(sum == 1, $"Debug.WriteLine | sum es 1, n1 es {n1}, n2 es {n2}");

        Console.WriteLine($"Console.WriteLine | Fibonacci({i}) = {sum} ({n2 - n1} + {n1})");
    }

    // If n2 is 5 continue, else break.
    Debug.Assert(n2 == 5, "Debug.Assert | El valor de retorno no es 5, y debería serlo.");

    return n == 0 ? n1 : n2;
}