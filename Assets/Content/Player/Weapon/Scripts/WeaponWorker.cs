using UnityEngine;
using System.Collections;

public class WeaponWorker : MonoBehaviour {

	public Animator SwordAnimator;
	public SpriteRenderer SwordRenderer;
	public PlayerDamager thisDamage;

	public void Kick(int SpriteLevel)
	{
		SwordAnimator.speed = 1;
		SwordRenderer.sortingOrder = SpriteLevel;
		thisDamage.Damage ();
	}
}
