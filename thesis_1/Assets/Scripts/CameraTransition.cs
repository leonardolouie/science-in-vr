using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour {
	


	public Transform[] views;
	public float transSpeed = 2;
	public Transform currentView;
	int a;
	// Use this for initialization 
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

		if (Orbit.flag == 0)
			currentView = views [0];
		if (Orbit.flag == 1) {
			currentView = views [1];
		}
		if (Orbit.flag == 2) {
			currentView = views [2];
		}
		if (Orbit.flag == 3) {
			currentView = views [3];
		}
		if (Orbit.flag == 4) {
			currentView = views [4];
		}
		if (Orbit.flag == 5) {
			currentView = views [5];
		}
		if (Orbit.flag == 6) {
			currentView = views [6];
		}
		if (Orbit.flag == 7) {
			currentView = views [7];
		}
		if (Orbit.flag == 8) {
			currentView = views [8];
		}
		//if (Orbit.flag == 1)
			//currentView = views [1];    INTENDED FOR PLLUTO
	}


		
	void LateUpdate(){
		transform.position = Vector3.Lerp (transform.position, currentView.position, Time.deltaTime * transSpeed);
		Vector3 curr = new Vector3 (
			Mathf.LerpAngle(transform.rotation.eulerAngles.x,currentView.transform.eulerAngles.x,Time.deltaTime * transSpeed),
			Mathf.LerpAngle(transform.rotation.eulerAngles.y,currentView.transform.eulerAngles.y,Time.deltaTime * transSpeed),
			Mathf.LerpAngle(transform.rotation.eulerAngles.z,currentView.transform.eulerAngles.z,Time.deltaTime * transSpeed)
		);

		transform.eulerAngles = curr;
		/*Vector3 direction = planet.position - transform.position;
			Quaternion rotation = Quaternion.LookRotation (direction);
			transform.rotation = rotation;*/
	}
}