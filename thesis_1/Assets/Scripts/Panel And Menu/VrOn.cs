using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class VrOn : MonoBehaviour {
	public Image ret1,ret2;
	public GameObject[] scripts;
	// Use this for initialization
	void Update(){
		if (glaze.ret)
			ret1.fillAmount += 1f / 2f * Time.deltaTime;
		else
			ret1.fillAmount = 0f;
	}
	public void vrOn(){
		StartCoroutine (activatorVr ("cardboard"));
	}

	public IEnumerator activatorVr(string vrOn){
		UnityEngine.XR.XRSettings.LoadDeviceByName (vrOn);
		yield return null;
		scripts [0].GetComponent<GvrEditorEmulator>().enabled = true;
		scripts [0].GetComponent<pZoom>().enabled = false;
		scripts [0].GetComponent<cameraOrbit>().enabled = false;
		scripts [1].GetComponent<GvrReticlePointer> ().enabled = true;
		scripts [2].GetComponent<GvrPointerInputModule> ().enabled = true;
		ret2.enabled = true;
		UnityEngine.XR.XRSettings.enabled = true;
		//SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		Debug.Log ("asd");
		//Application.LoadLevel(Application.LoadLevel);
	}
}
