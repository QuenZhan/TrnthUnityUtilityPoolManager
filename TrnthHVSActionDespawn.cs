using UnityEngine;
using System.Collections;
using PathologicalGames;
public class TrnthHVSActionDespawn : TrnthHVSActionPoolBase {
	protected override void _execute(){
		var tra=prefab.transform;
		// if(!tra.gameObject.activeInHierarchy)return;
		var pool=PoolManager.Pools[this.pool];
		if(pool.IsSpawned(tra))pool.Despawn(tra);
	}
}
