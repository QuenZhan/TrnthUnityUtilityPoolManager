using UnityEngine;
using System.Collections;

public class TrnthOnSpawedToSetActive : TrnthPoolBase {
	public GameObject[] gobjs;
	public bool yes;
	void OnSpawned(){
		foreach(GameObject e in gobjs){
			e.SetActive(yes);
		}
	}
}
