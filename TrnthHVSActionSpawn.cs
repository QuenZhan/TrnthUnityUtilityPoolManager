using UnityEngine;
using System.Collections;
using PathologicalGames;
public class TrnthHVSActionSpawn : TrnthHVSActionPoolBase {
	public bool beChild=false;
	public bool positionFit=true;
	public bool rotationFit;
	public Transform spawned{get;private set;}
	protected override void _execute(){
		if(!PoolManager.Pools.ContainsKey(this.pool))return;
		// var pool=PoolManager.Pools[this.pool];
		base._execute();
		spawned=PoolManager.Pools[this.pool].Spawn(prefab.transform);
		if(positionFit)spawned.position=transform.position;
		if(rotationFit)spawned.eulerAngles=transform.eulerAngles;
		if(beChild)spawned.parent=transform;
	}
}
