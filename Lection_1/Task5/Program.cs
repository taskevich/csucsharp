int LeapCount(int x)
{
    return x / 4 - x / 100 + x / 400;
}

int Solve(int a, int b)
{
    return LeapCount(b) - LeapCount(a - 1);
}

int a, b;

Console.Write("Введите A: ");
string inputA = Console.ReadLine();

Console.Write("Введите B: ");
string inputB = Console.ReadLine();

if (int.TryParse(inputA, out a) && int.TryParse(inputB, out b))
{
    int result = Solve(a, b);
    Console.WriteLine("Количество високосных лет на отерзке равно = {0}", result);
}
