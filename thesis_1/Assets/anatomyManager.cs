using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anatomyManager : MonoBehaviour {
	public static int selectedOrgan = -1;
	private GameObject organSystem;
	humanAnatomyManager manager;
	public static Material currentMaterial,onClickMat,defaultMat;
	anatomyCamTransitions act;
	// Use this for initialization
	void Start () {
			
		organSystem = GameObject.FindWithTag ("system");
		manager = FindObjectOfType<humanAnatomyManager> ();
		currentMaterial = gameObject.GetComponent<MeshRenderer> ().material;
		act = FindObjectOfType<anatomyCamTransitions> ();
		onClickMat = manager.onClikMat;
		defaultMat = gameObject.GetComponent<MeshRenderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if (!VrOn.isVROn) {
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
	}


	public void selectOrgansForVr(){
		selectedOrgan = this.transform.GetSiblingIndex ();
		organSystem.transform.GetChild (selectedOrgan).GetComponent<MeshRenderer> ().material = onClickMat;
	}

	public void deselectOrgansForVr ()
	{
		organSystem.transform.GetChild (selectedOrgan).GetComponent<MeshRenderer> ().material = defaultMat;
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
