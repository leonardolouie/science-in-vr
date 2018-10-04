using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanAnatomyManager : MonoBehaviour {
	int whatSystem;
	public GameObject[] anatomySystemsPrefabs;
	public Material onClikMat,defaultMat;
	anatomyManager anatomymanager;
	void Awake(){
		whatSystem = PlayerPrefs.GetInt ("whatSystem", 0);
		Instantiate (anatomySystemsPrefabs [whatSystem],Camera.main.transform.position+ new Vector3(0f,-.7f,1.3f),anatomySystemsPrefabs[whatSystem].transform.rotation);
		anatomymanager = FindObjectOfType<anatomyManager> ();
	}
	public void hide(){
		anatomymanager.hideOrgans ();
	}
	public void showAll(){
		anatomymanager.showOrgans ();
	}
}