using UnityEngine;
using System.Collections;
using System.Linq;
using TRNTH;

[RequireComponent(typeof(TrnthSpawn))]
public class TrnthHVSActionSpawener : TrnthHVSAction{
	protected override void _execute(){
		if(!_spawner)_spawner=GetComponent<TrnthSpawn>();
		_spawner.execute();
	}
	TrnthSpawn _spawner;
}
