using UnityEngine;
using System.Collections;

public class TrnthResetPosition : MonoBehaviour {
	void OnDisable(){
		transform.localPosition=Vector3.zero;
	}
}
