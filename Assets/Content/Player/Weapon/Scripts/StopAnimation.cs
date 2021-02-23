using UnityEngine;
using System.Collections;

public class StopAnimation : MonoBehaviour {

	public Animator thisAnimator;
	public SpriteRenderer SwordRenderer;
	public int Order;

	void Start()
	{
		Order = SwordRenderer.sortingOrder;
	}

	public void StopThisAnimation()
	{
		thisAnimator.speed = 0f;
	}

	public void ReturnOrder()
	{
		SwordRenderer.sortingOrder = Order;
	}
}
