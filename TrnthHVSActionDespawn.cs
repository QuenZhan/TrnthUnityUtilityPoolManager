using UnityEngine;
using System.Collections;
using PathologicalGames;
public class TrnthHVSActionDespawn : TrnthHVSActionPoolBase {
	// public bool destroyIfFailed=false;
	public void despawn(GameObject target){
		prefab=target;
		_execute();
	}
	protected override void _execute(){
		var tra=prefab.transform;
		var pool=PoolManager.Pools[this.pool];
		if(pool.IsSpawned(tra)){
			pool.Despawn(tra);
			return;
		}
		Debug.LogWarning("destroyIfFailed "+prefab.name,transform);
		// if(destroyIfFailed){
		// 	Destroy(prefab);
		// }
	}
}
