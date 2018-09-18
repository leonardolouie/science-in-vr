using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class login : MonoBehaviour {

	//string CreateUserUrl="localhost:81/superweb/webscivre/public/api/webscivreapilogin";
	string Url="localhost:81/scivre/public/api/webscivreapilogin"; //aj link
	public InputField name;
	public InputField password;
	public Text id;
	public Text errorfield;
	public GameObject loginPanel, registerPanel,mainMenuPanel;
	public Text Hello;
	public Text fullname;
	public Text student_id;
	public Text user;


	void Start(){
		/*if (PlayerPrefs.GetInt ("isLogged") == 1) {
			// dito ilalagay ung syncing ng data kung naka save, at nakapag Login na thru internet
			loginPanel.SetActive (false);
			registerPanel.SetActive (false);
			mainMenuPanel.SetActive (true);
		}*/
	}


	public void Login()
	{
		if (name.text != "" && password.text != "") {
			StartCoroutine (LoginDB (name.text, password.text));
		} 
		else 
 		{
			/*PlayerPrefs.SetInt ("isLogged", 1);
			loginPanel.SetActive (false);
			registerPanel.SetActive (false);
			mainMenuPanel.SetActive (true);*/

			errorfield.text = "All fields are required";
		}
	}
	IEnumerator LoginDB(string username, string password)
	{
		errorfield.text = "";
		/*if (Validation1.checkConnectionfail() == true)
		{
			errorfield.text = "Error: Internet Connection";
		} 
		else 
		{*/
			WWWForm form = new WWWForm ();

			form.AddField ("name", username);
			form.AddField ("password", password);
		
			using (UnityWebRequest www = UnityWebRequest.Post (Url, form)) 
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
						loginPanel.SetActive (false);
						registerPanel.SetActive (false);
						mainMenuPanel.SetActive (true);
						StartCoroutine (fetch (username));
						Hello.text = "Hi!, "+PlayerPrefs.GetString ("first_name");
						fullname.text = PlayerPrefs.GetString ("first_name")+" "+PlayerPrefs.GetString ("middle_name")+" "+PlayerPrefs.GetString ("last_name");
						student_id.text = PlayerPrefs.GetInt ("id")+" ";
						user.text = PlayerPrefs.GetString ("name")+" ";
					    

					} 
					else
					{
						errorfield.text = userDetail.message;
					}
				}
			//}
		}
	}


	IEnumerator fetch(string name)
	{

		string SetUrl = "localhost:81/scivre/public/api/webscivreapifetch";

		if(Validation1.checkConnectionfail() == true)
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
					PlayerPrefs.SetString ("name", userData.name);
					PlayerPrefs.SetInt ("isLogged", 1);


					//id.text = PlayerPrefs.GetInt ("id").ToString();
					//student_name.text = PlayerPrefs.GetString ("firs_name");
				}
			}
		}
	}
}