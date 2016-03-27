using UnityEngine;
using System.Collections;
using TRNTH;
public class TrnthHVSActionSpawnRandom : TrnthHVSActionSpawn {
	public GameObject[] prefabs;
	protected override void _execute(){
		this.prefab=prefabs.choose();
		base._execute();
	}
}
