void Solve()
{
    double A = 2;
    double B = 3;

    Vector parallelVector = GetParallelVector(A, B);
    Console.WriteLine("Вектор параллельной прямой: {0}", parallelVector);

    Vector normalVector = GetPerpendicularVector(A, B);
    Console.WriteLine("Вектор перепендикулрный парямой: {0}", normalVector);

    bool isVectorsPerpendicular = IsVectorPerpendicular(parallelVector, normalVector);
    Console.WriteLine("Вектора перпендикулярны?: {0}", isVectorsPerpendicular);

    bool isVectorsParallel = IsVectorsParallel(parallelVector, normalVector);
    Console.WriteLine("Вектора параллельны?: {0}", isVectorsParallel);
}

Vector GetParallerlVector(double a, double b)
{
    if (Math.Abs(a) < double.Epsilon && Math.Abs(b) < double.Epsilon)
    {
        return new Vector(-1, -1);
    }
    return new Vector(b, -a);
}

Vector GetPerpendicularVector(double a, double b)
{
    if (Math.Abs(a) < double.Epsilon && Math.Abs(b) < double.Epsilon)
    {
        return new Vector(-1, -1);
    }
    return new Vector(a, b);
}

bool IsVectorsParallel(Vector v1, Vector v2)
{
    double crossProduct = v1.X * v2.Y - v1.Y * v2.X;
    return Math.Abs(crossProduct) < double.Epsilon;
}

bool IsVectorPerpendicular(Vector v1, Vector v2)
{
    double dotProduct = v1.X * v2.X + v1.Y * v2.Y;
    return Math.Abs(dotProduct) < double.Epsilon;
}

struct Vector
{
    public double x;
    public double y;

    public Vector(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
}