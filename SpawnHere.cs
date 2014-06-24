using UnityEngine;
using System.Collections;
using TRNTH;
public class SpawnHere : TRNTH.PoolBase{
	public GameObject prefab;
	public bool chooseInChildren=false;
	public float probability=1;
	public GameObject execute(){
		if(probability<Random.value)return null;
		Transform _prefab;
		if(chooseInChildren){
			_prefab=U.chooseChild(prefab.transform);
		}else _prefab=prefab.transform;
		var instance=Spawn(_prefab);
		instance.transform.position=pos;
		enabled=false;
		return instance.gameObject;
	}
	void OnEnable(){
		execute();
	}
}
