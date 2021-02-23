using UnityEngine;
using System.Collections;

public class NPCAnimationSync : MonoBehaviour {

	public NPCDamager thisDamager;
	public Entity thisEntity;
	public Animator thisAnim;

	public void StartTime()
	{
		Invoke ("Damage", thisEntity.DamageTime);
	}

	public void Damage()
	{
		if (thisEntity.OnDamage == true) {
			thisEntity.OnDamage = false;
			thisDamager.SetDamage ();
			thisDamager.Damage();
			//Debug.Log ("delegate2");
		}

	}

	public void StopDamageTime()
	{

		//Debug.Log ("delegate");
	}

	public void StopAnimate()
	{
		thisAnim.speed = 0f;
	}
}