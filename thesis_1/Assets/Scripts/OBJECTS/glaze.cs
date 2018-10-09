using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class glaze : MonoBehaviour {
	public static bool ret;
	public float gazeTime = 2f;
	private float timer;
	private bool gazeAt;
	anatomyDialogue anaDiag;
	humanAnatomyManager anaManager;
	public GameObject canvasPlanets, canvasInfo;
	public Dialogue dialogue;
	public Text planetName,planetInfo;
	public bool planet = false,anatomyButton = false;
	// Use this for initialization
	void Start () {
		anaManager = FindObjectOfType<humanAnatomyManager> ();
		anaDiag = FindObjectOfType<anatomyDialogue> ();
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
		if (planet) {
			planetName.text = dialogue.name;
			planetInfo.text = dialogue.sentences;
			canvasInfo.SetActive (true);
			canvasPlanets.SetActive (false);
		}
		if (anatomyButton) {
				
		}
	}
	public void PointerExit(){
		timer = 0f;
		gazeAt = false;
		ret = false;
	}
		
	public void hideOrgansInVr(){
		GameObject.FindWithTag ("system").transform.GetChild (anatomyDialogue.selectedOrgans).gameObject.SetActive (false);
		GameObject panelAnim = GameObject.FindWithTag ("animcanvas");
		panelAnim.GetComponent<Animator> ().SetTrigger ("show");
		Destroy (panelAnim, .25f);
		anaManager.playRotation (true);
		anaDiag.hasSelected (false);

	}

	public void Show(){
		anaManager.showMoreInfo ();
	}
}
