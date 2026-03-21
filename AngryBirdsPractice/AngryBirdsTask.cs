using System;

namespace AngryBirds;

public static class AngryBirdsTask
{
    static double g = 9.8;

    public static double FindSightAngle(double v, double distance)
    {
        double value = g * distance / (v * v);

        if (value > 1 || value < -1)
        {
            return double.NaN;
        }

        return 0.5 * Math.Asin(value);
    }
}