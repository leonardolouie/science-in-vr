using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class login : MonoBehaviour {

	string CreateUserUrl="http://192.168.0.31:81/superweb/webscivre/public/api/webscivreapilogin";
 	public InputField name;
	public InputField password;
<<<<<<< HEAD
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

=======
	public void Login()
	{
		StartCoroutine (LoginDB (name.text, password.text));
>>>>>>> cedbc6e40fa10e9e109e1a5b59d5ffb3750f5953
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

<<<<<<< HEAD



	
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


=======
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
>>>>>>> cedbc6e40fa10e9e109e1a5b59d5ffb3750f5953

		
		}
	}

}
