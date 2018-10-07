using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class robotGlaze : MonoBehaviour {


	public static bool ret;
	private bool gazeAt;
	public static bool robotSelected;
	float gazeTime = 2f;
	private float timer;

	// Use this for initialization
	void Start () {

	}
	public void try1(){

	}
	// Update is called once per frame
	void Update () {
		if (gazeAt) {
			timer += Time.deltaTime;
			if (timer >= gazeTime){
				ExecuteEvents.Execute (gameObject, new PointerEventData (EventSystem.current), ExecuteEvents.pointerDownHandler);
				timer = 0f;
			}
		}
	}
	public void PointerEnter(){
		gazeAt = true;
		ret = true;
	}
	public void PointerDown(){
		gazeAt = false;
	}

	public void PointerExit(){
		timer = 0f;
		gazeAt = false;
		ret = false;
	}
}