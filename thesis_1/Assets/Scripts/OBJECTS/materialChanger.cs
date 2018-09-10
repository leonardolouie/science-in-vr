using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialChanger : MonoBehaviour {
	public radialMenu menuPrefab;
	public Renderer objectToChange;
	[HideInInspector]
	public bool pointerOverButton,pointerOverMenu;

	[System.Serializable]
	public class MaterialInfo{
		public string title;
		public Material material;
	}

	public MaterialInfo[] materials;

	private radialMenu currentMenu;
	private Transform childCollider;



	// Use this for initialization
	void Start () {
		childCollider = transform.GetChild (0);
		
	}
	public void OnPointerEnter(){
		pointerOverMenu = true;
		//spawn menu
		if(currentMenu == null){
			currentMenu = Instantiate (menuPrefab) as radialMenu;
			currentMenu.transform.position = transform.position;
			childCollider.localScale = new Vector3 (0.85f,0.001f,0.85f);

			//spawn Buttons
			 
		}
	}
	public void OnPointerExit(){
		pointerOverMenu = false;
	}

	public IEnumerator DestroyMenu(){
		yield return new WaitForEndOfFrame ();
		if (pointerOverButton == false && pointerOverMenu == false){
			Destroy (currentMenu.gameObject);
			childCollider.localScale = new Vector3 (0.25f, 0.001f, 0.25f);
		}
	}
	   
	// Update is called once per frame
	void Update () {
		
	}
}
