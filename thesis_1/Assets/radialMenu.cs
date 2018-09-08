using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radialMenu : MonoBehaviour {

	public radialButton buttonPrefab;
	public bool autoSpaceButton;
	public int numberOfButton = 6;
	public float buttonSize = 50f;
	public float distanceFromCenter = 50f;

	public RectTransform newButtonRect;
	// Use this for initialization
	void Start () {
		
	}
	public void SpawnButtons(materialChanger obj){
		for (int i = 0; i < obj.materials.Length; i++) {
			radialButton newButton = Instantiate (buttonPrefab) as radialButton;
			newButton.transform.SetParent (transform.GetChild (0));
			//newButton.transform.localScale = n

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
