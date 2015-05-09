using UnityEngine;
using System.Collections;

public class TrnthTemplateProjectile : MonoBehaviour {
	public float lifetime=5;
	public float timerActivate=0.5f;
	public Collider col;
	public Rigidbody rigid;
	public ParticleSystem loop;
	public TrnthHVSActionSpawn fxStart;
	public TrnthHVSActionSpawn fxHit;
	public TrnthHVSActionSpawn fxEnd;
	public TrnthHVSCondition attackSender;
	public void initialize(){
		col.enabled=false;
		rigid.transform.localPosition=Vector3.zero;
		loop.Play();
		fxStart.execute();
		Invoke("enableCollider",timerActivate);
		Invoke("hit",5);
	}
	public void hit(){
		col.enabled=false;
		loop.Stop();
		fxHit.execute();
	}
	void OnDespawn(){
		rigid.transform.localPosition=Vector3.zero;
		col.enabled=false;
	}
	void enableCollider(){
		col.enabled=true;
	}
}
