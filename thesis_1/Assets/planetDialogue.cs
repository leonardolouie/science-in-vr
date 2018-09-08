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

	public GameObject border;

    public float gazeTime = 2f;
    private float timer;

	public static float minZoom=200f,maxZoom=1500f;
    public static int selectedPlanet;
    public int planetNo;
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
			gazeAt = false;
		} else {
			FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
			//dito pwede ung double tap ilagay this is the change of pivot
			//lerp = true;
            selectedPlanet = planetNo;
			StartCoroutine (popUpBorder ());
             minZoom=100f;
             maxZoom = 300f;
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
	IEnumerator popUpBorder(){
		border.SetActive (true);
		yield return new WaitForSeconds (10f);
		border.SetActive (false);
	}

    public void defaultView() {
        selectedPlanet = 0;
        minZoom = 200f;
        maxZoom = 1500f;
    }
}
