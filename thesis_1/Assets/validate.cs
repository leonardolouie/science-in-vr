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
		if (user.text == "username" && pass.text == "password") {
			mainPanel.SetActive (true);
			loginPanel.SetActive (false);
		} else
			Debug.Log ("OOPS");
	}
	void Awake(){
		a = def;
	}
}
