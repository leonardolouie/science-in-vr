using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class login : MonoBehaviour {

	//string CreateUserUrl="localhost:81/superweb/webscivre/public/api/webscivreapilogin";
	string CreateUserUrl="localhost:81/superweb/webscivre/public/api/webscivreapiregister"; //aj link
	public InputField name;
	public InputField password;
	public Text student_name;
	public Text id;


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
						StartCoroutine (fetch (username));

					} 
					else
					{
						errorfield.text = userDetail.message;
					}



				}

			}



		}
	}


	IEnumerator fetch(string name)
	{

		string SetUrl = "localhost:81/superweb/webscivre/public/api/webscivreapifetch";

		if (Validation1.checkConnectionfail() == true)
		{

			Debug.Log ("Error: Internet Connection");


		} 
		else 
		{


			WWWForm form = new WWWForm ();
			form.AddField ("name", name);




			using (UnityWebRequest www = UnityWebRequest.Post (SetUrl, form)) 
			{

				yield return www.SendWebRequest();


				if (www.error != null)
				{
					Debug.Log("Error webserver request error: "+ www.error);
				}
				else
				{ 
					Debug.Log ("Response" + www.downloadHandler.text);

					Validation1.UserData userData= JsonUtility.FromJson<Validation1.UserData> (www.downloadHandler.text);
					//reponse details	
					PlayerPrefs.SetInt("id", userData.id);
					PlayerPrefs.SetString ("first_name", userData.first_name);
					PlayerPrefs.SetString ("middle_name", userData.middle_name);
					PlayerPrefs.SetString ("last_name", userData.last_name);




					id.text += PlayerPrefs.GetInt ("id").ToString();
					//student_name.text = PlayerPrefs.GetString ("firs_name");



					 
				}

			}



		}
	}






}