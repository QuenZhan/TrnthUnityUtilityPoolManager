using UnityEngine;
using System.Collections;
using PathologicalGames;
public class TrnthPoolPathologicalGames  {
	static public T spawn<T>(T prefab,Vector3 position,float despawnAfter)where T:Component{
		return spawn<T>(prefab,position,despawnAfter,null);
	}
	static public GameObject spawn(GameObject prefab,Vector3 position){
		return spawn(prefab,position,10,null);
	}
	static public GameObject spawn(GameObject prefab,Vector3 position,float despawnAfter){
		return spawn(prefab,position,despawnAfter,null);
	}
	static public GameObject spawn(GameObject prefab,Vector3 position,float despawnAfter,Transform parent){
		var pool=PoolManager.Pools["TRNTH"];
		var spawned=pool.Spawn(prefab.transform,position,prefab.transform.rotation,parent);
		if(spawned==null)return null;
		if(despawnAfter<=0)return spawned.gameObject;
		pool.Despawn(spawned,despawnAfter);
		return spawned.gameObject;
	}
	static public T spawn<T>(T prefab,Vector3 position,float despawnAfter,Transform parent)where T:Component{
		return spawn(prefab.gameObject,position,despawnAfter,parent).GetComponent<T>();
	}
	static public void despawn(GameObject spawned){
		var pool=PoolManager.Pools["TRNTH"];
		if(pool.IsSpawned(spawned.transform))pool.Despawn(spawned.transform);
	}
	static public void despawnOrDestory(GameObject target){
		var pool=PoolManager.Pools["TRNTH"];
		if(pool.IsSpawned(target.transform))pool.Despawn(target.transform);
		else GameObject.Destroy(target);
	}
}
