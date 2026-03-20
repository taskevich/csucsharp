void Solve()
{
    double a, b, c;
    double x = 0, y = 0;

    Console.WriteLine("Ведите коэффициенты прямой Ax + By + C = 0.");
    
    Console.Write("Ax=");
    string inputA = Console.ReadLine();

    Console.Write("By=");
    string inputB = Console.ReadLine();

    Console.Write("C=");
    string inputC = Console.ReadLine();

    Console.WriteLine("Введите точки x, y.");

    Console.Write("X=");
    string inputX = Console.ReadLine();

    Console.Write("Y=");
    string inputY = Console.ReadLine();

    bool okA = double.TryParse(inputA, out a);
    bool okB = double.TryParse(inputB, out b);
    bool okC = double.TryParse(inputC, out c);
    bool okX = double.TryParse(inputX, out x);
    bool okY = double.TryParse(inputY, out y);

    if (okA && okB && okC && okX && okY)
    {
        double t = (a * x + b * y + c) / (a * a + b * b);
        x = x - a * t;
        y = y - b * t;
        Console.WriteLine("Точка пересечения x={0}, y={1}", x, y);
    }
    else
    {
        throw new Exception("Некорректно введены коэффициенты.");
    }
}

Solve();