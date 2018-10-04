using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anatomyManager : MonoBehaviour {
	public static int selectedOrgan = -1;
	private GameObject organSystem;
	humanAnatomyManager manager;
	Material currentMaterial,onClickMat,defaultMat;
	anatomyCamTransitions act;
	// Use this for initialization
	void Start () {
		
		organSystem = GameObject.FindWithTag ("system");
		manager = FindObjectOfType<humanAnatomyManager> ();
		currentMaterial = gameObject.GetComponent<MeshRenderer> ().material;
		act = FindObjectOfType<anatomyCamTransitions> ();
		onClickMat = manager.onClikMat;
		defaultMat = manager.defaultMat;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if (currentMaterial == onClickMat) {
			
			currentMaterial = defaultMat;
			gameObject.GetComponent<MeshRenderer> ().material = defaultMat;
			selectedOrgan = -1;
		} else {
			for (int i = 0; i < organSystem.transform.childCount; i++) {
				organSystem.transform.GetChild (i).GetComponent<MeshRenderer> ().material = defaultMat;
			}
			currentMaterial = onClickMat;
			gameObject.GetComponent<MeshRenderer> ().material = onClickMat;

			selectedOrgan = transform.GetSiblingIndex ();
			//act.selectOrgan (selectedOrgan);
		}
	}


	public void showOrgans(){
		for (int i = 0; i < organSystem.transform.childCount; i++) {
				organSystem.transform.GetChild (i).gameObject.SetActive (true);
		}
	}
	public void hideOrgans(){
		if (selectedOrgan >= 0) {
			for (int i = 0; i < organSystem.transform.childCount; i++) {
				if (selectedOrgan == i) {
					organSystem.transform.GetChild (i).gameObject.SetActive (false);
				}
			}
		}
	}
}
