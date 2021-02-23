using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatBarWorker : MonoBehaviour {

	//В общем логика изи - получаем процент от имеющегося хп и максимального хп и уменьшаем
	//width бара на данные от его максимального размера и процента оставшегося хп, pos X получаем
	//от деления width оставшегося хп надвое

	public GameObject HPBar, StaminaBar, ManaBar, CoinBar;
	
	public void SetHP(float HP)//В проценте всего хп
	{
		HPBar.GetComponent<SetStateToBar> ().SetState (HP);
	}

	public void SetCoin(int Value)
	{
		CoinBar.GetComponent<Text> ().text = Value.ToString();
	}
}
