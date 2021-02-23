using UnityEngine;
using System.Collections.Generic;

public class DataSaver : MonoBehaviour {
	public List<string> DataList;
	public string Profit, Level;
	void Start () {
		DontDestroyOnLoad (this.gameObject);
	}
	public void SetDataGame(string level, string profit)
	{
		Profit = profit;
		Level = level;
	}
}
