using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class login : MonoBehaviour {

	string CreateUserUrl="localhost:81/superweb/webscivre/public/api/webscivreapilogin";
 	public InputField name;
	public InputField password;
	public  Text errorfield;
	void Start () {

	}
	//qweqweqweqweqwe

	// Update is called once per frame


	public void Login()
	{
		if (name.text != "" && password.text != "") {

			StartCoroutine (LoginDB (name.text, password.text));

		}
		else 
		{
			errorfield.text = "All fields are required";

		}

	}

	IEnumerator LoginDB(string username, string password)

	{
		errorfield.text = "";


		if (Validation1.checkConnectionfail() == true)
		{

			errorfield.text = "Error: Internet Connection";


		} 
		else 
		{



			WWWForm form = new WWWForm ();



			form.AddField ("name", username);
			form.AddField ("password", password);

			WWW www = new WWW(CreateUserUrl,form);
			Debug.Log ("wait");

			yield return www;

			Debug.Log (www.text);



			if (www.error == null) {
				
				if (www.text == "You are sucessfully Login") {
					//Lipat ka ng Module sa Main Menu
					errorfield.text = "Succesfully Logged in"; 
				} 
				else {

					errorfield.text = www.text;
				}

			} else 
			{

				errorfield.text = "Cannot connect to web server" + www.error;
			}

		}


	}

}
