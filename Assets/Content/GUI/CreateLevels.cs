using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MarchingBytes;
using System;

public class CreateLevels : MonoBehaviour
{

	FileWork FileWorker;

	void Start ()
	{
		List<string> nulllist = new List<string> ();
		FileWorker = new FileWork ();

		GameObject parent = this.GetComponentInChildren<HorizontalLayoutGroup> ().gameObject, pattern = this.GetComponentInChildren<LevelMenager>().gameObject;
		pattern.SetActive (false);
		if (FileWorker.File_Exist (@"Save\Save.sav")) {
			nulllist = FileWorker.File_Load (@"Save\Save.sav");
			for (int i=0; i<Convert.ToInt32(nulllist[1]); i++) {
				GameObject level = EasyObjectPool.instance.GetObjectFromPool ("LevelPool", Vector3.zero, Quaternion.identity);
				level.GetComponent<RectTransform>().anchoredPosition = pattern.GetComponent<RectTransform>().anchoredPosition;
				level.transform.SetParent (parent.transform);
				level.GetComponent<LevelMenager>().CreateReaction((i+1).ToString(), ((i+1)*50+30).ToString()+"$");
			}
		} else {
			nulllist.Add ("0");//$
			nulllist.Add ("5");//level
			nulllist.Add ("1");//sold
			nulllist.Add ("0");//sniper
			nulllist.Add ("0");//striker
			nulllist.Add ("0");//mag
			nulllist.Add ("0");//tank
			FileWorker.CreateDir("Save");
			FileWorker.File_Create (nulllist, @"Save\Save.sav");
			nulllist = FileWorker.File_Load (@"Save\Save.sav");
			for (int i=0; i<Convert.ToInt32(nulllist[1]); i++) {
				GameObject level = EasyObjectPool.instance.GetObjectFromPool ("LevelPool", Vector3.zero, new Quaternion (0, 0, 0, 1));
				level.transform.SetParent (parent.transform);
				level.GetComponent<LevelMenager>().CreateReaction((i+1).ToString(), ((i+1)*50+30).ToString()+"$");
			}
		}
	}
}
