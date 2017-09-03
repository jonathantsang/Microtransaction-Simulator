using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class cardInfoArray
{
	public int testing = 1;

	// TODO fix hardcoded storage
	public List<cardInfo> cardsList;
	public Dictionary<int, int> cardDict;

	public cardInfoArray() {
		cardsList = new List<cardInfo>() { new cardInfo() };
	}
	public cardInfoArray(int one, int two, int three){
		cardsList = new List<cardInfo>() { new cardInfo(one), new cardInfo(two), new cardInfo(three)};
	}
}

public class SaveData {

	public int DEBUG = 1;
	public cardInfoArray cards;

	public void WriteToFile(string filePath){
		// Convert the instance ('this') of this class to a JSON string with "pretty print" (nice indenting).
		string json = JsonUtility.ToJson(this, true);
		Debug.Log (json);
		// Write that JSON string to the specified file.
		File.WriteAllText(filePath, json);

	}

	public static SaveData ReadFromFile(string filePath){
		// If the file doesn't exist then just return the default object.
		if (!File.Exists (filePath)) {
			Debug.LogErrorFormat ("ReadFromFile({0}) -- file not found, returning new object", filePath);
			return new SaveData ();
		} else {
			// If the file does exist then read the entire file to a string.
			string contents = File.ReadAllText(filePath);

			// If it happens that the file is somehow empty then tell us and return a new SaveData object.
			if (string.IsNullOrEmpty(contents))
			{
				Debug.LogErrorFormat("File: '{0}' is empty. Returning default SaveData");
				return new SaveData();
			}
			// Otherwise we can just use JsonUtility to convert the string to a new SaveData object.
			Debug.Log(contents);
			return JsonUtility.FromJson<SaveData>(contents);
		}
	}
}
