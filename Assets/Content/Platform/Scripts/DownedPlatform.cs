using UnityEngine;
using System.Collections;

public class DownedPlatform : MonoBehaviour {

	public float time, time2;
	bool Upped = true;
	Vector3 thisTransform;

	void Start()
	{
		thisTransform = this.transform.position;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player") {
			if (Upped)
				Invoke ("Down", time);
		}
	}

	void Down()
	{
		Upped = false;
		this.GetComponent<Rigidbody2D> ().isKinematic = false;
		Invoke ("Up", time2);
	}

	void Up()
	{
		Upped = true;
		this.transform.position = thisTransform;
		this.transform.rotation = Quaternion.identity;
		this.GetComponent<Rigidbody2D> ().isKinematic = true;
	}
}
