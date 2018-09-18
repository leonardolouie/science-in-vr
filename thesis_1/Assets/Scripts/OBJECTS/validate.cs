using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class validate : MonoBehaviour {

	public Image def,solar,anatomy;
	Image a;
	public GameObject mainPanel,loginPanel;
	public InputField user,pass;
	// Use this for initialization
	public void test(){
		if (user.text == "123456" && pass.text == "password") {
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
