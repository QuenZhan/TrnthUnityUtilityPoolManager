using UnityEngine;
using System.Collections;
public class TrnthDespawn : TrnthPoolBase {
	public GameObject targetToDespawn;
	public float delay;
	public virtual void execute(){
		Despawn(targetToDespawn.transform);
	}
	public override void Awake(){
		base.Awake();
		if(!targetToDespawn)targetToDespawn=gameObject;
	}
	void OnEnable(){
		CancelInvoke();
		Invoke("execute",delay);
	}
}
