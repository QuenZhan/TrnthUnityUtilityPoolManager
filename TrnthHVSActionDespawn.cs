using UnityEngine;
using System.Collections;
using PathologicalGames;
public class TrnthHVSActionDespawn : TrnthHVSActionPoolBase {
	public bool destroyIfFailed=true;
	protected override void _execute(){
		var tra=prefab.transform;
		var pool=PoolManager.Pools[this.pool];
		if(pool.IsSpawned(tra)){
			pool.Despawn(tra);
			return;
		}
		if(destroyIfFailed)Destroy(prefab);
	}
}
