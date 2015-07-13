using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;


public class TableBasic : MonoBehaviour
{
	private StreamReader reader;

	public BoardTable boardTable;


	void Start()
	{
		boardTable = new BoardTable ();

		LoadLevel (1);
		LoadLevel (2);
	}

	public void LoadLevel(int level)
	{
		reader = new StreamReader ("Assets/LevelArrangement/LevelArrangement.txt");

		string tmp = "";

		for (int i = 0; i < level; i++)
		{
			tmp = reader.ReadLine();
		}

		if (tmp != null)
		{
			int[] numbers = new int[16];
			
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					switch (tmp [(i * 4) + j])
					{
					case '1':
						numbers [(i * 4) + j] = 1;
						break;
					case '2':
						numbers [(i * 4) + j] = 2;
						break;
					case '3':
						numbers [(i * 4) + j] = 3;
						break;
					case '4':
						numbers [(i * 4) + j] = 4;
						break;
					default:
						numbers [(i * 4) + j] = 8;
						break;
					}
				}
			}

			boardTable.SetNewTable (numbers);
		}
		else
		{
			boardTable.SetTableToEmpty();
		}

		Debug.Log (boardTable);

		reader.Close ();
	}
}










