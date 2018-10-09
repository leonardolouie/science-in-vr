using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class anatomyDialogue : MonoBehaviour {
	//public GameObject canvasPlanets, canvasInfo;
	//THIS GLAZE IS FOR THE DESCRIPTION 
	//OF ALL THE OJEBJECTS IN 3D MODE
	public Dialogue dialogue;



	public static bool ret;
	private bool gazeAt;
	public static bool hasSelect = false;

	float gazeTime = 2f;
	private float timer;
	public bool isOrgan;
	public static float minZoom,maxZoom;
	public static int selectedOrgans = -1; 

	anatomyCamTransitions camTransition;
	anatomyManager anam;
	humanAnatomyManager anamManager;
	int organNo;
	void Start(){
		anamManager = FindObjectOfType<humanAnatomyManager> ();
		anam = FindObjectOfType<anatomyManager> ();
		camTransition = FindObjectOfType<anatomyCamTransitions> ();
		defaultView ();
	}
	void Update () {
		if (VrOn.isVROn) {
			if (gazeAt) {
				timer += Time.deltaTime;
				if (timer >= gazeTime) {
					ExecuteEvents.Execute (gameObject, new PointerEventData (EventSystem.current), ExecuteEvents.pointerDownHandler);
					timer = 0f;
				}
			}
		}
	}
	public void PointerEnter(){
		if (VrOn.isVROn) {
			
			anamManager.playRotation (false);
			anam.selectOrgansForVr (transform.GetSiblingIndex ());
			gazeAt = true;
			ret = true;
		}
	}
	IEnumerator destroyPanel(GameObject panel){

		yield return new WaitForSeconds (10f);
		if (panel != null) {
			Destroy (panel);
			anamManager.playRotation (true);
			hasSelect = false;
		}
	
	}
	public void PointerDown(){
		if (VrOn.isVROn) {
			//means the vr is on , here you can add all the events when ur in vr mode
			gazeAt = false;
			if (isOrgan) {
				hasSelect = true;


				selectedOrgans = transform.GetSiblingIndex ();

				if (GameObject.FindWithTag ("animcanvas") != null) {
					GameObject cpanel = GameObject.FindWithTag ("animcanvas");
					cpanel.GetComponent<Animator> ().SetTrigger ("show");
					Destroy (cpanel,.25f);
				}
				//Destroy (GameObject.FindWithTag ("animcanvas"));

				GameObject panel = Instantiate (anamManager.animPanelShow,GameObject.FindWithTag("canvas").transform)as GameObject;
				panel.transform.position = transform.position;
				panel.GetComponent<Animator> ().SetTrigger ("show");
				if (panel != null) {
					StartCoroutine (destroyPanel (panel));
				}
				anamManager.infoScreen (dialogue.name, dialogue.sentences);
			}
		} else {
			
			hasSelected (true);
			FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
			//dito pwede ung double tap ilagay this is the change of pivot
			//lerp = true;
		}

	}
	public void PointerExit(){
		if (VrOn.isVROn)
		{
			if(!hasSelect)
				anamManager.playRotation (true);
			anam.deselectOrgansForVr (transform.GetSiblingIndex());
			timer = 0f;
			gazeAt = false;
			ret = false;
		}
	}


	public void defaultView() {
		minZoom = 2f;
		maxZoom = 5f;
	}

	public void hasSelected(bool a){
		hasSelect = a;
	}
}
