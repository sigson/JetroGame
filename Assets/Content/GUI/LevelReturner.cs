using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelReturner : MonoBehaviour {

	public void CreateReaction(string text)
	{
		this.GetComponent<Text> ().text = text;
	}
}
