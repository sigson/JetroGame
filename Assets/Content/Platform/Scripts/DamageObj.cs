using UnityEngine;
using System.Collections;

public class DamageObj : MonoBehaviour {

	public Entity thisEntity;
	Collider2D WorkColl = null;
	public float TimeDamage;
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player") {
			WorkColl = coll;
			Damage ();
		}
	}
	
	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.tag == "Player") {
			WorkColl = null;
			CancelInvoke();
		}
	}
	
	public void Damage()
	{
		if (WorkColl == null) {
			return;
		}
		if (WorkColl != null)
			WorkColl.GetComponentInParent<Entity> ().Damage (thisEntity.damage);
		Invoke ("Damage", thisEntity.DamageTime);
	}
	

	
	
	public void Canceled()
	{
		CancelInvoke();
	}
}
