using System;

namespace Mazes;

public static class SnakeMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        int horizontal = width - 3;
        while (!robot.Finished)
        {
            Move(robot, horizontal, Direction.Right);
            Move(robot, 2, Direction.Down);
            Move(robot, horizontal, Direction.Left);
            Move(robot, 2, Direction.Down);
        }
    }

    public static void Move(Robot robot, int steps, Direction direction)
    {
        for (int i = 0; i < steps; i++)
        {
            if (robot.Finished)
            {
                break;
            }
            robot.MoveTo(direction);
        }
    }
}