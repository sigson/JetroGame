using UnityEngine;
using System.Collections;

public class SetStateToBar : MonoBehaviour {

	RectTransform thisTransform;
	public float Width = 0f;

	void Awake()
	{
		thisTransform = this.GetComponent<RectTransform> ();
		Width = thisTransform.rect.width;
	}

	public void SetState(float stateInfo)
	{
		thisTransform.sizeDelta = new Vector2 ((Width / 100) * stateInfo, 0);
		thisTransform.rect.Set (((Width / 100) * stateInfo) / 2, 0, (Width / 100) * stateInfo, 0);
	}
}
