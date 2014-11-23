using UnityEngine;
using System.Collections;

public class TrnthRigidLauncher : MonoBehaviour {
	public TrnthSpawn spawner;
	public Vector3 velocityInit;
	public Vector3 noise;
	public void execute(){
		var instance=spawner.execute();
		var rig=instance.rigidbody;
		rig.velocity=transform.TransformDirection(velocityInit+Random.value*noise);
	}
	void OnEnable(){
		execute();
	}
}
