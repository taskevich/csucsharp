int Solve(int hours)
{
    int angle = Math.Abs(30 * (hours % 12));
    angle = Math.Min(angle, 360 - angle);
    return angle;
}

int hours;

Console.Write("Введите часы: ");
string input = Console.ReadLine();

if (int.TryParse(input, out hours))
{
    int result = Solve(hours);
    Console.WriteLine("Angle={0}", result);
}
else
{
    Console.WriteLine("Неверно введенное число");
}
