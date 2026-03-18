int ReverseOne(int value)
{
    return int.Parse(new string(value.ToString().Reverse().ToArray()));
}

int ReverseTwo(int value)
{
    int result = 0;
    while (value > 0)
    {
        var temp = value % 10;
        result = (result * 10) + temp;
        value = value / 10;
    }
    return result;
}

int ParseInput()
{
    Console.Write("Введите число из 3 символов: ");
    string input = Console.ReadLine();
    input = input.Replace(" ", "");
    
    if (input.Length != 3)
    {
        return -1;
    }

    if (!int.TryParse(input, out int value))
    {
        return -1;
    }

    return value;
}

int input = ParseInput();

if (input != -1)
{
    Console.WriteLine(ReverseOne(input));
    Console.WriteLine(ReverseTwo(input));
}
else
{
    Console.WriteLine("Некорректные входные данные");
}