using UnityEngine;
using System.Collections;

public class CopyRigidbody : MonoBehaviour {

	public Rigidbody2D CopyAt, CopyFor;


	void Update () {
		CopyFor.position = CopyAt.position;
	}
}
