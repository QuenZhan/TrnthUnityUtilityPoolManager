using UnityEngine;
using System.Collections.Generic;
using PathologicalGames;
public class TrnthPoolBase:TrnthMonoBehaviour{
	public GameObject Spawn(GameObject gobj){
		var gg=Spawn(gobj.transform);
		if(!gg)return null;
		return gg.gameObject;
	}
	public Transform Spawn(Transform tra){
		var instance=PoolManager.Pools["TRNTH"].Spawn(tra);
		if(instance)instance.position=pos;
		return instance;

	}
	public void DespawnTarget(GameObject gobj){
		Despawn(gobj);
	}
	public void Despawn(Transform tra){
		if(!tra.gameObject.activeInHierarchy)return;
		PoolManager.Pools["TRNTH"].Despawn(tra);		
	}
	public void Despawn(GameObject gobj){
		Despawn(gobj.transform);
	}
	public void Despawn(Transform tra,float delay){
		if(!tra.gameObject.activeInHierarchy)return;
		PoolManager.Pools["TRNTH"].Despawn(tra,delay);
	}
}