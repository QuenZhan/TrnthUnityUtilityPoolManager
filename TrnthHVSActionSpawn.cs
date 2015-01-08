using UnityEngine;
using System.Collections;
using PathologicalGames;
public class TrnthHVSActionSpawn : TrnthHVSActionPoolBase {
	public bool beChild=false;
	public bool positionFit=true;
	public bool rotationFit;
	public TrnthHVSCondition onSucceed;
	public TrnthHVSCondition onFail;
	public Transform spawned{get;private set;}
	protected override void _execute(){
		if(!PoolManager.Pools.ContainsKey(this.pool)){
			Debug.LogWarning("PoolManager.Pools has no pool : "+this.pool,transform);
			return;
		}
		base._execute();
		spawned=PoolManager.Pools[this.pool].Spawn(prefab.transform);
		if(!spawned){
			if(onFail)onFail.send();
			return;
		}
		if(positionFit)spawned.position=transform.position;
		if(rotationFit)spawned.eulerAngles=transform.eulerAngles;
		if(beChild)spawned.parent=transform;
		if(onSucceed)onSucceed.send();
	}
}
