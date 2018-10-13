using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dashPanel : MonoBehaviour {

	public bool home;
	public GameObject[] progress;
	float timeBetween = 5f, nextTime = 3f;
	void Update () {
			for (int i = 0; i < progress.Length; i++) {
				if (progress [i].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount * 100 < PlayerPrefs.GetInt ("Score" + (i + 1), 13) / 15 * 50 + 50) {
					progress [i].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount += 1 / 3f * Time.deltaTime;
				}
			}
	}
	public void reset(){
		for (int i = 0; i < progress.Length; i++) 
			progress [i].transform.GetChild (2).gameObject.GetComponent<Image> ().fillAmount = 0f;
		
	}

}