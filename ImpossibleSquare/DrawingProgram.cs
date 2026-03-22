using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class SquarePainter
    {
        private float x;
        private float y;
        private IGraphics newGraphics;
        private Pen pen;

        public SquarePainter(IGraphics newGraphics, Pen pen)
        {
            this.newGraphics = newGraphics;
            this.pen = pen;
            this.newGraphics.Clear(Colors.Black);
        }

        public void SetPosition(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public void DrawSide(double length, double angle)
        {
            // Делает шаг длиной length в направлении angle и рисует пройденную траекторию
            float x1 = (float)(x + length * Math.Cos(angle));
            float y1 = (float)(y + length * Math.Sin(angle));
            this.newGraphics.DrawLine(this.pen, x, y, x1, y1);

            x = x1;
            y = y1;
        }

        public void Move(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle)); 
            y = (float)(y + length * Math.Sin(angle));
        }
    }
    
    public class ImpossibleSquare
    {
        private static float mainSize = 0.0f;
        private static float minorSize = 0.0f;

        private const float MainPart = 0.375f;
        private const float MinorPart = 0.04f;

        public static void Draw(int width, int height, double turningAngle, IGraphics newGraphics)
        {
            int size = Math.Min(width, height);
            mainSize = size * MainPart;
            minorSize = size * MinorPart;
            double diagonalLength = Math.Sqrt(2) * (mainSize + size * 0.04f) / 2;

            float xPos = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            float yPos = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Pen pen = new Pen(Brushes.Yellow);
            SquarePainter squarePainter = new SquarePainter(newGraphics, pen);
            squarePainter.SetPosition(xPos, yPos);

            DrawSquareSide(squarePainter, 0);           
            DrawSquareSide(squarePainter, -Math.PI / 2);
            DrawSquareSide(squarePainter, Math.PI);     
            DrawSquareSide(squarePainter, Math.PI / 2); 
        }

        private static void DrawSquareSide(SquarePainter squarePainter, double baseAngle)
        {
            squarePainter.DrawSide(mainSize, baseAngle);
            squarePainter.DrawSide(minorSize * Math.Sqrt(2), baseAngle + Math.PI / 4);
            squarePainter.DrawSide(mainSize, baseAngle + Math.PI);
            squarePainter.DrawSide(mainSize - minorSize, baseAngle + Math.PI / 2);

            squarePainter.Move(minorSize, baseAngle - Math.PI);
            squarePainter.Move(minorSize * Math.Sqrt(2), baseAngle + 3 * Math.PI / 4);
        }
    }
}