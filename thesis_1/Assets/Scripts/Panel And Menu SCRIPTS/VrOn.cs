using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class VrOn : MonoBehaviour {


	public Animator vrMode;
	public static bool isVROn = false;
	public Image ret1,splashPanel;
	public GameObject[] objects;
	public GameObject canvasSplash,text;
	// Use this for initialization'
	robotPatrol rb;
	void Start(){
		rb = FindObjectOfType<robotPatrol> ();
	}
	void Update(){
		if (isVROn) {
			if (glaze.ret)
				ret1.fillAmount += 1f / 2f * Time.deltaTime;
			else
				ret1.fillAmount = 0f;
		}
	}
	public void vrOn(){
		if (!SystemInfo.supportsGyroscope) {
			StartCoroutine (activatorVr ("cardboard"));
		} else {
			StartCoroutine (cantVrMode ());
		}
	}

	IEnumerator cantVrMode(){
		text.GetComponent<Text> ().text = "Sorry, your device doesn't support gyroscope";
		canvasSplash.SetActive (true);
		text.SetActive (true);
		yield return new WaitForSeconds (2f);
		splashPanel.CrossFadeAlpha (0.0f, 2.0f, false);
		yield return new WaitForSeconds (2f);
		text.SetActive (false);
		canvasSplash.SetActive (false);
		vrMode.SetTrigger ("vrModeClick");
	}

	public IEnumerator activatorVr(string vrOn){
		//canvas splash screen goes here


			
			isVROn = true;
			canvasSplash.SetActive (true);
			text.SetActive (true);
			yield return new WaitForSeconds (5f);

			//forGVRPOINTERINPUT MODULE ENABLING
			objects [0].GetComponent<GvrPointerInputModule> ().enabled = true;
			//enabling VR SCENE
			objects [1].SetActive (true);
			//disabling 3D SCENE
			objects [2].SetActive (false);
			splashPanel.CrossFadeAlpha (0.0f, 2.0f, false);
			yield return new WaitForSeconds (2f);
			text.SetActive (false);
			canvasSplash.SetActive (false);

			//SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);

			XRSettings.LoadDeviceByName (vrOn);
			yield return null;

			XRSettings.enabled = true;
		rb.Start ();
	
	}
}
