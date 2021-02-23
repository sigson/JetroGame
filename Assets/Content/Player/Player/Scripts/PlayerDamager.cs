using UnityEngine;
using System.Collections;

public class PlayerDamager : MonoBehaviour {
	
	public Entity thisEntity;
	Collider2D WorkColl = null;
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Enemy") {
			WorkColl = coll;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.tag == "Enemy") {
			WorkColl = null;
		}
	}
	
	public void Damage()
	{
		if (WorkColl != null)
		WorkColl.GetComponent<Entity> ().Damage (thisEntity.damage);
	}
}