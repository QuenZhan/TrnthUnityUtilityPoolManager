using UnityEngine;
using System.Collections.Generic;
using PathologicalGames;
public class TrnthPoolBase:TrnthMonoBehaviour{
	public string poolName="TRNTH";
	public GameObject Spawn(GameObject gobj){
		var gg=Spawn(gobj.transform);
		if(!gg)return null;
		return gg.gameObject;
	}
	public Transform Spawn(Transform tra){
		if(!tra)return null;
		var instance=PoolManager.Pools[poolName].Spawn(tra);
		if(instance)instance.position=pos;
		return instance;
	}
	public void DespawnTarget(GameObject gobj){
		Despawn(gobj.transform);
	}
	public void Despawn(Transform tra){
		Despawn(tra,0);
	}
	public void Despawn(GameObject gobj){
		Despawn(gobj.transform);
	}
	public void Despawn(Transform tra,float delay){
		if(!tra.gameObject.activeInHierarchy)return;
		var pool=PoolManager.Pools[poolName];
		if(pool.IsSpawned(tra))pool.Despawn(tra,delay);
		else {
			pool.Add(tra,tra.name,true,true);
			// Destroy(tra.gameObject,delay);
		}
	}
	public void poolAdd(Transform tra){
		var pool=PoolManager.Pools[poolName];
		pool.Add(tra,tra.name,true,true);
	}
}