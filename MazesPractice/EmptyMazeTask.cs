using System;

namespace Mazes;

public static class EmptyMazeTask
{
	public static void MoveOut(Robot robot, int width, int height)
	{
		Move(robot, width - 3, Direction.Right);
		Move(robot, height - 3, Direction.Down);
	}

	private static void Move(Robot robot, int steps, Direction direction)
	{
		for (int i = 0; i < steps && !robot.Finished; i++)
		{
			robot.MoveTo(direction);
		}
	}
}