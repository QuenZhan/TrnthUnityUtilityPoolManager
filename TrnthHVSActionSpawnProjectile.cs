using UnityEngine;
using System.Collections;

public class TrnthHVSActionSpawnProjectile : TrnthHVSActionSpawn {
	public Vector3 velocityInit;
	public Vector3 noise;
	protected override void _execute(){
		base._execute();
		var instance=spawned;
		var rig=instance.GetComponent<TrnthTemplateProjectile>().rigid;
		var vec=new Vector3(velocityInit.x+Random.value*noise.x
			,velocityInit.y+Random.value*noise.y
			,velocityInit.z+Random.value*noise.z);
		rig.velocity=transform.TransformDirection(vec);
	}
}
