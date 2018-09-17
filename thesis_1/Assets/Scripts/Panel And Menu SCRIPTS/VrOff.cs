using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.UI;
public class VrOff : MonoBehaviour {
	public GameObject[] objects;
	void Start(){
		if (PlayerPrefs.GetInt ("isVrOn", 0) == 0) {
			//if we select in the main menu the vr mode
			vrOff ();
		}
	}

	public void vrOff(){
		StartCoroutine (activatorVr ("none"));
	}

	public IEnumerator activatorVr(string vrOff){
		//canvas splash screen goes here
		yield return new WaitForSeconds (5f);
		objects [0].GetComponent<GvrPointerInputModule> ().enabled = false;
		objects [1].SetActive (true);
		objects [2].SetActive (false);
		//splashPanel.CrossFadeAlpha(0.0f,2.0f,false);
		yield return new WaitForSeconds (2f);
		UnityEngine.XR.XRSettings.LoadDeviceByName (vrOff);
		UnityEngine.XR.XRSettings.enabled = false;
		//canvasSplash.SetActive (false);

		//SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		Debug.Log ("VR IS NOW OFF");
		//Application.LoadLevel(Application.LoadLevel);
	}
}
