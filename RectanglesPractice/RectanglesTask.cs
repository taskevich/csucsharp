using System;

namespace Rectangles;

public static class RectanglesTask
{
    // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
    public static bool AreIntersected(Rectangle r1, Rectangle r2)
    {
        // так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
        return (r1.Left > r2.Left + r2.Width || r2.Left > r1.Left + r1.Width ||
            r1.Top > r2.Top + r2.Height || r2.Top > r1.Top + r1.Height) ? false : true;
    }

    // Площадь пересечения прямоугольников
    public static int IntersectionSquare(Rectangle r1, Rectangle r2)
    {
        if (!AreIntersected(r1, r2))
        {
            return 0;            
        }

        int left = r1.Left > r2.Left ? r1.Left : r2.Left;
        int right = (r1.Left + r1.Width) < (r2.Left + r2.Width) ? (r1.Left + r1.Width) : (r2.Left + r2.Width);

        int top = r1.Top > r2.Top ? r1.Top : r2.Top;
        int bottom = (r1.Top + r1.Height) < (r2.Top + r2.Height) ? (r1.Top + r1.Height) : (r2.Top + r2.Height);

        return (right - left) * (bottom - top);
    }

    // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
    // Иначе вернуть -1
    // Если прямоугольники совпадают, можно вернуть номер любого из них.
    public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
    {
        bool r1InsideR2 = r1.Left >= r2.Left && r1.Left + r1.Width <= r2.Left + r2.Width &&
                       r1.Top >= r2.Top && r1.Top + r1.Height <= r2.Top + r2.Height;

        bool r2InsideR1 = r2.Left >= r1.Left && r2.Left + r2.Width <= r1.Left + r1.Width &&
                        r2.Top >= r1.Top && r2.Top + r2.Height <= r1.Top + r1.Height;

        if (r1InsideR2)
        {
            return 0;
        }

        if (r2InsideR1)
        { 
            return 1;
        }

        return -1;
    }
}