using UnityEngine;
using System.Collections;
using System.Linq;
using TRNTH;
public class TrnthSpawn : TrnthPoolBase{
	public GameObject prefab;
	public TrnthPhysicsCast phyiscsCast;
	public bool chooseInChildren=false;
	public bool beChild=false;
	public bool worldRotationFit;
	public float probability=1;
	public float delay=0;
	public GameObject execute(){
		if(probability<Random.value)return null;
		if(phyiscsCast){
			phyiscsCast.update();
			if(phyiscsCast.colliders.Length>0)return null;
		}
		Transform _prefab;
		if(chooseInChildren){
			var q=from t in getChildren(prefab.transform)
				where t.gameObject.activeSelf
				select t;
			_prefab=U.choose<Transform>(q.ToArray());
		}else _prefab=prefab.transform;
		var instance=Spawn(_prefab);
		if(!instance)return null;
		instance.transform.position=pos;
		if(worldRotationFit){
			instance.transform.eulerAngles=transform.eulerAngles;
		}
		if(beChild)instance.transform.parent=transform;
		return instance.gameObject;
	}
	void OnEnable(){
		//execute();
		Invoke("execute",delay);
	}
	// void OnSpawned(){
	// 	if(executeOnSpawned)Invoke("execute",delay);
	// }
}
