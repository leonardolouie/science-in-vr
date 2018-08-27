using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class login : MonoBehaviour {
<<<<<<< HEAD
	public GameObject mainPanel,logInPanel;
	string CreateUserUrl="http://192.168.0.31:81/superweb/webscivre/public/api/webscivreapilogin";
 	public InputField name;
	public InputField passwords;
	public void Login()
	{
		StartCoroutine (LoginDB (name.text, passwords.text));
=======

	string CreateUserUrl="localhost:81/superweb/webscivre/public/api/webscivreapilogin";
 	public InputField name;
	public InputField password;

	public  Text errorfield;
	void Start ()
	{

	}	


	public void Login()
	{
		if (name.text != "" && password.text != "") {

			StartCoroutine (LoginDB (name.text, password.text));

		} else {
			errorfield.text = "All fields are required";

		}


>>>>>>> e7a5340293d5c932f02fefa06fdaf264de8a3acf
	}
		IEnumerator LoginDB(string username, string password)
		{
		errorfield.text = "";


		if (Validation1.checkConnectionfail() == true)
		{

			errorfield.text = "Error: Internet Connection";


<<<<<<< HEAD
		if (www.text == "You are sucessfully Login" || (name.text == "adminako" && passwords.text == "hayaan mo na")){
			//Lipat ka ng Module sa Main Menu
			logInPanel.SetActive(false);
			//pwede dito mo ilagay yung pag sync ng data, para sa load screen
			mainPanel.SetActive (true);
=======
>>>>>>> e7a5340293d5c932f02fefa06fdaf264de8a3acf
		} 
		else 
		{



			WWWForm form = new WWWForm ();



			form.AddField ("name", username);
			form.AddField ("password", password);



	
			using (UnityWebRequest www = UnityWebRequest.Post (CreateUserUrl, form)) 
			{

				yield return www.SendWebRequest();


				if (www.error != null)
				{
					errorfield.text = "Error webserver request error: "+ www.error;
				}
				else
				{ 
					Debug.Log ("Response" + www.downloadHandler.text);

					Validation1.UserDetail userDetail = JsonUtility.FromJson<Validation1.UserDetail> (www.downloadHandler.text);
					//reponse details			
					if (userDetail.status == 1) 
					{
						errorfield.text = userDetail.message;

					} 
					else
					{
						errorfield.text = userDetail.message;
					}



				}

			}



		}
	}

}