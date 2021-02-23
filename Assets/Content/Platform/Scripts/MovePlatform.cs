using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {

	public float Distance, Velocity;
	public float LocalDistance;
	public bool RightStart;
	public bool Return = false;


	void OnCollisionEnter2D(Collision2D coll)
	{
		coll.transform.GetComponentInParent<Obj>().transform.parent = transform;
	}
	
	void OnCollisionExit2D(Collision2D coll)
	{
		coll.transform.GetComponentInParent<Obj>().transform.parent = null;
	}

	public void Move(float t)
	{
		transform.position = new Vector3 (transform.position.x + t, transform.position.y, 0f);
	}

	void FixedUpdate()
	{
		if (RightStart) {
			if (Distance >= LocalDistance && !Return) {
				LocalDistance += Velocity;
				Move (Velocity);
			}
			if (Distance <= LocalDistance && !Return) {
				Return = true;
			}
			if (Return && LocalDistance > 0) {
				LocalDistance -= Velocity;
				Move (-Velocity);
			}
			if (LocalDistance <= 0 && Return) {
				Return = false;
			}
		} else {
			if (0 >= LocalDistance && !Return) {
				LocalDistance += Velocity;
				Move (Velocity);
			}
			if (0 <= LocalDistance && !Return) {
				Return = true;
			}
			if (Return && LocalDistance > -Distance) {
				LocalDistance -= Velocity;
				Move (-Velocity);
			}
			if (LocalDistance <= -Distance && Return) {
				Return = false;
			}
		}
	}
}