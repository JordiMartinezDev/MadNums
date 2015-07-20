public class NumberPiece
{
	private int row;
	private int column;
	private int pieceNum;
	private int name;

	public NumberPiece ()
	{
		row = column = pieceNum = name = 0;
	}

	public NumberPiece (int value)
	{
		row = column = pieceNum = name = value;
	}

	public override string ToString()
	{
		string returnValue = "";

		if(name < 10) { returnValue += " "; }

		returnValue += name;

		return returnValue;
	}

	public void SetValues(int _row, int _column, int _pieceNum)
	{
		row = _row;
		column = _column;
		pieceNum = _pieceNum;
		name = (row * 4) + column;
	}

	public int GetNum() { return pieceNum; }

	// el operador no es correcto :(
	//public static int operator + (NumberPiece other) { return pieceNum + other.GetNum(); }
	
}