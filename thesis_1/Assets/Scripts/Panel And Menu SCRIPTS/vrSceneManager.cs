using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class vrSceneManager : MonoBehaviour {

	public GameObject robot,splashPanel,text;
	public Image vrOffSplashImage;
	MainMenu m;
	VrOff a;
	void Start(){
		robot.transform.position = new Vector3 (robot.transform.position.x, 0f, robot.transform.position.z);
		m = FindObjectOfType<MainMenu> ();
		a = FindObjectOfType<VrOff> ();
	}
		
	public void takeOffVrSplash(){
		StartCoroutine (turningOff ());
	}

	IEnumerator turningOff(){

		yield return null;

		splashPanel.SetActive (true);
		text.SetActive (true);
		yield return new WaitForSeconds (10f);
		vrOffSplashImage.CrossFadeAlpha (0f, 2f, false);
		yield return new WaitForSeconds (2f);
		text.SetActive (false);
		UnityEngine.XR.XRSettings.LoadDeviceByName ("none");
		UnityEngine.XR.XRSettings.enabled = false;
		//going to main menu
		m.Home ();
	}
		
	public void startScene(){
		StartCoroutine (summonRobot ());

	}

	IEnumerator summonRobot(){
		while(robot.GetComponent<Transform> ().position.y < 0.587f) {
			robot.GetComponent<Transform> ().position += new Vector3 (0f, 0.005f, 0f);
			yield return null;
		}
		StopAllCoroutines ();
	}
}
