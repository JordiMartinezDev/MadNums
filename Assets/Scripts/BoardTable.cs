public class BoardTable
{
	private int[] initialArrangement;
	
	private int[,] nums;
	
	public BoardTable()
	{
		initialArrangement = new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
		nums = new int[4, 4] {{ 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }};
	}
	
	public void SetNewTable(int[] numbers)
	{
		for (int i = 0; i < 16; i++)
		{
			nums[i / 4, i % 4] = numbers[i];
			initialArrangement[i] = numbers[i];
		}
	}
	
	public void SetTableToEmpty()
	{
		for (int i = 0; i < 16; i++)
		{
			nums[i / 4, i % 4] = 0;
		}
	}
	
	public void ResetTable()
	{
		for (int i = 0; i < 16; i++)
		{
			nums[i / 4, i % 4] = initialArrangement[i];
		}
	}
	
	public void SWAP(int r1, int c1, int r2, int c2)
	{
		int tmp = nums [r1, c1];
		nums [r1, c1] = nums [r2, c2];
		nums [r2, c2] = tmp;
	}
	
	public bool CheckWin()
	{
		for (int i = 0; i < 4; i++)
		{
			if(nums[i, 0] + nums[i, 1] + nums[i, 2] + nums[i, 3] != 10
			   || nums[0, i] + nums[1, i] + nums[2, i] + nums[3, i] != 10)
			{
				return false;
			}
		}
		
		return true;
	}
	
	public override string ToString()
	{
		string returnValue = "";
		
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				returnValue += nums[i, j];
				returnValue += ", ";
			}
			
			returnValue += "\n";
		}
		return returnValue;
	}
}

