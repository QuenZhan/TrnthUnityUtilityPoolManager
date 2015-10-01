using UnityEngine;
using System.Collections;
using PathologicalGames;
public class TrnthHVSActionSpawn : TrnthHVSActionInstantiate {
	[SerializeField] string pool="TRNTH";
	public bool instantiateIfNoPool=false;
	protected override GameObject create(Vector3 position,Quaternion rotation,Transform parent){
		var canPooling=PoolManager.Pools.ContainsKey(this.pool);
		if(!canPooling){
			Debug.LogWarning("PoolManager.Pools has no pool : "+this.pool,transform);
			if(instantiateIfNoPool)return base.create(position,rotation,parent);
			return null;
		}
		var pool=PoolManager.Pools[this.pool];
		var ins=pool.Spawn(prefab.transform,position,rotation,parent);
		if(life>0)pool.Despawn(ins,life);
		return ins.gameObject;
	}
}
