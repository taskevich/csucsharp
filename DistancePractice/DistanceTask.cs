using System;

namespace DistanceTask;

public static class DistanceTask
{
    // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
    public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
    {
        double dx = bx - ax;
        double dy = by - ay;
        double lengthAB = dx * dx + dy * dy;  // Расстояние от A до B
        
        if (lengthAB == 0.0)
        {
            // Если оказываемся здесь, то
            // отрезок == точке и это просто
            // расстояние до A
            return Math.Sqrt((x - ax) * (x - ax) + (y - ay) * (y - ay));
        }

        // Вычисление проекции точки на отрезок
        double t = ((x - ax) * dx + (y - ay) * dy) / lengthAB;
        t = t < 0 ? 0 : (t > 1 ? 1 : t);

        // Блзккя точка на отрезке
        double closeX = ax + t * dx;
        double closeY = ay + t * dy;

        // Расстяние до точки
        double distX = x - closeX;
        double distY = y - closeY;

        return Math.Sqrt(distX * distX + distY * distY);
    }
}