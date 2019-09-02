using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dashPanel : MonoBehaviour {

	public bool home;
	public GameObject[] progress;


	void Start(){
		progress [0].transform.GetChild (0).gameObject.GetComponent<Text> ().text =	PlayerPrefs.GetInt("Score1")+ "/15";
		progress [0].transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = (PlayerPrefs.GetInt ("Score1",45) / 15 * 50 + 50) + "%";

		progress [1].transform.GetChild (0).gameObject.GetComponent<Text> ().text =	PlayerPrefs.GetInt("Score2")+ "/15";
		progress [1].transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = (PlayerPrefs.GetInt ("Score2") / 15 * 50 + 50) + "%";

		progress [2].transform.GetChild (0).gameObject.GetComponent<Text> ().text =	PlayerPrefs.GetInt("Score3")+ "/15";
		progress [2].transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = (PlayerPrefs.GetInt ("Score3") / 15 * 50 + 50) + "%";

		progress [3].transform.GetChild (0).gameObject.GetComponent<Text> ().text =	PlayerPrefs.GetInt("Score4")+ "/15";
		progress [3].transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = (PlayerPrefs.GetInt ("Score4") / 15 * 50 + 50) + "%";

		progress [4].transform.GetChild (0).gameObject.GetComponent<Text> ().text =	PlayerPrefs.GetInt("Score5")+ "/15";
		progress [4].transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = ((PlayerPrefs.GetInt ("Score5",0) / 15 * 50) + 50).ToString() + "%";

		progress [5].transform.GetChild (0).gameObject.GetComponent<Text> ().text =	PlayerPrefs.GetInt("Score6")+ "/15";
		progress [5].transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = (PlayerPrefs.GetInt ("Score6") / 15 * 50 + 50) + "%";

		progress [6].transform.GetChild (0).gameObject.GetComponent<Text> ().text =	PlayerPrefs.GetInt("Score7")+ "/15";
		progress [6].transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = (PlayerPrefs.GetInt ("Score7") / 15 * 50 + 50) + "%";

		progress [7].transform.GetChild (0).gameObject.GetComponent<Text> ().text =	PlayerPrefs.GetInt("Score8")+ "/15";
		progress [7].transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = (PlayerPrefs.GetInt ("Score8") / 15 * 50 + 50) + "%";

		progress [8].transform.GetChild (0).gameObject.GetComponent<Text> ().text =	PlayerPrefs.GetInt("Score9")+ "/15";
		progress [8].transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = (PlayerPrefs.GetInt ("Score9") / 15 * 50 + 50) + "%";
	}



	void Update () {
		Debug.Log ((PlayerPrefs.GetInt ("Score1") / 15 * 50 + 50).ToString ());
		if (progress [0].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount * 100 < (float)(PlayerPrefs.GetInt ("Score1") / 15 * 50 + 50)) {
			progress [0].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount += 1 / 3f * Time.deltaTime;
		}

		if (progress [1].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount * 100 < (float)(PlayerPrefs.GetInt ("Score2") / 15 * 50 + 50)) {
			progress [1].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount += 1 / 3f * Time.deltaTime;
		}

		if (progress [2].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount * 100 < (float)(PlayerPrefs.GetInt ("Score3") / 15 * 50 + 50)) {
			progress [2].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount += 1 / 3f * Time.deltaTime;
		}

		if (progress [3].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount * 100 < (float)(PlayerPrefs.GetInt ("Score4") / 15 * 50 + 50)) {
			progress [3].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount += 1 / 3f * Time.deltaTime;
		}

		if (progress [4].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount * 100 < (float)(PlayerPrefs.GetInt ("Score5") / 15 * 50 + 50)) {
			progress [4].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount += 1 / 3f * Time.deltaTime;
		}

		if (progress [5].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount * 100 < (float)(PlayerPrefs.GetInt ("Score6") / 15 * 50 + 50)) {
			progress [5].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount += 1 / 3f * Time.deltaTime;
		}

		if (progress [6].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount * 100 < (float)(PlayerPrefs.GetInt ("Score7") / 15 * 50 + 50)) {
			progress [6].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount += 1 / 3f * Time.deltaTime;
		}

		if (progress [7].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount * 100 < (float)(PlayerPrefs.GetInt ("Score8") / 15 * 50 + 50)) {
			progress [7].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount += 1 / 3f * Time.deltaTime;
		}

		if (progress [8].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount * 100 < (float)(PlayerPrefs.GetInt ("Score9") / 15 * 50 + 50)) {
			progress [8].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount += 1 / 3f * Time.deltaTime;
		}
				
	}
		
	public void reset(){
		for (int i = 0; i < progress.Length; i++) 
			progress [i].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount = 0f;
	}
}