using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public bool NPC, Enemy, Player, Boss, Bowman, Knight, Mag;
	public int JumpsInOneJump, Coins;
	public float MaxHP, HP, AvoidanceChance, damage, DamageTime, PauseAfterAttack;
	public StatBarWorker thisStatsWorker;
	public NPCDamager thisDamager;
	public NPCAnimationSync thisNPCAnimS;
	public NPCController ThisController;
	public GameObject thisRealObject;
	public GameObject Controller;
	public string AnimationLayer, TypeTarget;
	public bool OnDamage;

	public float DamageEntitySpeed, DamageEntityDownTime;

	void Start()
	{
		Transform trans = this.transform;
		if (Player) {
			if (PlayerPrefs.HasKey ("PosX") && PlayerPrefs.HasKey ("PosY")) {
				//Controller.transform.position = trans.InverseTransformPoint(new Vector3 (PlayerPrefs.GetFloat ("PosX")+this.transform.position.x, PlayerPrefs.GetFloat ("PosY")+this.transform.position.y, 1));
				this.transform.position = new Vector3 (PlayerPrefs.GetFloat ("PosX"), PlayerPrefs.GetFloat ("PosY"), 1);
			}
		}
	}

	public void AddCoin(int Value)
	{
		Coins += Value;
		thisStatsWorker.SetCoin (Coins);
	}

	public void Damage(float Damage)
	{
		float avoidance = Random.Range (0, 100);
		if (avoidance >= AvoidanceChance) {
			HP -= Damage;
		}
		thisStatsWorker.SetHP (100 / (MaxHP / HP));
		if (HP <= 0) {
			if (Player)
			{
				//HP = MaxHP;
				//thisStatsWorker.SetHP (100 / (MaxHP / HP));
				Application.LoadLevel(Application.loadedLevelName);
			}
			if (Enemy)
			{
				OnDamage = false;
				thisDamager.Canceled();
				thisDamager.gameObject.SetActive(false);
				ThisController.gameObject.SetActive(false);
				thisNPCAnimS.thisAnim.Play("Dead"+AnimationLayer);
			}
			if (Boss)
			{
				OnDamage = false;
				thisDamager.Canceled();
				thisRealObject.SetActive(false);
			}
		}
	}

}
