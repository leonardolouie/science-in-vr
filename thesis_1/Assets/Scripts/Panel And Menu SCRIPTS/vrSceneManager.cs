using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class vrSceneManager : MonoBehaviour {



	public GameObject[] planetPrefabs;


	public GameObject splashPanel,text,planetSpawner,fade;
	public Image vrOffSplashImage,FADEPHOTO;
	MainMenu m;
	VrOff a;


	void Start(){
		m = FindObjectOfType<MainMenu> ();
		a = FindObjectOfType<VrOff> ();
	}
		
	public void takeOffVrSplash(){
		StartCoroutine (turningOff ());
	}


	//will be held to all buttons for parameters
	public void selectThePlanet(int a){
		StartCoroutine (showPlanet (a));
	}
		
	IEnumerator showPlanet(int planetNo){
		fade.SetActive (true);
		FADEPHOTO.canvasRenderer.SetAlpha (0f);
		FADEPHOTO.CrossFadeAlpha (1f, 3f, false);
		yield return new WaitForSeconds (3f);
		if (planetSpawner.transform.childCount > 0) {
			DestroyImmediate (planetSpawner.transform.GetChild (0).gameObject);
		}
		GameObject b = Instantiate (planetPrefabs [planetNo - 1], planetSpawner.transform.position,Quaternion.identity) as GameObject;
		b.transform.SetParent (planetSpawner.transform);
		yield return new WaitForSeconds (2f);
		FADEPHOTO.CrossFadeAlpha (0f, 3f, false);
		yield return new WaitForSeconds (3f);
		fade.SetActive (false);

		yield return null;

		// any actions goes here
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
}
