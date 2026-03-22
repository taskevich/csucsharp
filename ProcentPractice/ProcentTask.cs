static double Calculate(string userInput)
{
    string[] input = userInput.Split(" ");

    if (input.Length > 3 || input.Length < 3)
    {
        throw new Exception("Количество аргументов должно быть = 3. Пример: 100 12 1");
    }

    int month;
    double contribution, procent;

    if (
        double.TryParse(input[0], out contribution)
        && double.TryParse(input[1], out procent)
        && int.TryParse(input[2], out month)
    )
    {
        return contribution * Math.Pow(1 + procent / (12 * 100), month);
    }
    else
    {
        throw new Exception("Не удалось преобразовать аргументы");
    }
}

string input = Console.ReadLine();
double result = Calculate(input);

Console.WriteLine(result);
