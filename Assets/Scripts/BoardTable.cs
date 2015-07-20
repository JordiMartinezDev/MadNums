public class BoardTable
{
	private int[] initialArrangement;
	public NumberPiece[] nums;
	public bool[] walls;
	private bool[] unions;
	
	public BoardTable()
	{
		initialArrangement = new int[16];
		nums = new NumberPiece[16];
		walls = new bool[24];
		unions = new bool[9];

		//for (int i = 0; i < 16; i++) {   nums[i].Init(); initialArrangement[i] = 0; }

		for (int i = 0; i < 16; i++) {initialArrangement[i] = 0; }
		for (int i = 0; i < 16; i++) {   nums[i] = new NumberPiece(); }

		for (int i = 0; i < 24; i++) {  walls[i] = false; }
		for (int i = 0; i < 9; i++)  { unions[i] = false; }
	}
	
	public void SetNewTable(int[] numbers, bool[] _walls, bool[] _unions)
	{
		for (int i = 0; i < 16; i++)
		{
			nums[i].SetValues(i / 4, i % 4, numbers[i]);
			initialArrangement[i] = numbers[i];
		}

		walls = _walls;
		unions = _unions;
	}
	
	public void SetTableToEmpty()
	{
		for (int i = 0; i < 16; i++) { nums[i].SetValues(i / 4, i % 4, 0); }
	}
	
	public void ResetTable()
	{
		for (int i = 0; i < 16; i++) { nums[i].SetValues(i / 4, i % 4, initialArrangement[i]); }
	}
	
	public void SWAP(int piece_1, int piece_2)
	{
		NumberPiece tmp = nums [piece_1];
		nums [piece_1] = nums [piece_2];
		nums [piece_2] = tmp;
	}
	
	public bool CheckWin()
	{
		for (int i = 0; i < 4; i++)
		{
			if(nums[i * 4].GetNum() + nums[(i * 4) + 1].GetNum() + nums[(i * 4) + 2].GetNum() + nums[(i * 4) + 3].GetNum() != 10
			   || nums[i].GetNum() + nums[i + 4].GetNum() + nums[i + 8].GetNum() + nums[i + 12].GetNum() != 10)
			{
				return false;
			}
		}
		
		return true;
	}
	
	public override string ToString()
	{
		string returnValue = " ";
		
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				returnValue += nums[(i * 4) + j] + " ";

				if (j != 3)
				{
					if (walls[(i * 3) + j]) { returnValue += "|"; }
				}

				returnValue += " ";
			}

			returnValue += "\t";

			for (int j = 0; j < 4; j++)
			{
				returnValue += " " + nums[(i * 4) + j].GetNum() + " ";
				
				if (j != 3)
				{
					if (walls[(i * 3) + j]) { returnValue += "|"; }
				}
				
				returnValue += " ";
			}

			if (i != 3)
			{
				returnValue += "\n ";

				for (int j = 0; j < 4; j++)
				{
					returnValue += (walls[(i * 4) + j + 12]? "--" : "  ");
					
					if (j != 3 && i != 3)
					{
						returnValue += (unions[(i * 3) + j]? " · " : "   ");
					}
				}

				returnValue += "\t";

				for (int j = 0; j < 4; j++)
				{
					returnValue += (walls[(i * 4) + j + 12]? "--" : "  ");
					
					if (j != 3 && i != 3)
					{
						returnValue += (unions[(i * 3) + j]? " · " : "   ");
					}
				}
			}

			returnValue += "\n ";
		}

		return returnValue;
	}
}







