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
	public GameObject canvasSplash;

	// Use this for initialization
	void Update(){
		if (glaze.ret || planetDialogue.ret)
			ret1.fillAmount += 1f / 2f * Time.deltaTime;
		else
			ret1.fillAmount = 0f;
	}
	public void vrOn(){
		StartCoroutine (activatorVr ("cardboard"));
	}

	public IEnumerator activatorVr(string vrOn){
		//canvas splash screen goes here
		canvasSplash.SetActive(true);
		yield return new WaitForSeconds (3f);
		FindObjectOfType<planetDialogue> ().planetNumber (0);
		UnityEngine.XR.XRSettings.LoadDeviceByName (vrOn);
		UnityEngine.XR.XRSettings.enabled = true;
		objects [0].GetComponent<GvrPointerInputModule> ().enabled = true;
		objects [1].SetActive (true);
		objects [2].SetActive (true);
		objects [3].SetActive (false);
		splashPanel.CrossFadeAlpha(0.0f,2.0f,false);
		yield return new WaitForSeconds(2f);
		canvasSplash.SetActive (false);
		isVROn = true;

		//SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		Debug.Log ("VR IS NOW ON");
		//Application.LoadLevel(Application.LoadLevel);
	}
}
