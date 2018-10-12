using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dashPanel : MonoBehaviour {


	public GameObject[] progress;
	int index;
	float timeBetween = 5f, nextTime = 3f;
	// Use this for initialization
	void Start () {
		//StartCoroutine (loadProgress ());
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timeBetween) {
			
			progress[index].transform.GetChild(2).gameObject.GetComponent<Image>().fillAmount += 1f / 3f * Time.deltaTime;
			if (Time.time > nextTime) {
				index++;
				timeBetween += Time.time;
			}
		}
	}


}
