using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;


public class TableBasic 
{
	private StreamReader reader;

	public BoardTable boardTable;


	public TableBasic()
	{
		boardTable = new BoardTable ();
	}

	public void LoadLevel(int level)
	{
		reader = new StreamReader ("Assets/LevelArrangement/LevelArrangement.txt");

		string tmp = "";

		for (int i = 0; i < level; i++)
		{
			tmp = reader.ReadLine();
		}

		int[] numbers = new int[16];
		bool[] walls = new bool[24];
		bool[] unions = new bool[9];
		
		for (int i = 0; i < 16; i++)
		{
			switch (tmp [i])
			{
			case '1':
				numbers [i] = 1;
				break;
			case '2':
				numbers [i] = 2;
				break;
			case '3':
				numbers [i] = 3;
				break;
			case '4':
				numbers [i] = 4;
				break;
			}
		}
		
		for (int i = 0; i < 24; i++) { walls[i] = (tmp[i + 17] == '1'); }
		
		for (int i = 0; i < 9; i++) { unions[i] = (tmp[i + 42] == '1'); }
		
		boardTable.SetNewTable (numbers, walls, unions);

		reader.Close ();

		Debug.Log (boardTable);
	}
}










