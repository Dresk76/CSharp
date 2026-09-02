Console.WriteLine("Hello World!");

Console.Write("Escribe tu nombre: ");
string? name = Console.ReadLine();

if (string.IsNullOrWhiteSpace(name))
{
    name = "Invitado";
}

Console.WriteLine($"Hola, {name}! Bienvenido al programa.");