using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class VrOn : MonoBehaviour {
	public static bool isVROn = false;
	public Image ret1,splashPanel;
	public GameObject[] objects;
	public GameObject canvasSplash,text;
	// Use this for initialization
	void Update(){
		if (isVROn) {
			if (glaze.ret || planetDialogue.ret)
				ret1.fillAmount += 1f / 2f * Time.deltaTime;
			else
				ret1.fillAmount = 0f;
		}
	}
	public void vrOn(){
		StartCoroutine (activatorVr ("cardboard"));
	}
	public IEnumerator activatorVr(string vrOn){
		//canvas splash screen goes here
		canvasSplash.SetActive(true);
		text.SetActive (true);
		yield return new WaitForSeconds (5f);

		//forGVRPOINTERINPUT MODULE ENABLING
		objects [0].GetComponent<GvrPointerInputModule> ().enabled = true;
		//enabling VR SCENE
		objects [1].SetActive (true);
		//disabling 3D SCENE
		objects [2].SetActive (false);
		splashPanel.CrossFadeAlpha(0.0f,2.0f,false);
		yield return new WaitForSeconds(2f);
		text.SetActive (false);
		canvasSplash.SetActive (false);
		isVROn = true;
		//SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);

		UnityEngine.XR.XRSettings.LoadDeviceByName (vrOn);
		yield return null;
		UnityEngine.XR.XRSettings.enabled = true;
	}
}
