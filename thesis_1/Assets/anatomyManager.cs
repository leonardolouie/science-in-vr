using UnityEngine;

public class anatomyManager : MonoBehaviour {
	public static int selectedOrgan = -1;
	private GameObject organSystem;
	humanAnatomyManager manager;
	Material currentMaterial,onClickMat;
	anatomyCamTransitions act;
	// Use this for initialization
	void Start () {
		organSystem = GameObject.FindWithTag ("system");
		manager = FindObjectOfType<humanAnatomyManager> ();
		currentMaterial = gameObject.GetComponent<MeshRenderer> ().material;
		act = FindObjectOfType<anatomyCamTransitions> ();
		onClickMat = manager.onClikMat;
		//defaultMat = gameObject.GetComponent<MeshRenderer> ().material;
	}
	void OnMouseDown(){
		if (!VrOn.isVROn) {
			if (gameObject.GetComponent<MeshRenderer> ().material == onClickMat) {
				gameObject.GetComponent<MeshRenderer> ().material = currentMaterial;
				selectedOrgan = -1;
			} else {
				for (int i = 0; i < organSystem.transform.childCount; i++) {
					organSystem.transform.GetChild (i).GetComponent<MeshRenderer> ().material = organSystem.transform.GetChild (i).GetComponent<anatomyManager> ().currentMaterial;
				}
				gameObject.GetComponent<MeshRenderer> ().material = onClickMat;
				selectedOrgan = transform.GetSiblingIndex ();
			}
		}
	}
	public void selectOrgansForVr(){
		selectedOrgan = transform.GetSiblingIndex ();
		organSystem.transform.GetChild (selectedOrgan).GetComponent<MeshRenderer> ().material = onClickMat;
	}

	public void deselectOrgansForVr ()
	{
		organSystem.transform.GetChild (selectedOrgan).GetComponent<MeshRenderer> ().material = currentMaterial;
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
