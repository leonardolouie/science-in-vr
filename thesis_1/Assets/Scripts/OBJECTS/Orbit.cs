using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

	public GameObject sun;
	public float speed;
	public GameObject axis;
	public float axisSpeed;
	public static int flag;
	public int planetPosition;
	// Update is called once per frames
	void Update () {
		OrbitAround ();
		spin ();

		if (pZoom.zoomFactor >= 25)
			flag = 0;
	}
	void OnMouseOver(){
		if (Input.GetMouseButtonUp (0)) {
			flag = planetPosition;
		} 
	
	}
	void OrbitAround(){
		transform.RotateAround (sun.transform.localPosition, Vector3.up, speed * Time.deltaTime);
	}
	void spin(){
		transform.RotateAround (axis.transform.position, Vector3.up, axisSpeed * Time.deltaTime);
	}
}
