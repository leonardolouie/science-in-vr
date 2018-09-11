using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuPanel : MonoBehaviour {
	public Transform cam,camMain;
	float dist;
	Vector3 fix;
	private Animator anim;
	void Start(){
		//Initialization of the distance between the camera and the also the animati
		//fix = transform.position;
		anim = gameObject.GetComponent<Animator> ();
	}
	void Update () {
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x,camMain.eulerAngles.y,camMain.eulerAngles.z);
		//if (cam.eulerAngles.x > 0)
			//transform.position = fix;
		//panel follow camera code
		if (cam.eulerAngles.x >= 65 && cam.eulerAngles.x <= 100)
			anim.SetInteger ("menuToggle", 1);
		if (cam.eulerAngles.x <= 50 && cam.eulerAngles.x >= 1)
			anim.SetInteger ("menuToggle", 0);
	}
	public void panelToggle(){
	}
}