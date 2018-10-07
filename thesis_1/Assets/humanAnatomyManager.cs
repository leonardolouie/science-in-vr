using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class humanAnatomyManager : MonoBehaviour {
	public Text header;
	int whatSystem;
	public GameObject[] anatomySystemsPrefabs;
	public Material onClikMat;
	anatomyManager anatomymanager;
	public Transform spawnPointVr,humanBase;
	void Awake(){
		if (!VrOn.isVROn) {
			whatSystem = PlayerPrefs.GetInt ("whatSystem", 0);
			switch (whatSystem) {
			case 0:
				header.text = "Digestive System";
				break;
			case 1:
				header.text = "Respiratory System";
				break;
			case 2:
				header.text = "Urinary System";
				break;
			default:
				break;
			}

			Instantiate (anatomySystemsPrefabs [whatSystem],humanBase.position, anatomySystemsPrefabs [whatSystem].transform.rotation);
			anatomymanager = FindObjectOfType<anatomyManager> ();
		}
	}
	public void hide(){
		anatomymanager.hideOrgans ();
	}
	public void showAll(){
		anatomymanager.showOrgans ();
	}
		
	public void vrOn(){
		Destroy (GameObject.FindWithTag ("system"));
		//Invoke ("a", 10f);
		GameObject a = Instantiate (anatomySystemsPrefabs [whatSystem], spawnPointVr.position, anatomySystemsPrefabs [whatSystem].transform.rotation) as GameObject;
		a.transform.SetParent (spawnPointVr);
	}
}