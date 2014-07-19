using UnityEngine;
using System.Collections.Generic;

public class TrnthUiNavigation : TrnthPoolBase {
	static public TrnthUiNavigation main;
	public List<GameObject> list;
	public void push(GameObject prefab){
		GameObject e=Spawn(prefab);
		list.Add(e);
		e.transform.position=pos;		
	}
	public void pop(){
		if(list.Count<1)return;
		var last=list[list.Count-1];
		list.Remove(last);
		Despawn(last);
	}
	public override void Awake(){
		base.Awake();
		main=this;
	}
}