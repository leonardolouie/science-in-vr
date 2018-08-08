using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
public class VrOff : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (deactivatorVr ("none"));
	}
	public IEnumerator deactivatorVr(string vrOff){
		UnityEngine.XR.XRSettings.LoadDeviceByName (vrOff);
		yield return null;
		UnityEngine.XR.XRSettings.enabled = false;
	}
}
