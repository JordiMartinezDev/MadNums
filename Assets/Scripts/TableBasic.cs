using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class BoardTable
{
	private int[] initialArrangement;

	private int[][] nums;

	public BoardTable()
	{
		for (int i = 0; i < 16; i++)
		{
			nums[i / 4][i % 4] = 0;
			initialArrangement[i] = 0;
		}
	}

	void SetNewTable(int[] numbers)
	{
		for (int i = 0; i < 16; i++)
		{
			nums[i / 4][i % 4] = numbers[i];
			initialArrangement[i] = numbers[i];
		}
	}

	void ResetTable()
	{
		for (int i = 0; i < 16; i++)
		{
			nums[i / 4][i % 4] = initialArrangement[i];
		}
	}

	void SWAP(int r1, int c1, int r2, int c2)
	{
		int tmp = nums [r1] [c1];
		nums [r1] [c1] = nums [r2] [c2];
		nums [r2] [c2] = tmp;
	}

	bool CheckWin()
	{
		for (int i = 0; i < 4; i++)
		{
			if(nums[i][0] + nums[i][1] + nums[i][2] + nums[i][3] != 10
			   || nums[0][i] + nums[1][i] + nums[2][i] + nums[3][i] != 10)
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
				returnValue += nums[i][j];
				returnValue += ", ";
			}

			returnValue += "\n";
		}
		return returnValue;
	}

}


public class TableBasic : MonoBehaviour
{
	private StreamReader reader;

	public BoardTable boardTable;


	void Start()
	{
		reader = new StreamReader ("Assets/LevelArrangement/LevelArrangement.txt");

		LoadLevel (1);
		LoadLevel (2);
	}

	void LoadLevel(int level)
	{
		reader.DiscardBufferedData ();

		string tmp = " ";

		for (int i = 0; i < (level - 1) * 5; i++)
		{
			tmp = reader.ReadLine();
		}

		int[] numbers = new int[16];

		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				numbers[(i * 4) + j] = Int32.Parse(tmp);
			}

			tmp = reader.ReadLine();
		}

		Debug.Log (boardTable);

	}
}










