using UnityEngine;
using System.Collections;
using System.Linq;
using TRNTH;
public class TrnthSpawnBoucingNumber:TrnthSpawn{
	public int damage;
	public override GameObject execute(){
		var instance=base.execute();
		if(instance){
			var bn=instance.GetComponent<TrnthBoucingNumber>();
			bn.setup((int)damage);
		}
		return instance;
	}
}
