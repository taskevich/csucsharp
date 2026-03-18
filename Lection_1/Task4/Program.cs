int Gcd(int a, int b)
{
    while (b != 0)
    {
        int t = b;
        b = a % b;
        a = t;
    }
    return a;
}

int Solve(int n, int x, int y)
{
    int lcm = x * y / Gcd(x, y);
    int count = (n - 1) / x + (n - 1) / y - (n - 1) / lcm;
    return count;
}

int n, x, y;

Console.Write("Введите количество меньших: ");
string inputN = Console.ReadLine();

Console.Write("Введите простой делитель X: ");
string inputX = Console.ReadLine();

Console.Write("Введите простой делитель Y: ");
string inputY = Console.ReadLine();

bool okN = int.TryParse(inputN, out n);
bool okX = int.TryParse(inputX, out x);
bool okY = int.TryParse(inputY, out y);

if (okN && okX && okY)
{
    int result = Solve(n, x, y);
    Console.WriteLine("Количество меньших = {0}", result);
}
else
{
    Console.WriteLine("Не удалось распарсить одно из чисел");
}