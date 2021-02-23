using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProfitReturner : MonoBehaviour {

	public void CreateReaction(string text)
	{
		this.GetComponent<Text> ().text = text;
	}
}
