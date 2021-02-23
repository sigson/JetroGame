using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelMenager : MonoBehaviour {

	string Level, Profit;

	public void CreateReaction(string level, string profit)
	{
		Level = level;
		Profit = profit;
		this.GetComponentInChildren<LevelReturner> ().CreateReaction (level);
		this.GetComponentInChildren<ProfitReturner> ().CreateReaction (profit);
		this.GetComponentInChildren<Button>().onClick.AddListener(()=>NextLevel());
	}

	public void NextLevel()
	{
		GameObject.FindGameObjectWithTag ("DataSaver").GetComponent<DataSaver>().SetDataGame(Level, Profit);
		Application.LoadLevel ("Game");
	}
}
