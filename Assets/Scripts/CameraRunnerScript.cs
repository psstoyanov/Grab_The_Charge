using UnityEngine;
using System.Collections;

public class CameraRunnerScript : MonoBehaviour {

	//Camera to follow player
	public Transform player; 

	void LateUpdate () {
		transform.position = new Vector3 (player.position.x + 5.0f, 4, -15);
	}
}
