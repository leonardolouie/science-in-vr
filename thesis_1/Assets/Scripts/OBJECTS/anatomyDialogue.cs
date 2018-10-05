using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class anatomyDialogue : MonoBehaviour {

	//THIS GLAZE IS FOR THE DESCRIPTION 
	//OF ALL THE OJEBJECTS IN 3D MODE
	public Dialogue dialogue;

	public static bool ret;
	private bool gazeAt;
	public static bool hasSelect = false;

	float gazeTime = 2f;
	private float timer;

	public static float minZoom,maxZoom;
	public static int selectedOrgans = -1; 

	anatomyCamTransitions camTransition;
	anatomyManager anam;
	int organNo;
	void Start(){
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
			anam.selectOrgansForVr ();
			gazeAt = true;
			ret = true;
		}
	}
	public void PointerDown(){
		if (VrOn.isVROn) {
			//means the vr is on , here you can add all the events when ur in vr mode
			gazeAt = false;
		} else {
			//selectedOrgans = transform.GetSiblingIndex ();
			FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
			//dito pwede ung double tap ilagay this is the change of pivot
			//lerp = true;
		}

	}
	public void PointerExit(){
		if (VrOn.isVROn)
		{
			anam.deselectOrgansForVr ();
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
