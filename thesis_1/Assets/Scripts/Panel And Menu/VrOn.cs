using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.SceneManagement;
public class VrOn : MonoBehaviour {

	public GameObject[] scripts;
	// Use this for initialization
	public void Start () {
		
	}
	public void vrOn(){
		StartCoroutine (activatorVr ("cardboard"));
	}

	public IEnumerator activatorVr(string vrOn){
		UnityEngine.XR.XRSettings.LoadDeviceByName (vrOn);
		yield return null;
		scripts [0].GetComponent<GvrEditorEmulator>().enabled = true;
		scripts [1].GetComponent<GvrReticlePointer> ().enabled = true;
		UnityEngine.XR.XRSettings.enabled = true;
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		Debug.Log ("asd");
		//Application.LoadLevel(Application.LoadLevel);
	}
}
