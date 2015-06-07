using UnityEngine;
using System.Collections;
using PathologicalGames;
public class TrnthHVSActionDespawn : TrnthHVSActionPoolBase {
	public bool destroyIfFailed=false;
	protected override void _execute(){
		if(!prefab)return;
		var tra=prefab.transform;
		var pool=PoolManager.Pools[this.pool];
		if(pool.IsSpawned(tra)){
			pool.Despawn(tra);
			return;
		}
		Debug.LogWarning("destroyIfFailed",transform);
		if(destroyIfFailed){
			Destroy(prefab);
		}
	}
}
