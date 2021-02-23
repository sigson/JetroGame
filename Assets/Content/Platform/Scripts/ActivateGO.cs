using UnityEngine;
using System.Collections;

public class ActivateGO : MonoBehaviour {

	public GameObject[] thisGameObject;
	public bool DeactivateOnStart;

	void Start()
	{
		if (DeactivateOnStart) {
			foreach(GameObject go in thisGameObject)
			{
				go.SetActive(false);
			}
		}
	}

	public void SetActive(bool state)
	{
		foreach(GameObject go in thisGameObject)
		{
			go.SetActive(state);
		}
	}
}
