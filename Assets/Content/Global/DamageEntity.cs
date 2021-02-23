using UnityEngine;
using System.Collections;
using MarchingBytes;

public class DamageEntity : MonoBehaviour {

	Rigidbody2D thisRigidbody;
	public float Damage;
	public string TypeTarget;
	float DamageEntityTimeDead;
	bool NoDanger = false;
	

	public void SetStartData(Vector2 velocity, float damage, string typetarget, float entitytimedead)
	{
		thisRigidbody = this.GetComponent<Rigidbody2D> ();
		thisRigidbody.velocity = velocity;
		Damage = damage;
		TypeTarget = typetarget;
		DamageEntityTimeDead = entitytimedead;
		Invoke ("Dead", DamageEntityTimeDead);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == TypeTarget) {
			coll.GetComponentInParent<Entity> ().Damage (Damage);
		}
		EasyObjectPool.instance.ReturnObjectToPool (this.gameObject);
		CancelInvoke ();
//		if (!NoDanger) { из-за странного ебантяйства я не могу сделать стрелу неопасной
//		}
//		if (coll.tag == "BlockGround") {
//			NoDanger = true;
//		}
	}

	void Dead()
	{
		EasyObjectPool.instance.ReturnObjectToPool(this.gameObject);
	}
}
