namespace Mazes;

public static class DiagonalMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        int steps = GetSteps(width, height);
        var (main, side) = GetDirections(width, height);
        while (!robot.Finished)
        {
            StartMove(robot, steps, main, side);
        }
    }

    public static void StartMove(Robot robot, int steps, Direction main, Direction side)
    {
        Move(robot, steps, main);
        if (robot.Finished)
        {
            return;
        }
        robot.MoveTo(side);
    }

    private static (Direction main, Direction side) GetDirections(int width, int height)
    {
        return width >= height
            ? (Direction.Right, Direction.Down)
            : (Direction.Down, Direction.Right);
    }

    public static int GetSteps(int width, int height)
    {
        int w = width - 2;
        int h = height - 2;
        int steps = w >= h ? w / h : h / w;
        return steps;
    }

    public static void Move(Robot robot, int steps, Direction direction)
    {
        for (int i = 0; i < steps && !robot.Finished; i++)
        {
            robot.MoveTo(direction);
        }
    }
}