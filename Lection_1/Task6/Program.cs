Point a = new Point(10, 20);
Point b = new Point(30, 40);
Point c = new Point(50, 30);

double resultDistance = DistanceToLine(a, b, c);
Console.WriteLine("Дистанция = {0}", resultDistance);

double DistanceToLine(Point a, Point b, Point c)
{
    double abX = b.x - a.x;
    double abY = b.y - a.y;

    double apX = c.x - a.x;
    double apY = c.y - a.y;

    double crossProduct = Math.Abs(abX * apY - abY * apX);

    double lengthAB = Math.Sqrt(abX * abX + abY * abY);

    if (lengthAB < double.Epsilon)
    {
        double dx = c.x - a.x;
        double dy = c.y - a.y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    double distance = crossProduct / lengthAB;

    return distance;
}

struct Point
{
    public double x;
    public double y;

    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
};
