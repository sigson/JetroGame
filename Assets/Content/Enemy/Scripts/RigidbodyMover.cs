using UnityEngine;
using System.Collections;

public class RigidbodyMover : MonoBehaviour {
	
	public Rigidbody2D Body;
	
	void Start()
	{
		Body = this.GetComponent<Rigidbody2D> ();
	}
	
	public void Move(float x_velocity)
	{
		Body.velocity = new Vector2 (x_velocity, Body.velocity.y);
	}
}
