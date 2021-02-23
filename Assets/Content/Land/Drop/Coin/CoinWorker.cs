using UnityEngine;
using System.Collections;

public class CoinWorker : MonoBehaviour {

	public int CoinValue;
	public bool Activated = false;
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (Activated == false) {
			if (coll.tag == "Player") {
				Activated = true;
				coll.GetComponentInParent<Entity>().AddCoin(CoinValue);
				this.GetComponent<Animator>().Play("Coin getting");

			}
		}
	}

	public void StopAnimation()
	{
		this.GetComponent<Animator>().speed = 0f;
		this.GetComponentInParent<Obj>().gameObject.SetActive(false);
	}
}
