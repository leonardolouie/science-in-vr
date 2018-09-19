using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class exit : MonoBehaviour {
	public void QuitGame()
	{
		Debug.Log ("As you wish! :)");
		Application.Quit();
	}
	public void toggleMode(int OnOff){
		PlayerPrefs.SetInt ("isVron", OnOff);
	}
}
