using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FileManager : MonoBehaviour
{

	public static List<string> ArrayToList(string[] array)
	{
		List<string> list = new List<string>();
		for (int i = 0; i < array.Length; i++)
		{
			string s = array[i];
			if (s.Length > 0 )
			{
				list.Add(s);
			}
		}
		return list;
	}



	public static List<string> ReadTextAsset(TextAsset txt)
	{
		string[] lines = txt.text.Split('\n', '\r');

		return ArrayToList(lines);
	}

}