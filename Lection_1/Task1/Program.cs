void SwapOne<T>(T a, T b)
{
    (a, b) = (b, a);
    Console.WriteLine("a={0}; b={1}", a, b);
}

SwapOne<int>(1, 2);
SwapOne<string>("Hello", "World");