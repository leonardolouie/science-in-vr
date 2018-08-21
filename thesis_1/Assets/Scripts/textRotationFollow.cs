using UnityEngine;

public class textRotationFollow : MonoBehaviour {
	//signifies the camera
	public Transform player;
	void Update () { 
		Vector3 direction = player.position - transform.parent.position;
		Quaternion rotation = Quaternion.LookRotation (-direction);
		transform.rotation = rotation;
	}
}
