using System;

namespace DistanceTask;

public static class DistanceTask
{
    // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
    public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
    {
        // Раз длинный блок...
        double dx = bx - ax, dy = by - ay;
        double t = dx * dx + dy * dy == 0 ? 0 : ((x - ax) * dx + (y - ay) * dy) / (dx * dx + dy * dy);
        t = Math.Max(0, Math.Min(1, t));
        double cx = ax + t * dx, cy = ay + t * dy;
        return Math.Sqrt((x - cx) * (x - cx) + (y - cy) * (y - cy));
    }
}