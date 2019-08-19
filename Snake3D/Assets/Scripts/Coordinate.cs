public struct Coordinate
{
	public int row;
	public int column;

	public Coordinate(int _x, int _y)
	{
		row = _x;
		column = _y;
	}

	public static bool operator ==(Coordinate c1, Coordinate c2)
	{
		return c1.row == c2.row && c1.column == c2.column;
	}

	public static bool operator !=(Coordinate c1, Coordinate c2)
	{
		return !(c1 == c2);
	}
}
