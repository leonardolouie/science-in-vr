using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class login : MonoBehaviour {

	string CreateUserUrl="http://192.168.0.31:81/superweb/webscivre/public/api/webscivreapilogin";
 	public InputField name;
	public InputField password;
	public void Login()
	{
		StartCoroutine (LoginDB (name.text, password.text));
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

		if (www.text == "You are sucessfully Login") {
			//Lipat ka ng Module sa Main Menu
		} 
		else {
			//male password

		}
	}

}
