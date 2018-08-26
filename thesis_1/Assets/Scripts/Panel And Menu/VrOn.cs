using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class VrOn : MonoBehaviour {
	public Image ret1,splashPanel;
	public GameObject[] objects;
	public GameObject canvasSplash;
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
		//canvas splash screen goes here
		canvasSplash.SetActive(true);
		yield return new WaitForSeconds (3f);
		UnityEngine.XR.XRSettings.LoadDeviceByName (vrOn);
		splashPanel.CrossFadeAlpha(0.0f,2.0f,false);
		yield return new WaitForSeconds(2f);
		canvasSplash.SetActive (false);
		objects [0].GetComponent<GvrPointerInputModule> ().enabled = true;
		objects [1].SetActive (true);
		objects [2].SetActive (true);
		objects [3].SetActive (false);
		objects [4].SetActive (true);


		/*scripts [0].GetComponent<GvrEditorEmulator>().enabled = true;
		scripts [0].GetComponent<pZoom>().enabled = false;
		scripts [0].GetComponent<cameraOrbit>().enabled = false;
		scripts [1].GetComponent<GvrReticlePointer> ().enabled = true;
		scripts [1].GetComponent<MeshRenderer> ().enabled = true;
		scripts [2].GetComponent<GvrPointerInputModule> ().enabled = true;
		ret2.enabled = true;*/
		UnityEngine.XR.XRSettings.enabled = true;
		//SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		Debug.Log ("VR IS NOW ON");
		//Application.LoadLevel(Application.LoadLevel);
	}
}
