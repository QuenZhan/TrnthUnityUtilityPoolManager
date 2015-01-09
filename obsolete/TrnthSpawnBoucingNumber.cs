﻿using UnityEngine;
using System.Collections;
using System.Linq;
using TRNTH;
public class TrnthSpawnBoucingNumber:TrnthSpawn{
	public TrnthAttackReceiver reciever;
	// public 
	// public TrnthSender
	public int damage;
	public override GameObject execute(){
		if(reciever){
			if(!reciever.attack.showDamage)return null;
			damage=(int)reciever.damage;
		}
		var instance=base.execute();
		if(instance){
			var bn=instance.GetComponent<TrnthBoucingNumber>();
			bn.setup((int)damage);
		}
		return instance;
	}
}
