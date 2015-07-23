using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class BoardTable
{
	private  int[] initialArrangement; //1-4
	public   int[] objectPositions; //0-15  name -> position
	public   int[] objectLabels; //0-15 position -> names
	public   int[] nums; //1-4
	public  bool[] walls;
	private bool[] unions;
	
	public BoardTable()
	{
		initialArrangement = new int[16];
		objectPositions = new int[16];
		objectLabels = new int[16];
		nums = new int[16];
		walls = new bool[24];
		unions = new bool[9];

		for (int i = 0; i < 16; i++)
		{
			initialArrangement[i] = 0;
			objectPositions[i] = 0;
			objectLabels[i] = 0;
			nums[i] = 0;
		}
		for (int i = 0; i < 24; i++) {  walls[i] = false; }
		for (int i = 0; i <  9; i++) { unions[i] = false; }
	}
	
	public void SetNewTable(int[] numbers, bool[] _walls, bool[] _unions)
	{
		for (int i = 0; i < 16; i++)
		{
			objectPositions[i] = i;
			objectLabels[i] = i;
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
			objectPositions[i] = i;
			objectLabels[i] = i;
			nums[i] = initialArrangement[i];
		}
	}
	
	public void SWAP(int piece_1, int piece_2)
	{
		int tmp;

		tmp = nums [piece_1];
		nums [piece_1] = nums [piece_2];
		nums [piece_2] = tmp;

		tmp = objectPositions [piece_1];
		objectPositions [piece_1] = objectPositions [piece_2];
		objectPositions [piece_2] = tmp;

		tmp = objectLabels [objectPositions [piece_1]];
		objectLabels [objectPositions [piece_1]] = objectLabels [objectPositions [piece_2]];
		objectLabels [objectPositions [piece_2]] = tmp;
	}

	public int CheckMove(int objectName, MovementTYPE movType)
	{
		int index = objectPositions [objectName];

		switch (movType)
		{
		case MovementTYPE.RIGHT:
			if (index % 4 !=  3 && !walls[index - (index / 4)]) { return objectLabels[objectPositions[index + 1]]; }
			break;

		case  MovementTYPE.LEFT:
			if (index % 4 !=  0 && !walls[index - (index / 4) - 1]) { return objectLabels[objectPositions[index - 1]]; }
			break;

		case  MovementTYPE.DOWN:
			if (index < 12 && !walls[index + 12]) { return objectLabels[objectPositions[index + 4]]; }
			break;

		case    MovementTYPE.UP:
			if (index > 4  && !walls[index +  8]) { return objectLabels[objectPositions[index - 4]]; }
			break;
		}

		return 16;
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

	public void LoadLevel(int level)
	{
		string tmp = "";

		StreamReader reader = new StreamReader ("Assets/LevelArrangement/LevelArrangement.txt");
		
		for (int i = 0; i < level; i++)
		{
			tmp = reader.ReadLine();
		}

		reader.Close ();
		
		for (int i = 0; i < 16; i++)
		{
			switch (tmp [i])
			{
			case '1': nums [i] = 1; break;
			case '2': nums [i] = 2; break;
			case '3': nums [i] = 3; break;
			case '4': nums [i] = 4; break;
			}

			objectPositions[i] = i;
			objectLabels[i] = i;
		}
		
		for (int i = 0; i < 24; i++) { walls[i] = (tmp[i + 17] == '1'); }
		
		for (int i = 0; i < 9; i++) { unions[i] = (tmp[i + 42] == '1'); }
		
		Debug.Log (this);
	}
	
	public override string ToString()
	{
		string returnValue = " ";
		
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				if (objectLabels[(i * 4) + j] < 10) { returnValue += "  "; }

				returnValue += objectLabels[(i * 4) + j] + " ";

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







