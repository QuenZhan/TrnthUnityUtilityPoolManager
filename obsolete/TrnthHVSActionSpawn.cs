﻿using UnityEngine;
using System.Collections;
using PathologicalGames;
public class TrnthHVSActionSpawn : TrnthHVSActionPoolBase {
	public bool beChild=false;
	public bool positionFit=true;
	public bool rotationFit;
	public bool instantiateIfNoPool=false;
	public string rename="";
	public float despawnAfter=1;
	[HideInInspector]
	public TrnthHVSCondition onSucceed;
	[HideInInspector]
	public TrnthHVSCondition onFail;
	public Transform spawned{get;private set;}
	public GameObject spawn(GameObject go){
		prefab=go;
		_execute();
		return spawned.gameObject;
	}
	protected override void _execute(){
		spawned=null;
		base._execute();
		var position=prefab.transform.position;
		var rotation=prefab.transform.rotation;
		Transform parent=null;
		if(positionFit)position=this.transform.position;
		if(rotationFit)rotation=this.transform.rotation;
		if(beChild)parent=this.transform;
		var canPooling=PoolManager.Pools.ContainsKey(this.pool);
		if(!canPooling){
			Debug.LogWarning("PoolManager.Pools has no pool : "+this.pool,transform);
			if(instantiateIfNoPool)spawned=(Instantiate(prefab) as GameObject).transform;
		}else{
			prefab.transform.position=position;
			spawned=PoolManager.Pools[this.pool].Spawn(prefab.transform,position,rotation,parent);
		}
		if(!spawned){
			if(onFail)onFail.send();
			return;
		}
		if(rename!="")spawned.name=rename;
		if(onSucceed)onSucceed.send();
		if(despawnAfter>0){
			if(canPooling)PoolManager.Pools[this.pool].Despawn(spawned,despawnAfter);
			else {
				Debug.LogWarning("!canPooling",transform);
				if(instantiateIfNoPool)Destroy(spawned.gameObject,despawnAfter);
			}
		}
	}
}