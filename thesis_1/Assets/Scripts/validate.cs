using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class validate : MonoBehaviour {
	
	bool aa = true;
	public Text try2;
	public Image def,solar,anatomy,try1;
	Image a;
	public GameObject mainPanel,loginPanel;
	public InputField user,pass;
	// Use this for initialization
	void Update(){
		if (try1.fillAmount != 0f && aa) {
			try1.fillAmount -= 0.5f * Time.deltaTime;
			if (try1.fillAmount == 0f)
				aa = false;
		} else {
			try1.fillAmount += 0.5f * Time.deltaTime;
			if (try1.fillAmount == 1f)
				aa = true;
		}

		//if (try1.fillAmount < 1f)
			//try1.fillAmount += 0.01f;

		try2.text = (try1.fillAmount * 100f).ToString ();
	}
	public void test(){
		if (user.text == "username" && pass.text == "password") {
			mainPanel.SetActive (true);
			loginPanel.SetActive (false);
		} else
			Debug.Log ("OOPS");
	}
	void Awake(){
		a = def;
	}
	public void defaultBg(){
		StartCoroutine (load(def,solar,anatomy));
	}
	public void solarBg(){
		StartCoroutine (load(solar,def,anatomy));
	}
	public void anatomyBg(){
		StartCoroutine (load(anatomy,solar,def));
	}
	IEnumerator load(Image a,Image b,Image c){
		//fade out  b and c//
		a.canvasRenderer.SetAlpha(1.0f); // image need to be load
		b.CrossFadeAlpha(0.0f,0.5f,false);
		c.CrossFadeAlpha(0.0f,0.5f,false);
		yield return new WaitForSeconds (0.25f);

	}
}
