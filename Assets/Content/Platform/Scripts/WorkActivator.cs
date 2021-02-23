using UnityEngine;
using System.Collections;

public class WorkActivator : MonoBehaviour {

	public ActivateGO[] thisActivator;
	public bool OneEndWork;
	bool ifwork;


	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "Player")
		if (!ifwork)
		foreach (ActivateGO act in thisActivator) {
			act.SetActive(true);
			if (OneEndWork)
				ifwork = true;
		}
	}
}
