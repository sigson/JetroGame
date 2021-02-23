using UnityEngine;
using System.Collections.Generic;
using MarchingBytes;

public class NPCDamager : MonoBehaviour {

	public Entity thisEntity;
	Collider2D WorkColl = null;
	public Animator thisAnimator;
	public DamageSub thisDS;
	public List<GameObject> ArrowsArr;
	public bool InPaused;
	
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
			//CancelInvoke();
		}
	}
	
	public void Damage()
	{
		//Debug.Log (WorkColl);

		if (WorkColl == null) {
			return;
		}
		if (!InPaused) {
			thisEntity.OnDamage = true;
			thisEntity.thisNPCAnimS.StartTime ();
			thisAnimator.SetInteger ("States", 2);
		}
	}
	

	public void SetDamage()
	{
		InPaused = true;
		Invoke ("Resume", thisEntity.PauseAfterAttack);
		if (thisEntity.Knight) {
			if (WorkColl != null)
				WorkColl.GetComponentInParent<Entity> ().Damage (thisEntity.damage);
		}
		if (thisEntity.Bowman)
		{
			if (WorkColl != null)
			{
				GameObject Arrow = EasyObjectPool.instance.GetObjectFromPool("Arrows", this.transform.position, Quaternion.identity);
				Transform ArrowTransform = Arrow.transform;
				Arrow.transform.position = new Vector3(ArrowTransform.position.x, ArrowTransform.position.y+ArrowTransform.localScale.x*2, ArrowTransform.position.z);
				Arrow.transform.right = WorkColl.transform.position - this.transform.position;
				Arrow.GetComponent<DamageEntity>().SetStartData(new Vector2(Arrow.transform.right.x, Arrow.transform.right.y) * thisEntity.DamageEntitySpeed, thisEntity.damage, thisEntity.TypeTarget, thisEntity.DamageEntityDownTime);
				//ArrowsArr.Add(Arrow);
			}
		}
	}


	void Resume()
	{
		InPaused = false;
		Damage ();
	}

	public void Canceled()
	{
		CancelInvoke();
	}
}
