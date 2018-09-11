using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.UI;
public class VrOff : MonoBehaviour {
	public Image splashPanel;
	public GameObject[] objects;
	public GameObject canvasSplash;
	// Use this for initialization
	void Update(){
	}
	public void vrOff(){
		StartCoroutine (activatorVr ("none"));
	}

	public IEnumerator activatorVr(string vrOff){
		//canvas splash screen goes here
		canvasSplash.SetActive(true);
		yield return new WaitForSeconds (3f);
		UnityEngine.XR.XRSettings.LoadDeviceByName (vrOff);
		splashPanel.CrossFadeAlpha(0.0f,2.0f,false);
		yield return new WaitForSeconds(2f);
		canvasSplash.SetActive (false);
		objects [0].GetComponent<GvrPointerInputModule> ().enabled = false;
		objects [1].SetActive (false);
		objects [2].SetActive (false);
		objects [3].SetActive (true);
		objects [4].SetActive (false);
		UnityEngine.XR.XRSettings.enabled = false;
		//SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		Debug.Log ("VR IS NOW OFF");
		//Application.LoadLevel(Application.LoadLevel);
	}
}
