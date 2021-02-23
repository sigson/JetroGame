using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour
{

	public RigidbodyMover thisRigidbody;
	public Entity thisEntity;
	public float Velocity;
	Vector3 Scale;
	Collider2D WorkColl = null;
	public Animator thisAnimator;
	bool IsBoss;
	public NPCDamager thisDamager;

	void Start ()
	{
		Scale = thisRigidbody.transform.localScale;
		IsBoss = thisEntity.Boss;
		thisAnimator.Play ("Idle" + thisEntity.AnimationLayer);
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.tag == "Player") {
			WorkColl = coll;
		}
	}

	void OnTriggerExit2D (Collider2D coll)
	{
		if (coll.tag == "Player") {
			WorkColl = null;
		}
	}

	void FixedUpdate ()
	{
		if (thisEntity.OnDamage == false) {
			if (WorkColl != null) {
				if (thisRigidbody.transform.position.x > WorkColl.transform.position.x) {
					thisRigidbody.transform.localScale = new Vector3 (-Scale.x, Scale.y, 1);
					thisEntity.thisStatsWorker.transform.localScale = new Vector3 (Scale.x, 1, 1);
					thisRigidbody.Move (-Velocity);
				} else {
					thisRigidbody.transform.localScale = new Vector3 (Scale.x, Scale.y, 1);
					thisRigidbody.Move (Velocity);
					thisEntity.thisStatsWorker.transform.localScale = new Vector3 (-Scale.x, 1, 1);
				}
				thisAnimator.SetInteger ("States", 1);
			} else {
				thisAnimator.SetInteger ("States", 0);
			}
		} else {

		}
	}
}
	