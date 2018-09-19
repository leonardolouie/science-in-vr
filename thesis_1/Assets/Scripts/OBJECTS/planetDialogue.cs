using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class planetDialogue : MonoBehaviour {

	//THIS GLAZE IS FOR THE DESCRIPTION 
	//OF ALL THE OJEBJECTS IN 3D MODE
	public Dialogue dialogue;

	public static bool ret;
	private bool gazeAt;
	public static bool hasSelect;

  	float gazeTime = 2f;
    private float timer;

	public static float minZoom,maxZoom;
    public static int selectedPlanet;
    public int planetNo;
	void Start(){
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
			gazeAt = true;
			ret = true;
		}
	}
	public void PointerDown(){
		if (VrOn.isVROn) {
			//means the vr is on , here you can add all the events when ur in vr mode
			hasSelect = true;
			gazeAt = false;
			selectedPlanet = planetNo;
		} else {
			FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
			//dito pwede ung double tap ilagay this is the change of pivot
			//lerp = true;
			hasSelect = true;
            selectedPlanet = planetNo;

			if (selectedPlanet == 9)
				defaultView ();
			else {
				minZoom = 250f;
				maxZoom = 500f;
			}
		}
			
	}
	public void PointerExit(){
        if (VrOn.isVROn)
        {
            timer = 0f;
            gazeAt = false;
            ret = false;
        }
	}


    public void defaultView() {
		minZoom = 300f;
		maxZoom = 1200f;
    }

	public void hasSelected(bool a){
		hasSelect = a;
	}
	public void planetNumber(int a){
		planetNo = a;
	}
}
