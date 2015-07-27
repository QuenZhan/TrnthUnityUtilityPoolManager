using UnityEngine;
using System.Collections;
using System.Linq;
using TRNTH;
using PathologicalGames;

public class TrnthSpawnBoucingNumber:TrnthSpawn{
	public TrnthHVSConditionAttackReceiver reciever;
	// public 
	// public TrnthSender
	public int damage;
	public override GameObject execute(){
		if(reciever){
			if(!reciever.result.showDamage)return null;
			damage=(int)reciever.damage;
		}
		var instance=base.execute();
		if(instance){
			var bn=instance.GetComponent<TrnthBoucingNumber>();
			bn.setup((int)damage);
		}
		var pool=PoolManager.Pools[poolName];
		pool.Despawn(instance.transform,3f);
		return instance;
	}
}
