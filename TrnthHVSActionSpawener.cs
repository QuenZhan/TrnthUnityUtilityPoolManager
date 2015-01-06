using UnityEngine;
using System.Collections;
using System.Linq;
using TRNTH;
public class TrnthHVSActionSpawener : TrnthHVSAction{
	public TrnthSpawn spawner;
	protected override void _execute(){
		base._execute();
		if(!spawner)spawner=GetComponent<TrnthSpawn>();
		spawner.execute();
	}
}
