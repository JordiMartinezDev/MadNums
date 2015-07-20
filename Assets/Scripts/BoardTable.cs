public class BoardTable
{
	private  int[] initialArrangement;
	public   int[] positions;
	public   int[] nums;
	public  bool[] walls;
	private bool[] unions;
	
	public BoardTable()
	{
		initialArrangement = new int[16];
		positions = new int[16];
		nums = new int[16];
		walls = new bool[24];
		unions = new bool[9];

		for (int i = 0; i < 16; i++)
		{
			initialArrangement[i] = 0;
			positions[i] = 0;
			nums[i] = 0;
		}
		for (int i = 0; i < 24; i++) {  walls[i] = false; }
		for (int i = 0; i <  9; i++) { unions[i] = false; }
	}
	
	public void SetNewTable(int[] numbers, bool[] _walls, bool[] _unions)
	{
		for (int i = 0; i < 16; i++)
		{
			positions[i] = i;
			nums[i] = numbers[i];
			initialArrangement[i] = numbers[i];
		}

		walls = _walls;
		unions = _unions;
	}
	
	public void ResetTable()
	{
		for (int i = 0; i < 16; i++)
		{
			positions[i] = i;
			nums[i] = initialArrangement[i];
		}
	}
	
	public void SWAP(int piece_1, int piece_2)
	{
		int tmp = nums [piece_1];
		nums [piece_1] = nums [piece_2];
		nums [piece_2] = tmp;

		tmp = positions [piece_1];
		positions [piece_1] = positions [piece_2];
		positions [piece_2] = tmp;
	}

	public bool CheckMove(int position, MovementTYPE movType)
	{
		int index = positions [position];

		switch (movType)
		{
		case MovementTYPE.RIGHT: return (index % 4 !=  3 && !walls[index - (index/4)    ]);
		case  MovementTYPE.LEFT: return (index % 4 !=  0 && !walls[index - (index/4) - 1]);
		case  MovementTYPE.DOWN: return (     index < 12 && !walls[index + 12]);
		case    MovementTYPE.UP: return (     index > 4  && !walls[index +  8]);
		                default: return true;
		}
	}

	public bool CheckWin()
	{
		for (int i = 0; i < 4; i++)
		{
			if (  nums[i * 4] + nums[(i * 4) + 1] + nums[(i * 4) + 2] + nums[(i * 4) + 3] != 10
			   || nums[i    ] + nums[i + 4      ] + nums[i + 8      ] + nums[i + 12     ] != 10)
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
				if (positions[(i * 4) + j] < 10) { returnValue += "  "; }

				returnValue += positions[(i * 4) + j] + " ";

				if (j != 3)
				{
					if (walls[(i * 3) + j]) { returnValue += "|"; }
				}

				returnValue += " ";
			}

			returnValue += "\t";

			for (int j = 0; j < 4; j++)
			{
				returnValue += " " + nums[(i * 4) + j] + " ";
				
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
					returnValue += (walls[(i * 4) + j + 12]? "-- " : "   ");
					
					if (j != 3)
					{
						returnValue += (unions[(i * 3) + j]? " ·  " : "    ");
					}
				}

				returnValue += "\t";

				for (int j = 0; j < 4; j++)
				{
					returnValue += (walls[(i * 4) + j + 12]? "--" : "  ");
					
					if (j != 3)
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







