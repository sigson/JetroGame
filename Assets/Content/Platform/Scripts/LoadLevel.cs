using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public string NameLocations;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player") {
			Application.LoadLevel (NameLocations);
			PlayerPrefs.DeleteKey ("PosX");
			PlayerPrefs.DeleteKey ("PosY");
			PlayerPrefs.DeleteKey ("AtivatedSavesMax");
		}
	}

	public void FLoadLevel()
	{
		Application.LoadLevel (NameLocations);
	}

	public void FExitGame()
	{
		Application.Quit ();
	}
}
