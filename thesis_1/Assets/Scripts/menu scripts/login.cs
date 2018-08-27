using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class login : MonoBehaviour {

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