using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class humanAnatomyManager : MonoBehaviour {
	public GameObject animPanelShow,text;
	private bool startOrganRotation = false,strSlctdOrgnRot;
	float organSpeedRotation = 3f;
	public Text header,organName,organDesc;
	MainMenu m;
	Text nameOrgan;
	int whatSystem;
	public GameObject[] anatomySystemsPrefabs;
	public Material onClikMat;
	anatomyManager anatomymanager;
	public Transform spawnPointVr,humanBase,spawnPointOrgan;

	void Start(){
		m = FindObjectOfType<MainMenu> ();
	}
	void Awake(){
		if(!VrOn.isVROn) {
			whatSystem = PlayerPrefs.GetInt ("whatSystem", 0);
			switch (whatSystem) {
			case 0:
				header.text = "Digestive System";
				break;
			case 1:
				header.text = "Respiratory System";
				break;
			case 2:
				header.text = "Urinary System";
				break;
			case 3:
				header.text = "Skeletal System";
				break;
			case 4:
				header.text = "Muscular System";
				break;
			case 5:
				header.text = "Circulatory System";
				break;
			case 6:
				header.text = "Nervous System";
				break;
			case 7:
				header.text = "Endocrine System";
				break;
			default:
				break;
			}
			if (whatSystem == 3 || whatSystem == 4 || whatSystem == 5) {
				Instantiate (anatomySystemsPrefabs [whatSystem], humanBase.position, anatomySystemsPrefabs [whatSystem].transform.rotation);
				humanBase.gameObject.SetActive (false);
			} else {
				Instantiate (anatomySystemsPrefabs [whatSystem], humanBase.position, anatomySystemsPrefabs [whatSystem].transform.rotation);
			}

		}
		anatomymanager = FindObjectOfType<anatomyManager> ();
	
	}
	public void playRotation(bool start){
		startOrganRotation = start;
	}

	public void setSpeedRotation(float speed){
		organSpeedRotation = Mathf.Lerp (organSpeedRotation, speed, 1.5f);
	}
		
	public void showMoreInfo(){
		GameObject system = GameObject.FindWithTag ("system");
		strSlctdOrgnRot = true;
		GameObject organ = Instantiate (system.transform.GetChild (anatomyDialogue.selectedOrgans).gameObject,spawnPointOrgan)as GameObject;
		organ.transform.position = spawnPointOrgan.position;
		organ.GetComponent<anatomyDialogue> ().enabled = false;

	}

	void Update(){
		if (startOrganRotation) {
			spawnPointVr.RotateAround (spawnPointVr.transform.position, Vector3.up, organSpeedRotation * Time.deltaTime);
		}
		if (strSlctdOrgnRot) {
			spawnPointOrgan.Rotate(25f * Time.deltaTime,0f,0f);
		}
	}
	public void hide(){
		anatomymanager.hideOrgans ();
	}
	public void showAll(){
		anatomymanager.showOrgans ();
	}
	public void showAllVr(){
		GameObject system = GameObject.FindWithTag ("system");
		for (int i = 0; i < system.transform.childCount; i++) {
			system.transform.GetChild (i).gameObject.SetActive (true);
		}
	}

	public void vrOn(){
		Destroy (GameObject.FindWithTag ("system"));
		//Invoke ("a", 10f);
		GameObject a = Instantiate (anatomySystemsPrefabs [whatSystem], spawnPointVr.position, anatomySystemsPrefabs [whatSystem].transform.rotation) as GameObject;
		a.transform.SetParent (spawnPointVr);
		a.transform.localScale = new Vector3 (2, 2.4f, 2);
	}
	public void robotMenu(){
	}
	public void infoScreen(string name, string desc){
		organName.text = name;
		organDesc.text = desc;
		GameObject.FindWithTag ("organName").GetComponent<Text> ().text = name;

	
	}


	public IEnumerator turnOff(){
		text.SetActive (true);
		yield return new WaitForSeconds (10f);
		//text.transform.GetChild(0).gameObject.GetComponent<Image>().CrossFadeAlpha (0f, 2f, false);
		//text.SetActive (false);

		UnityEngine.XR.XRSettings.LoadDeviceByName ("none");
		UnityEngine.XR.XRSettings.enabled = false;
		//going to main menu
		m.Home ();
	}
}