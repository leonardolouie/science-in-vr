using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.UI;
public class VrOff : MonoBehaviour {
	public GameObject[] objects;
	public Animator anim;

	void Awake(){
		PlayerPrefs.SetInt ("scene", 1);
	}
	void Start(){
		if (PlayerPrefs.GetInt ("isVrOn", 0) == 0) {
			//if we select in the main menu the vr mode
			vrOff ();
			anim.GetComponent<Animator> ().SetTrigger ("Pressed");
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

		//canvasSplash.SetActive (false);

		//SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		Debug.Log ("VR IS NOW OFF");
		//Application.LoadLevel(Application.LoadLevel);
		UnityEngine.XR.XRSettings.LoadDeviceByName (vrOff);
		yield return null;
		UnityEngine.XR.XRSettings.enabled = false;
	}
}
