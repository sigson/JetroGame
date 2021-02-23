using UnityEngine;
using System.Collections;

public class SetParent : MonoBehaviour {

	public GameObject Parent, Child;
	void Start () {
		Child.transform.SetParent (Parent.transform);
	}

}
