using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {

	public float Distance, Velocity;
	public float LocalDistance;
	public bool RightDownStart;
	bool Return = false;
	public bool LeftRight, DownForward;
	
	public void Move(float t)
	{
		if (LeftRight)
		transform.position = new Vector3 (transform.position.x + t, transform.position.y, 0f);
		if (DownForward)
			transform.position = new Vector3 (transform.position.x, transform.position.y + t, 0f);
	}
	
	void FixedUpdate()
	{
		if (RightDownStart) {
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
