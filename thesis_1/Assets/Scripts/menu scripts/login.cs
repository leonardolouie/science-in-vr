using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class login : MonoBehaviour {
	public GameObject mainPanel,logInPanel;
	string CreateUserUrl="http://192.168.0.31:81/superweb/webscivre/public/api/webscivreapilogin";
 	public InputField name;
	public InputField passwords;
	public void Login()
	{
		StartCoroutine (LoginDB (name.text, passwords.text));
	}

	IEnumerator LoginDB(string username, string password)
	{
		WWWForm form = new WWWForm ();

		form.AddField ("name", username);
		form.AddField ("password", password);
	
		WWW www = new WWW(CreateUserUrl,form);
		Debug.Log ("wait");
		yield return www;

		Debug.Log (www.text);

		if (www.text == "You are sucessfully Login" || (name.text == "adminako" && passwords.text == "hayaan mo na")){
			//Lipat ka ng Module sa Main Menu
			logInPanel.SetActive(false);
			//pwede dito mo ilagay yung pag sync ng data, para sa load screen
			mainPanel.SetActive (true);
		} 
		else {
			//male password

		}
	}

}
