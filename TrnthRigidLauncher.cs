using UnityEngine;
using System.Collections;

public class TrnthRigidLauncher : TrnthHVSAction {
	public TrnthSpawn spawner;
	public Vector3 velocityInit;
	public Vector3 noise;
	protected override void _execute(){
		base._execute();
		var instance=spawner.execute();
		var rig=instance.rigidbody;
		rig.velocity=transform.TransformDirection(velocityInit+Random.value*noise);
	}
}
