using UnityEngine;
using System.Collections;

public class SaveScript : MonoBehaviour {

	public GameObject GO;
	public bool Activated;
	public int SaveNum;

	void Start()
	{
		if (PlayerPrefs.HasKey ("AtivatedSavesMax")) {
			if (PlayerPrefs.GetInt("AtivatedSavesMax")>=SaveNum)
			{
				Activated = true;
				this.GetComponent<Animator>().Play("SavedBlockAnimation");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (Activated == false) {
			if (coll.tag == "Player") {
				Activated = true;
				//PlayerPrefs.SetString("StartedFlag", "Started"); //Started or InSave
				this.GetComponent<Animator>().Play("SavedBlockAnimation");
				PlayerPrefs.SetFloat("PosX", GO.transform.position.x);
				PlayerPrefs.SetFloat("PosY", GO.transform.position.y);
				PlayerPrefs.SetInt("AtivatedSavesMax", SaveNum);
			}
		}
	}
}
